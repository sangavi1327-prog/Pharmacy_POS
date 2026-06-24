using System;
using System.Data;
using System.Windows.Forms;
using SmartMedPharmacy.Services;

namespace SmartMedPharmacy.Forms
{
    public partial class OrderManagementForm : Form
    {
        private int _selectedOrderId = -1;

        public OrderManagementForm()
        {
            InitializeComponent();
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Ready For Pickup");
            cmbStatus.Items.Add("Delivered");
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadOrders()
        {
            try
            {
                DataTable dt = OrderService.GetAllOrders();
                dgvOrders.DataSource = dt;
                ClearDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load orders: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDetails()
        {
            dgvOrderItems.DataSource = null;
            lblTotalVal.Text = "$0.00";
            _selectedOrderId = -1;
            btnUpdateStatus.Enabled = false;
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
                _selectedOrderId = Convert.ToInt32(row.Cells["OrderID"].Value);
                string currentStatus = row.Cells["Status"].Value.ToString();

                if (cmbStatus.Items.Contains(currentStatus))
                {
                    cmbStatus.SelectedItem = currentStatus;
                }

                btnUpdateStatus.Enabled = true;
                LoadOrderDetails(_selectedOrderId, Convert.ToDecimal(row.Cells["TotalAmount"].Value));
            }
        }

        private void LoadOrderDetails(int orderId, decimal totalAmount)
        {
            try
            {
                DataTable dtItems = OrderService.GetOrderDetails(orderId);
                dgvOrderItems.DataSource = dtItems;
                lblTotalVal.Text = $"${totalAmount:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load order details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId == -1) return;
            string selectedStatus = cmbStatus.SelectedItem.ToString();

            try
            {
                if (OrderService.UpdateOrderStatus(_selectedOrderId, selectedStatus))
                {
                    MessageBox.Show("Order status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                }
                else
                {
                    MessageBox.Show("Failed to update order status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
