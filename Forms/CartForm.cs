using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SmartMedPharmacy.Models;
using SmartMedPharmacy.Services;

namespace SmartMedPharmacy.Forms
{
    public partial class CartForm : Form
    {
        // Global static cart items session storage
        public static List<CartItem> Cart = new List<CartItem>();
        private CartItem _selectedCartItem;

        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicineID", typeof(int));
            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("OriginalPrice", typeof(decimal));
            dt.Columns.Add("Discount", typeof(decimal));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));

            decimal subTotal = 0;
            decimal totalDiscount = 0;
            decimal finalTotal = 0;

            foreach (var item in Cart)
            {
                decimal originalItemTotal = item.Medicine.Price * item.Quantity;
                decimal itemFinalTotal = item.Medicine.FinalPrice * item.Quantity;
                decimal discountAmt = originalItemTotal - itemFinalTotal;

                subTotal += originalItemTotal;
                totalDiscount += discountAmt;
                finalTotal += itemFinalTotal;

                dt.Rows.Add(
                    item.Medicine.MedicineID,
                    item.Medicine.MedicineName,
                    item.Quantity,
                    item.Medicine.Price,
                    item.Medicine.Discount,
                    item.Medicine.FinalPrice,
                    itemFinalTotal
                );
            }

            dgvCart.DataSource = dt;

            lblSubTotalVal.Text = string.Format("${0:N2}", subTotal);
            lblDiscountVal.Text = string.Format("${0:N2}", totalDiscount);
            lblTotalVal.Text = string.Format("${0:N2}", finalTotal);

            _selectedCartItem = null;
            btnUpdateQty.Enabled = false;
            btnRemove.Enabled = false;
            btnCheckout.Enabled = Cart.Count > 0;
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int medId = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["MedicineID"].Value);
                _selectedCartItem = Cart.FirstOrDefault(c => c.Medicine.MedicineID == medId);
                if (_selectedCartItem != null)
                {
                    numQuantity.Maximum = _selectedCartItem.Medicine.Stock + _selectedCartItem.Quantity; // Max possible is stock + what is already added
                    numQuantity.Value = _selectedCartItem.Quantity;
                    btnUpdateQty.Enabled = true;
                    btnRemove.Enabled = true;
                }
            }
        }

        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            if (_selectedCartItem == null) return;
            int newQty = (int)numQuantity.Value;

            if (newQty <= 0)
            {
                btnRemove_Click(sender, e);
                return;
            }

            // Check if stock permits
            if (newQty > _selectedCartItem.Medicine.Stock)
            {
                MessageBox.Show(string.Format("Only {0} items are available in inventory.", _selectedCartItem.Medicine.Stock), "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedCartItem.Quantity = newQty;
            MessageBox.Show("Quantity updated successfully!", "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCartItems();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_selectedCartItem == null) return;

            var confirmResult = MessageBox.Show(string.Format("Remove {0} from cart?", _selectedCartItem.Medicine.MedicineName), "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                Cart.Remove(_selectedCartItem);
                LoadCartItems();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Cart.Count == 0) return;

            Customer currentCust = AuthenticationService.CurrentUser as Customer;
            if (currentCust == null)
            {
                MessageBox.Show("Authentication Session Error. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate final total amount
            decimal totalAmount = Cart.Sum(item => item.Medicine.FinalPrice * item.Quantity);

            var confirmCheckout = MessageBox.Show(string.Format("Are you sure you want to place this order for ${0:N2}?", totalAmount), "Confirm Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmCheckout == DialogResult.Yes)
            {
                try
                {
                    string errMsg;
                    bool success = OrderService.PlaceOrder(currentCust.Id, Cart, totalAmount, out errMsg);
                    if (success)
                    {
                        MessageBox.Show("Order placed successfully! You can track your order status in the dashboard.", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cart.Clear();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Order checkout failed:\n\n{0}", errMsg), "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("An error occurred during checkout:\n\n{0}", ex.Message), "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
