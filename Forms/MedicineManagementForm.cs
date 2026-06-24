using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SmartMedPharmacy.Models;
using SmartMedPharmacy.Services;
using SmartMedPharmacy.Utilities;

namespace SmartMedPharmacy.Forms
{
    public partial class MedicineManagementForm : Form
    {
        private int _selectedMedicineId = -1;

        public MedicineManagementForm()
        {
            InitializeComponent();
        }

        private void MedicineManagementForm_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("All");
            cmbFilterCategory.Items.Add("Antibiotics");
            cmbFilterCategory.Items.Add("Painkillers");
            cmbFilterCategory.Items.Add("Cardiology");
            cmbFilterCategory.Items.Add("Vitamins");
            cmbFilterCategory.Items.Add("Other");
            cmbFilterCategory.SelectedIndex = 0;

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Antibiotics");
            cmbCategory.Items.Add("Painkillers");
            cmbCategory.Items.Add("Cardiology");
            cmbCategory.Items.Add("Vitamins");
            cmbCategory.Items.Add("Other");
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadMedicines()
        {
            try
            {
                List<Medicine> medicines = MedicineService.GetAllMedicines();
                dgvMedicines.DataSource = ConvertToDataTable(medicines);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load medicines: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertToDataTable(List<Medicine> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicineID", typeof(int));
            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Dosage", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Supplier", typeof(string));
            dt.Columns.Add("ExpiryDate", typeof(DateTime));
            dt.Columns.Add("Discount", typeof(decimal));
            dt.Columns.Add("FinalPrice", typeof(decimal));

            foreach (var med in list)
            {
                dt.Rows.Add(med.MedicineID, med.MedicineName, med.Category, med.Dosage, med.Price, med.Stock, med.Supplier, med.ExpiryDate, med.Discount, med.FinalPrice);
            }
            return dt;
        }

        private void ClearForm()
        {
            txtMedicineName.Clear();
            cmbCategory.SelectedIndex = 0;
            txtDosage.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            txtSupplier.Clear();
            dtpExpiryDate.Value = DateTime.Today.AddMonths(6);
            txtDiscount.Text = "0.00";
            _selectedMedicineId = -1;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out Medicine med)) return;

            try
            {
                if (MedicineService.AddMedicine(med))
                {
                    MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMedicines();
                }
                else
                {
                    MessageBox.Show("Failed to add medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception Raised", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMedicineId == -1) return;
            if (!ValidateInputs(out Medicine med)) return;

            med.MedicineID = _selectedMedicineId;

            try
            {
                if (MedicineService.UpdateMedicine(med))
                {
                    MessageBox.Show("Medicine updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMedicines();
                }
                else
                {
                    MessageBox.Show("Failed to update medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception Raised", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMedicineId == -1) return;

            var confirmResult = MessageBox.Show("Are you sure you want to delete this medicine?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (MedicineService.DeleteMedicine(_selectedMedicineId))
                    {
                        MessageBox.Show("Medicine deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMedicines();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Exception Raised", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMedicines.Rows[e.RowIndex];
                _selectedMedicineId = Convert.ToInt32(row.Cells["MedicineID"].Value);
                txtMedicineName.Text = row.Cells["MedicineName"].Value.ToString();
                
                string category = row.Cells["Category"].Value.ToString();
                if (cmbCategory.Items.Contains(category))
                    cmbCategory.SelectedItem = category;
                else
                    cmbCategory.SelectedIndex = 0;

                txtDosage.Text = row.Cells["Dosage"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
                txtSupplier.Text = row.Cells["Supplier"].Value.ToString();
                dtpExpiryDate.Value = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);
                txtDiscount.Text = row.Cells["Discount"].Value.ToString();

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchKeyword.Text.Trim();
            try
            {
                List<Medicine> all = MedicineService.GetAllMedicines();
                
                // Implement O(N) Linear Search as required by prompt
                List<Medicine> filtered = LinearSearchHelper.LinearSearch(all, keyword);

                dgvMedicines.DataSource = ConvertToDataTable(filtered);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                List<Medicine> all = MedicineService.GetAllMedicines();
                string category = cmbFilterCategory.SelectedItem.ToString();
                if (category == "All") category = null;

                // Implement LINQ Filtering as required by prompt
                List<Medicine> filtered = LinearSearchHelper.LinqFilter(all, category, null, null);

                if (chkLowStock.Checked)
                {
                    filtered = filtered.Where(m => m.IsLowStock(10)).ToList();
                }

                if (chkExpiringSoon.Checked)
                {
                    filtered = filtered.Where(m => m.IsExpiringSoon()).ToList();
                }

                dgvMedicines.DataSource = ConvertToDataTable(filtered);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filtering failed: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool ValidateInputs(out Medicine med)
        {
            med = null;
            string name = txtMedicineName.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString();
            string dosage = txtDosage.Text.Trim();
            string supplier = txtSupplier.Text.Trim();
            DateTime expiry = dtpExpiryDate.Value;

            if (Validator.IsEmpty(name) || Validator.IsEmpty(category))
            {
                MessageBox.Show("Medicine Name and Category are required.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Validator.IsValidPrice(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid positive decimal price.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Validator.IsValidStock(txtStock.Text, out int stock))
            {
                MessageBox.Show("Please enter a valid non-negative integer stock value.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount < 0 || discount > 100)
            {
                MessageBox.Show("Please enter a valid discount percentage (0 to 100).", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            med = new Medicine
            {
                MedicineName = name,
                Category = category,
                Dosage = dosage,
                Price = price,
                Stock = stock,
                Supplier = supplier,
                ExpiryDate = expiry,
                Discount = discount
            };

            return true;
        }
    }
}
