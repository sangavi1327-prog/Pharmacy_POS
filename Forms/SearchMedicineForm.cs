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
    public partial class SearchMedicineForm : Form
    {
        private List<Medicine> _allMedicines = new List<Medicine>();
        private List<Medicine> _filteredMedicines = new List<Medicine>();
        private Medicine _selectedMedicine;

        public SearchMedicineForm()
        {
            InitializeComponent();
        }

        private void SearchMedicineForm_Load(object sender, EventArgs e)
        {
            LoadCategoryFilters();
            LoadSortOptions();
            FetchAllMedicines();
        }

        private void LoadCategoryFilters()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All");
            cmbCategory.Items.Add("Antibiotics");
            cmbCategory.Items.Add("Painkillers");
            cmbCategory.Items.Add("Cardiology");
            cmbCategory.Items.Add("Vitamins");
            cmbCategory.Items.Add("Other");
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadSortOptions()
        {
            cmbSort.Items.Clear();
            cmbSort.Items.Add("None");
            cmbSort.Items.Add("Name (A-Z)");
            cmbSort.Items.Add("Price (Low to High)");
            cmbSort.Items.Add("Price (High to Low)");
            cmbSort.SelectedIndex = 0;
        }

        private void FetchAllMedicines()
        {
            try
            {
                // Fetch non-expired medicines with stock > 0
                _allMedicines = MedicineService.GetAllMedicines()
                                               .Where(m => !m.IsExpired())
                                               .ToList();
                _filteredMedicines = new List<Medicine>(_allMedicines);
                DisplayMedicines(_filteredMedicines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to load medicines: {0}", ex.Message), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayMedicines(List<Medicine> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicineID", typeof(int));
            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Dosage", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Discount", typeof(decimal));
            dt.Columns.Add("FinalPrice", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("ExpiryDate", typeof(DateTime));

            foreach (var m in list)
            {
                dt.Rows.Add(m.MedicineID, m.MedicineName, m.Category, m.Dosage, m.Price, m.Discount, m.FinalPrice, m.Stock, m.ExpiryDate);
            }
            dgvSearch.DataSource = dt;
            lblSelectedMed.Text = "None Selected";
            _selectedMedicine = null;
            btnAddToCart.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            string category = cmbCategory.SelectedItem.ToString();
            if (category == "All") category = null;

            decimal? minPrice = null;
            decimal? maxPrice = null;

            if (!string.IsNullOrEmpty(txtMinPrice.Text))
            {
                decimal min;
                if (decimal.TryParse(txtMinPrice.Text, out min)) minPrice = min;
                else MessageBox.Show("Min Price must be a number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!string.IsNullOrEmpty(txtMaxPrice.Text))
            {
                decimal max;
                if (decimal.TryParse(txtMaxPrice.Text, out max)) maxPrice = max;
                else MessageBox.Show("Max Price must be a number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 1. Perform Linear Search first if keyword is provided as requested by the search algorithm criteria
            List<Medicine> results = _allMedicines;
            if (!string.IsNullOrEmpty(keyword))
            {
                results = LinearSearchHelper.LinearSearch(_allMedicines, keyword);
            }

            // 2. Apply LINQ Filtering for category and price ranges
            _filteredMedicines = LinearSearchHelper.LinqFilter(results, category, minPrice, maxPrice);

            // 3. Apply Sorting
            ApplySorting();

            DisplayMedicines(_filteredMedicines);
        }

        private void ApplySorting()
        {
            string sortOption = cmbSort.SelectedItem == null ? "None" : cmbSort.SelectedItem.ToString();
            if (sortOption == "Name (A-Z)")
            {
                _filteredMedicines = _filteredMedicines.OrderBy(m => m.MedicineName).ToList();
            }
            else if (sortOption == "Price (Low to High)")
            {
                _filteredMedicines = _filteredMedicines.OrderBy(m => m.FinalPrice).ToList();
            }
            else if (sortOption == "Price (High to Low)")
            {
                _filteredMedicines = _filteredMedicines.OrderByDescending(m => m.FinalPrice).ToList();
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySorting();
            DisplayMedicines(_filteredMedicines);
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int medId = Convert.ToInt32(dgvSearch.Rows[e.RowIndex].Cells["MedicineID"].Value);
                _selectedMedicine = _allMedicines.FirstOrDefault(m => m.MedicineID == medId);
                if (_selectedMedicine != null)
                {
                    lblSelectedMed.Text = string.Format("{0} - ${1:N2}", _selectedMedicine.MedicineName, _selectedMedicine.FinalPrice);
                    numQuantity.Maximum = _selectedMedicine.Stock;
                    numQuantity.Value = _selectedMedicine.Stock > 0 ? 1 : 0;
                    btnAddToCart.Enabled = _selectedMedicine.Stock > 0;
                }
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (_selectedMedicine == null) return;
            int qty = (int)numQuantity.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please select a quantity greater than zero.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qty > _selectedMedicine.Stock)
            {
                MessageBox.Show(string.Format("Cannot add {0} items. Only {1} items are available in stock.", qty, _selectedMedicine.Stock), "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if item is already in Cart
            var existing = CartForm.Cart.FirstOrDefault(c => c.Medicine.MedicineID == _selectedMedicine.MedicineID);
            if (existing != null)
            {
                int totalQty = existing.Quantity + qty;
                if (totalQty > _selectedMedicine.Stock)
                {
                    MessageBox.Show(string.Format("Your cart already has {0} items. Adding {1} more would exceed stock limit of {2}.", existing.Quantity, qty, _selectedMedicine.Stock), "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existing.Quantity = totalQty;
            }
            else
            {
                CartForm.Cart.Add(new CartItem
                {
                    Medicine = _selectedMedicine,
                    Quantity = qty
                });
            }

            MessageBox.Show(string.Format("{0} (x{1}) added to cart!", _selectedMedicine.MedicineName, qty), "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FetchAllMedicines(); // Refresh stock totals visually
        }
    }
}
