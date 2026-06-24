using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SmartMedPharmacy.DataAccess;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Services
{
    public class OrderService
    {
        public static bool PlaceOrder(int customerId, List<CartItem> cartItems, decimal totalAmount, out string errorMessage)
        {
            errorMessage = string.Empty;
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = DatabaseHelper.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                // 1. Check stock availability for all items before starting
                foreach (var item in cartItems)
                {
                    string checkStockQuery = "SELECT Stock FROM [Medicine] WHERE MedicineID = @MedicineID";
                    using (SqlCommand checkCmd = new SqlCommand(checkStockQuery, conn, transaction))
                    {
                        checkCmd.Parameters.AddWithValue("@MedicineID", item.Medicine.MedicineID);
                        object stockObj = checkCmd.ExecuteScalar();
                        if (stockObj == null)
                        {
                            errorMessage = $"Medicine '{item.Medicine.MedicineName}' no longer exists.";
                            transaction.Rollback();
                            return false;
                        }
                        int currentStock = (int)stockObj;
                        if (currentStock < item.Quantity)
                        {
                            errorMessage = $"Insufficient stock for '{item.Medicine.MedicineName}'. Current stock is {currentStock}.";
                            transaction.Rollback();
                            return false;
                        }
                    }
                }

                // 2. Insert Order
                string insertOrderQuery = @"
                    INSERT INTO [Orders] (CustomerID, OrderDate, TotalAmount, Status)
                    VALUES (@CustomerID, @OrderDate, @TotalAmount, @Status);
                    SELECT SCOPE_IDENTITY();";

                int orderId = 0;
                using (SqlCommand orderCmd = new SqlCommand(insertOrderQuery, conn, transaction))
                {
                    orderCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    orderCmd.Parameters.AddWithValue("@Status", "Pending");

                    orderId = Convert.ToInt32(orderCmd.ExecuteScalar());
                }

                // 3. Insert Order Items and Update Stock
                foreach (var item in cartItems)
                {
                    string insertItemQuery = @"
                        INSERT INTO [OrderItems] (OrderID, MedicineID, Quantity, Price)
                        VALUES (@OrderID, @MedicineID, @Quantity, @Price)";

                    using (SqlCommand itemCmd = new SqlCommand(insertItemQuery, conn, transaction))
                    {
                        itemCmd.Parameters.AddWithValue("@OrderID", orderId);
                        itemCmd.Parameters.AddWithValue("@MedicineID", item.Medicine.MedicineID);
                        itemCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@Price", item.Medicine.FinalPrice);
                        itemCmd.ExecuteNonQuery();
                    }

                    string updateStockQuery = @"
                        UPDATE [Medicine]
                        SET Stock = Stock - @Quantity
                        WHERE MedicineID = @MedicineID";

                    using (SqlCommand stockCmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        stockCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        stockCmd.Parameters.AddWithValue("@MedicineID", item.Medicine.MedicineID);
                        stockCmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                errorMessage = ex.Message;
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }

        public static DataTable GetCustomerOrders(int customerId)
        {
            string query = @"
                SELECT OrderID, OrderDate, TotalAmount, Status
                FROM [Orders]
                WHERE CustomerID = @CustomerID
                ORDER BY OrderDate DESC";
            SqlParameter[] parameters = { new SqlParameter("@CustomerID", customerId) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public static DataTable GetOrderDetails(int orderId)
        {
            string query = @"
                SELECT oi.OrderItemID, oi.OrderID, oi.MedicineID, m.MedicineName, oi.Quantity, oi.Price, (oi.Quantity * oi.Price) AS SubTotal
                FROM [OrderItems] oi
                JOIN [Medicine] m ON oi.MedicineID = m.MedicineID
                WHERE oi.OrderID = @OrderID";
            SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public static DataTable GetAllOrders()
        {
            string query = @"
                SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status, c.FullName AS CustomerName, c.Phone
                FROM [Orders] o
                JOIN [Customer] c ON o.CustomerID = c.CustomerID
                ORDER BY o.OrderDate DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static bool UpdateOrderStatus(int orderId, string status)
        {
            string query = "UPDATE [Orders] SET Status = @Status WHERE OrderID = @OrderID";
            SqlParameter[] parameters = {
                new SqlParameter("@Status", status),
                new SqlParameter("@OrderID", orderId)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public static bool UploadPrescription(int customerId, string filePath)
        {
            string query = "INSERT INTO [Prescription] (CustomerID, FilePath, UploadDate) VALUES (@CustomerID, @FilePath, @UploadDate)";
            SqlParameter[] parameters = {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@FilePath", filePath),
                new SqlParameter("@UploadDate", DateTime.Now)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public static DataTable GetCustomerPrescriptions(int customerId)
        {
            string query = "SELECT PrescriptionID, FilePath, UploadDate FROM [Prescription] WHERE CustomerID = @CustomerID ORDER BY UploadDate DESC";
            SqlParameter[] parameters = { new SqlParameter("@CustomerID", customerId) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }

    public class CartItem
    {
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal => Medicine.FinalPrice * Quantity;
    }
}
