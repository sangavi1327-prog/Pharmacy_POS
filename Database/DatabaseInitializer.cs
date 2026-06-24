using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SmartMedPharmacy.Database
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            string masterConnString = ConfigurationManager.ConnectionStrings["MasterDb"]?.ConnectionString;
            string smartMedConnString = ConfigurationManager.ConnectionStrings["SmartMedDb"]?.ConnectionString;

            if (string.IsNullOrEmpty(masterConnString) || string.IsNullOrEmpty(smartMedConnString))
            {
                MessageBox.Show("Connection strings are not configured in App.config.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 1. Check if database exists, create it if not
                using (SqlConnection masterConn = new SqlConnection(masterConnString))
                {
                    masterConn.Open();
                    string checkDbQuery = "SELECT database_id FROM sys.databases WHERE name = 'SmartMedPharmacyDB'";
                    using (SqlCommand cmd = new SqlCommand(checkDbQuery, masterConn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            // Create Database
                            string createDbQuery = "CREATE DATABASE SmartMedPharmacyDB";
                            using (SqlCommand createCmd = new SqlCommand(createDbQuery, masterConn))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // 2. Initialize Tables
                using (SqlConnection dbConn = new SqlConnection(smartMedConnString))
                {
                    dbConn.Open();

                    // Load DbSchema.sql or execute commands directly
                    string schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "DbSchema.sql");
                    string sqlSchema = "";

                    if (File.Exists(schemaPath))
                    {
                        sqlSchema = File.ReadAllText(schemaPath);
                    }
                    else
                    {
                        sqlSchema = GetFallbackSchema();
                    }

                    // Execute schemas by command
                    string[] commands = sqlSchema.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var commandText in commands)
                    {
                        if (string.IsNullOrWhiteSpace(commandText)) continue;
                        using (SqlCommand cmd = new SqlCommand(commandText, dbConn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3. Seed Default Admin
                    string checkAdminQuery = "SELECT COUNT(*) FROM [Admin] WHERE Username = 'admin'";
                    using (SqlCommand checkAdminCmd = new SqlCommand(checkAdminQuery, dbConn))
                    {
                        int adminCount = (int)checkAdminCmd.ExecuteScalar();
                        if (adminCount == 0)
                        {
                            string seedAdminQuery = "INSERT INTO [Admin] (Username, Password) VALUES ('admin', 'admin123')";
                            using (SqlCommand seedCmd = new SqlCommand(seedAdminQuery, dbConn))
                            {
                                seedCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Critical Database Initialization Failed:\n\n{ex.Message}\n\nPlease check if SQL Server LocalDB is running.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static string GetFallbackSchema()
        {
            return @"
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Admin')
            BEGIN
                CREATE TABLE [Admin] (
                    AdminID INT IDENTITY PRIMARY KEY,
                    Username NVARCHAR(50) NOT NULL,
                    Password NVARCHAR(50) NOT NULL
                );
            END;

            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Customer')
            BEGIN
                CREATE TABLE [Customer] (
                    CustomerID INT IDENTITY PRIMARY KEY,
                    FullName NVARCHAR(100) NOT NULL,
                    Email NVARCHAR(100) NOT NULL,
                    Phone NVARCHAR(20) NULL,
                    Address NVARCHAR(200) NULL,
                    Username NVARCHAR(50) NOT NULL,
                    Password NVARCHAR(50) NOT NULL
                );
            END;

            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Medicine')
            BEGIN
                CREATE TABLE [Medicine] (
                    MedicineID INT IDENTITY PRIMARY KEY,
                    MedicineName NVARCHAR(100) NOT NULL,
                    Category NVARCHAR(100) NOT NULL,
                    Dosage NVARCHAR(100) NULL,
                    Price DECIMAL(10,2) NOT NULL,
                    Stock INT NOT NULL,
                    Supplier NVARCHAR(100) NULL,
                    ExpiryDate DATE NOT NULL,
                    Discount DECIMAL(5,2) DEFAULT 0.00
                );
            END;

            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Orders')
            BEGIN
                CREATE TABLE [Orders] (
                    OrderID INT IDENTITY PRIMARY KEY,
                    CustomerID INT NOT NULL,
                    OrderDate DATETIME NOT NULL,
                    TotalAmount DECIMAL(10,2) NOT NULL,
                    Status NVARCHAR(50) NOT NULL
                );
            END;

            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'OrderItems')
            BEGIN
                CREATE TABLE [OrderItems] (
                    OrderItemID INT IDENTITY PRIMARY KEY,
                    OrderID INT NOT NULL,
                    MedicineID INT NOT NULL,
                    Quantity INT NOT NULL,
                    Price DECIMAL(10,2) NOT NULL
                );
            END;

            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Prescription')
            BEGIN
                CREATE TABLE [Prescription] (
                    PrescriptionID INT IDENTITY PRIMARY KEY,
                    CustomerID INT NOT NULL,
                    FilePath NVARCHAR(300) NOT NULL,
                    UploadDate DATETIME NOT NULL
                );
            END;
            ";
        }
    }
}
