using System;
using System.Data;
using System.Data.SqlClient;
using SmartMedPharmacy.DataAccess;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Services
{
    public class AuthenticationService
    {
        private static User _currentUser;
        public static User CurrentUser
        {
            get { return _currentUser; }
        }

        public static bool RegisterCustomer(string fullName, string email, string phone, string address, string username, string password)
        {
            string checkQuery = "SELECT COUNT(*) FROM [Customer] WHERE Username = @Username OR Email = @Email";
            SqlParameter[] checkParams = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email)
            };

            object result = DatabaseHelper.ExecuteScalar(checkQuery, checkParams);
            if (result != null && (int)result > 0)
            {
                throw new InvalidOperationException("Username or Email already exists.");
            }

            string insertQuery = @"
                INSERT INTO [Customer] (FullName, Email, Phone, Address, Username, Password)
                VALUES (@FullName, @Email, @Phone, @Address, @Username, @Password)";

            SqlParameter[] insertParams = {
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@Email", email),
                new SqlParameter("@Phone", (object)phone ?? DBNull.Value),
                new SqlParameter("@Address", (object)address ?? DBNull.Value),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            int affected = DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);
            return affected > 0;
        }

        public static User Login(string username, string password, bool isAdmin)
        {
            if (isAdmin)
            {
                string query = "SELECT AdminID, Username, Password FROM [Admin] WHERE Username = @Username AND Password = @Password";
                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    Admin admin = new Admin
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["AdminID"]),
                        Username = dt.Rows[0]["Username"].ToString(),
                        Password = dt.Rows[0]["Password"].ToString()
                    };
                    _currentUser = admin;
                    return admin;
                }
            }
            else
            {
                string query = "SELECT CustomerID, FullName, Email, Phone, Address, Username, Password FROM [Customer] WHERE Username = @Username AND Password = @Password";
                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    Customer customer = new Customer
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["CustomerID"]),
                        FullName = dt.Rows[0]["FullName"].ToString(),
                        Email = dt.Rows[0]["Email"].ToString(),
                        Phone = dt.Rows[0]["Phone"].ToString(),
                        Address = dt.Rows[0]["Address"].ToString(),
                        Username = dt.Rows[0]["Username"].ToString(),
                        Password = dt.Rows[0]["Password"].ToString()
                    };
                    _currentUser = customer;
                    return customer;
                }
            }

            return null;
        }

        public static bool UpdateCustomerProfile(int customerId, string fullName, string email, string phone, string address, string password)
        {
            string checkQuery = "SELECT COUNT(*) FROM [Customer] WHERE Email = @Email AND CustomerID != @CustomerID";
            SqlParameter[] checkParams = {
                new SqlParameter("@Email", email),
                new SqlParameter("@CustomerID", customerId)
            };

            object result = DatabaseHelper.ExecuteScalar(checkQuery, checkParams);
            if (result != null && (int)result > 0)
            {
                throw new InvalidOperationException("Email is already in use by another account.");
            }

            string updateQuery = @"
                UPDATE [Customer]
                SET FullName = @FullName, Email = @Email, Phone = @Phone, Address = @Address, Password = @Password
                WHERE CustomerID = @CustomerID";

            SqlParameter[] updateParams = {
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@Email", email),
                new SqlParameter("@Phone", (object)phone ?? DBNull.Value),
                new SqlParameter("@Address", (object)address ?? DBNull.Value),
                new SqlParameter("@Password", password),
                new SqlParameter("@CustomerID", customerId)
            };

            int affected = DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);
            Customer cust = _currentUser as Customer;
            if (affected > 0 && cust != null && cust.Id == customerId)
            {
                cust.FullName = fullName;
                cust.Email = email;
                cust.Phone = phone;
                cust.Address = address;
                cust.Password = password;
            }
            return affected > 0;
        }

        public static void Logout()
        {
            if (_currentUser != null)
            {
                _currentUser.Logout();
                _currentUser = null;
            }
        }
    }
}
