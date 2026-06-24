using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SmartMedPharmacy.DataAccess;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Services
{
    public class MedicineService
    {
        public static List<Medicine> GetAllMedicines()
        {
            List<Medicine> list = new List<Medicine>();
            string query = "SELECT * FROM [Medicine]";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToMedicine(row));
            }
            return list;
        }

        public static Medicine GetMedicineById(int id)
        {
            string query = "SELECT * FROM [Medicine] WHERE MedicineID = @MedicineID";
            SqlParameter[] parameters = { new SqlParameter("@MedicineID", id) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return MapRowToMedicine(dt.Rows[0]);
            }
            return null;
        }

        public static bool AddMedicine(Medicine med)
        {
            string query = @"
                INSERT INTO [Medicine] (MedicineName, Category, Dosage, Price, Stock, Supplier, ExpiryDate, Discount)
                VALUES (@MedicineName, @Category, @Dosage, @Price, @Stock, @Supplier, @ExpiryDate, @Discount)";

            SqlParameter[] parameters = {
                new SqlParameter("@MedicineName", med.MedicineName),
                new SqlParameter("@Category", med.Category),
                new SqlParameter("@Dosage", (object)med.Dosage ?? DBNull.Value),
                new SqlParameter("@Price", med.Price),
                new SqlParameter("@Stock", med.Stock),
                new SqlParameter("@Supplier", (object)med.Supplier ?? DBNull.Value),
                new SqlParameter("@ExpiryDate", med.ExpiryDate),
                new SqlParameter("@Discount", med.Discount)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public static bool UpdateMedicine(Medicine med)
        {
            string query = @"
                UPDATE [Medicine]
                SET MedicineName = @MedicineName, Category = @Category, Dosage = @Dosage, Price = @Price,
                    Stock = @Stock, Supplier = @Supplier, ExpiryDate = @ExpiryDate, Discount = @Discount
                WHERE MedicineID = @MedicineID";

            SqlParameter[] parameters = {
                new SqlParameter("@MedicineName", med.MedicineName),
                new SqlParameter("@Category", med.Category),
                new SqlParameter("@Dosage", (object)med.Dosage ?? DBNull.Value),
                new SqlParameter("@Price", med.Price),
                new SqlParameter("@Stock", med.Stock),
                new SqlParameter("@Supplier", (object)med.Supplier ?? DBNull.Value),
                new SqlParameter("@ExpiryDate", med.ExpiryDate),
                new SqlParameter("@Discount", med.Discount),
                new SqlParameter("@MedicineID", med.MedicineID)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public static bool DeleteMedicine(int id)
        {
            string query = "DELETE FROM [Medicine] WHERE MedicineID = @MedicineID";
            SqlParameter[] parameters = { new SqlParameter("@MedicineID", id) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public static List<Medicine> GetLowStockMedicines(int threshold = 10)
        {
            List<Medicine> list = new List<Medicine>();
            string query = "SELECT * FROM [Medicine] WHERE Stock <= @Threshold";
            SqlParameter[] parameters = { new SqlParameter("@Threshold", threshold) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToMedicine(row));
            }
            return list;
        }

        public static List<Medicine> GetExpiringSoonMedicines(int days = 30)
        {
            List<Medicine> list = new List<Medicine>();
            string query = "SELECT * FROM [Medicine] WHERE ExpiryDate <= @TargetDate AND ExpiryDate >= @Today";
            SqlParameter[] parameters = {
                new SqlParameter("@TargetDate", DateTime.Today.AddDays(days)),
                new SqlParameter("@Today", DateTime.Today)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToMedicine(row));
            }
            return list;
        }

        public static Medicine MapRowToMedicine(DataRow row)
        {
            return new Medicine
            {
                MedicineID = Convert.ToInt32(row["MedicineID"]),
                MedicineName = row["MedicineName"].ToString(),
                Category = row["Category"].ToString(),
                Dosage = row["Dosage"] != DBNull.Value ? row["Dosage"].ToString() : string.Empty,
                Price = Convert.ToDecimal(row["Price"]),
                Stock = Convert.ToInt32(row["Stock"]),
                Supplier = row["Supplier"] != DBNull.Value ? row["Supplier"].ToString() : string.Empty,
                ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                Discount = row["Discount"] != DBNull.Value ? Convert.ToDecimal(row["Discount"]) : 0m
            };
        }
    }
}
