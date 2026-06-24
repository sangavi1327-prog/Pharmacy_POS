using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SmartMedPharmacy.DataAccess;
using SmartMedPharmacy.Utilities;

namespace SmartMedPharmacy.Forms
{
    public partial class CustomerManagementForm : Form
    {
        private int _selectedCustomerId = -1;

        public CustomerManagementForm()
        {
            InitializeComponent();
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                string query = "SELECT CustomerID, FullName, Email, Phone, Address, Username, Password FROM [Customer]";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvCustomers.DataSource = dt;
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customers: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtPassword.Clear();
            _selectedCustomerId = -1;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == -1) return;

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string password = txtPassword.Text;

            if (Validator.IsEmpty(fullName) || Validator.IsEmpty(email) || Validator.IsEmpty(password))
            {
                MessageBox.Show("Full Name, Email and Password are required.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(phone) && !Validator.IsValidPhone(phone))
            {
                MessageBox.Show("Please enter a valid phone number.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string checkQuery = "SELECT COUNT(*) FROM [Customer] WHERE Email = @Email AND CustomerID != @CustomerID";
                SqlParameter[] checkParams = {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@CustomerID", _selectedCustomerId)
                };
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams) ?? 0);
                if (count > 0)
                {
                    MessageBox.Show("Email is already used by another customer.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
                    UPDATE [Customer]
                    SET FullName = @FullName, Email = @Email, Phone = @Phone, Address = @Address, Password = @Password
                    WHERE CustomerID = @CustomerID";

                SqlParameter[] parameters = {
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Phone", (object)phone ?? DBNull.Value),
                    new SqlParameter("@Address", (object)address ?? DBNull.Value),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@CustomerID", _selectedCustomerId)
                };

                if (DatabaseHelper.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Failed to update customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception Raised", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                _selectedCustomerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();

                btnUpdate.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadCustomers();
                return;
            }

            try
            {
                string query = @"
                    SELECT CustomerID, FullName, Email, Phone, Address, Username, Password 
                    FROM [Customer]
                    WHERE FullName LIKE @Keyword OR Email LIKE @Keyword OR Phone LIKE @Keyword";
                SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
                
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvCustomers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
