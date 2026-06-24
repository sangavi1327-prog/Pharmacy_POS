using System;
using System.Data;
using SmartMedPharmacy.DataAccess;
using SmartMedPharmacy.Interfaces;

namespace SmartMedPharmacy.Services
{
    public class ReportService : IReport
    {
        public DataTable GenerateSalesReport()
        {
            string query = @"
                SELECT o.OrderID, o.OrderDate, c.FullName AS CustomerName, o.TotalAmount, o.Status
                FROM [Orders] o
                JOIN [Customer] c ON o.CustomerID = c.CustomerID
                ORDER BY o.OrderDate DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public DataTable GenerateStockReport()
        {
            string query = @"
                SELECT MedicineID, MedicineName, Category, Price, Stock, ExpiryDate, Supplier, Discount,
                       CASE 
                           WHEN Stock = 0 THEN 'Out of Stock'
                           WHEN Stock <= 10 THEN 'Low Stock'
                           ELSE 'In Stock'
                       END AS StockStatus,
                       CASE 
                           WHEN ExpiryDate < GETDATE() THEN 'Expired'
                           WHEN DATEDIFF(day, GETDATE(), ExpiryDate) <= 30 THEN 'Expiring Soon'
                           ELSE 'Good'
                       END AS ExpiryStatus
                FROM [Medicine]
                ORDER BY Stock ASC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public DataTable GenerateCustomerReport()
        {
            string query = @"
                SELECT c.CustomerID, c.FullName, c.Email, c.Phone, c.Address,
                       COUNT(o.OrderID) AS TotalOrders,
                       ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent
                FROM [Customer] c
                LEFT JOIN [Orders] o ON c.CustomerID = o.CustomerID
                GROUP BY c.CustomerID, c.FullName, c.Email, c.Phone, c.Address
                ORDER BY TotalSpent DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static DataTable GetDashboardStats()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TotalSales", typeof(decimal));
            dt.Columns.Add("TotalOrders", typeof(int));
            dt.Columns.Add("TotalCustomers", typeof(int));
            dt.Columns.Add("TotalMedicines", typeof(int));
            dt.Columns.Add("LowStockCount", typeof(int));

            string salesQuery = "SELECT ISNULL(SUM(TotalAmount), 0) FROM [Orders] WHERE Status != 'Cancelled'";
            string ordersQuery = "SELECT COUNT(*) FROM [Orders]";
            string customersQuery = "SELECT COUNT(*) FROM [Customer]";
            string medsQuery = "SELECT COUNT(*) FROM [Medicine]";
            string lowStockQuery = "SELECT COUNT(*) FROM [Medicine] WHERE Stock <= 10";

            decimal sales = 0;
            object resSales = DatabaseHelper.ExecuteScalar(salesQuery);
            if (resSales != DBNull.Value && resSales != null) sales = Convert.ToDecimal(resSales);

            int orders = Convert.ToInt32(DatabaseHelper.ExecuteScalar(ordersQuery) ?? 0);
            int customers = Convert.ToInt32(DatabaseHelper.ExecuteScalar(customersQuery) ?? 0);
            int meds = Convert.ToInt32(DatabaseHelper.ExecuteScalar(medsQuery) ?? 0);
            int lowStock = Convert.ToInt32(DatabaseHelper.ExecuteScalar(lowStockQuery) ?? 0);

            dt.Rows.Add(sales, orders, customers, meds, lowStock);
            return dt;
        }
    }
}
