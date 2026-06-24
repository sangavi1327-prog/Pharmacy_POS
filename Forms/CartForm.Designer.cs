using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCart;
        private Panel pnlBilling;
        private Label lblBillingTitle;
        private Label lblSubTotal;
        private Label lblSubTotalVal;
        private Label lblDiscount;
        private Label lblDiscountVal;
        private Label lblTotal;
        private Label lblTotalVal;
        private Button btnCheckout;
        private GroupBox grpEditQty;
        private NumericUpDown numQuantity;
        private Button btnUpdateQty;
        private Button btnRemove;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCart = new DataGridView();
            this.pnlBilling = new Panel();
            this.lblBillingTitle = new Label();
            this.lblSubTotal = new Label();
            this.lblSubTotalVal = new Label();
            this.lblDiscount = new Label();
            this.lblDiscountVal = new Label();
            this.lblTotal = new Label();
            this.lblTotalVal = new Label();
            this.btnCheckout = new Button();
            this.grpEditQty = new GroupBox();
            this.numQuantity = new NumericUpDown();
            this.btnUpdateQty = new Button();
            this.btnRemove = new Button();

            this.pnlBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.grpEditQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.BackgroundColor = Color.White;
            this.dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new Point(12, 12);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new Size(580, 436);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellClick);

            // pnlBilling
            this.pnlBilling.BackColor = Color.White;
            this.pnlBilling.Controls.Add(this.grpEditQty);
            this.pnlBilling.Controls.Add(this.btnCheckout);
            this.pnlBilling.Controls.Add(this.lblTotalVal);
            this.pnlBilling.Controls.Add(this.lblTotal);
            this.pnlBilling.Controls.Add(this.lblDiscountVal);
            this.pnlBilling.Controls.Add(this.lblDiscount);
            this.pnlBilling.Controls.Add(this.lblSubTotalVal);
            this.pnlBilling.Controls.Add(this.lblSubTotal);
            this.pnlBilling.Controls.Add(this.lblBillingTitle);
            this.pnlBilling.Location = new Point(610, 12);
            this.pnlBilling.Name = "pnlBilling";
            this.pnlBilling.Size = new Size(278, 436);
            this.pnlBilling.TabIndex = 1;

            // lblBillingTitle
            this.lblBillingTitle.AutoSize = true;
            this.lblBillingTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblBillingTitle.ForeColor = Color.FromArgb(0, 128, 128);
            this.lblBillingTitle.Location = new Point(15, 15);
            this.lblBillingTitle.Text = "Order Summary";

            // grpEditQty
            this.grpEditQty.Controls.Add(this.btnRemove);
            this.grpEditQty.Controls.Add(this.btnUpdateQty);
            this.grpEditQty.Controls.Add(this.numQuantity);
            this.grpEditQty.Font = new Font("Segoe UI Semibold", 9F);
            this.grpEditQty.Location = new Point(15, 55);
            this.grpEditQty.Name = "grpEditQty";
            this.grpEditQty.Size = new Size(245, 120);
            this.grpEditQty.TabIndex = 0;
            this.grpEditQty.TabStop = false;
            this.grpEditQty.Text = "Modify Selection";

            // numQuantity
            this.numQuantity.Font = new Font("Segoe UI", 9.5F);
            this.numQuantity.Location = new Point(15, 30);
            this.numQuantity.Size = new Size(100, 23);

            // btnUpdateQty
            this.btnUpdateQty.BackColor = Color.FromArgb(31, 40, 51);
            this.btnUpdateQty.FlatStyle = FlatStyle.Flat;
            this.btnUpdateQty.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            this.btnUpdateQty.ForeColor = Color.White;
            this.btnUpdateQty.Location = new Point(130, 27);
            this.btnUpdateQty.Size = new Size(100, 27);
            this.btnUpdateQty.Text = "Update Qty";
            this.btnUpdateQty.UseVisualStyleBackColor = false;
            this.btnUpdateQty.Click += new System.EventHandler(this.btnUpdateQty_Click);

            // btnRemove
            this.btnRemove.BackColor = Color.FromArgb(235, 104, 76);
            this.btnRemove.FlatStyle = FlatStyle.Flat;
            this.btnRemove.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnRemove.ForeColor = Color.White;
            this.btnRemove.Location = new Point(15, 75);
            this.btnRemove.Size = new Size(215, 30);
            this.btnRemove.Text = "❌ Remove Item";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // lblSubTotal
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new Font("Segoe UI Semibold", 9.5F);
            this.lblSubTotal.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubTotal.Location = new Point(15, 210);
            this.lblSubTotal.Text = "Cart Subtotal:";

            // lblSubTotalVal
            this.lblSubTotalVal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblSubTotalVal.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblSubTotalVal.Location = new Point(130, 208);
            this.lblSubTotalVal.Size = new Size(130, 20);
            this.lblSubTotalVal.Text = "$0.00";
            this.lblSubTotalVal.TextAlign = ContentAlignment.MiddleRight;

            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new Font("Segoe UI Semibold", 9.5F);
            this.lblDiscount.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblDiscount.Location = new Point(15, 245);
            this.lblDiscount.Text = "Discounts Applied:";

            // lblDiscountVal
            this.lblDiscountVal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblDiscountVal.ForeColor = Color.FromArgb(235, 104, 76);
            this.lblDiscountVal.Location = new Point(130, 243);
            this.lblDiscountVal.Size = new Size(130, 20);
            this.lblDiscountVal.Text = "$0.00";
            this.lblDiscountVal.TextAlign = ContentAlignment.MiddleRight;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTotal.Location = new Point(15, 290);
            this.lblTotal.Text = "Net Checkout Total:";

            // lblTotalVal
            this.lblTotalVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotalVal.ForeColor = Color.FromArgb(0, 128, 128);
            this.lblTotalVal.Location = new Point(15, 315);
            this.lblTotalVal.Size = new Size(245, 30);
            this.lblTotalVal.Text = "$0.00";
            this.lblTotalVal.TextAlign = ContentAlignment.MiddleRight;

            // btnCheckout
            this.btnCheckout.BackColor = Color.FromArgb(0, 128, 128); // Teal
            this.btnCheckout.FlatStyle = FlatStyle.Flat;
            this.btnCheckout.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            this.btnCheckout.ForeColor = Color.White;
            this.btnCheckout.Location = new Point(15, 365);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new Size(245, 42);
            this.btnCheckout.Text = "🚀 Complete Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // CartForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ClientSize = new Size(900, 460);
            this.Controls.Add(this.pnlBilling);
            this.Controls.Add(this.dgvCart);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CartForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SmartMed Pharmacy - Shopping Cart Summary";
            this.Load += new System.EventHandler(this.CartForm_Load);
            this.pnlBilling.ResumeLayout(false);
            this.pnlBilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.grpEditQty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
