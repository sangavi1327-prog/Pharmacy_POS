using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class OrderManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvOrders;
        private Panel pnlDetails;
        private Label lblItemsTitle;
        private DataGridView dgvOrderItems;
        private Label lblTotal;
        private Label lblTotalVal;
        private Label lblStatusHeader;
        private ComboBox cmbStatus;
        private Button btnUpdateStatus;
        private Label lblHeaderOrders;

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
            this.dgvOrders = new DataGridView();
            this.pnlDetails = new Panel();
            this.lblItemsTitle = new Label();
            this.dgvOrderItems = new DataGridView();
            this.lblTotal = new Label();
            this.lblTotalVal = new Label();
            this.lblStatusHeader = new Label();
            this.cmbStatus = new ComboBox();
            this.btnUpdateStatus = new Button();
            this.lblHeaderOrders = new Label();

            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();

            // lblHeaderOrders
            this.lblHeaderOrders.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblHeaderOrders.ForeColor = Color.FromArgb(0, 128, 128);
            this.lblHeaderOrders.Location = new Point(12, 10);
            this.lblHeaderOrders.Name = "lblHeaderOrders";
            this.lblHeaderOrders.Size = new Size(200, 25);
            this.lblHeaderOrders.Text = "All Customer Orders";

            // dgvOrders
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = Color.White;
            this.dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new Point(12, 40);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new Size(480, 450);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);

            // pnlDetails
            this.pnlDetails.BackColor = Color.White;
            this.pnlDetails.Controls.Add(this.btnUpdateStatus);
            this.pnlDetails.Controls.Add(this.cmbStatus);
            this.pnlDetails.Controls.Add(this.lblStatusHeader);
            this.pnlDetails.Controls.Add(this.lblTotalVal);
            this.pnlDetails.Controls.Add(this.lblTotal);
            this.pnlDetails.Controls.Add(this.dgvOrderItems);
            this.pnlDetails.Controls.Add(this.lblItemsTitle);
            this.pnlDetails.Location = new Point(510, 40);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new Size(420, 450);
            this.pnlDetails.TabIndex = 1;

            // lblItemsTitle
            this.lblItemsTitle.AutoSize = true;
            this.lblItemsTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblItemsTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblItemsTitle.Location = new Point(15, 15);
            this.lblItemsTitle.Text = "Order Items Details";

            // dgvOrderItems
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.BackgroundColor = Color.FromArgb(240, 244, 248);
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new Point(15, 40);
            this.dgvOrderItems.MultiSelect = false;
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.Size = new Size(390, 200);
            this.dgvOrderItems.TabIndex = 1;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblTotal.Location = new Point(15, 260);
            this.lblTotal.Text = "Total Amount:";

            // lblTotalVal
            this.lblTotalVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotalVal.ForeColor = Color.FromArgb(0, 128, 128);
            this.lblTotalVal.Location = new Point(130, 258);
            this.lblTotalVal.Size = new Size(200, 25);
            this.lblTotalVal.Text = "$0.00";

            // lblStatusHeader
            this.lblStatusHeader.AutoSize = true;
            this.lblStatusHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblStatusHeader.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblStatusHeader.Location = new Point(15, 310);
            this.lblStatusHeader.Text = "Update Status";

            // cmbStatus
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.Location = new Point(15, 335);
            this.cmbStatus.Size = new Size(240, 25);
            this.cmbStatus.TabIndex = 2;

            // btnUpdateStatus
            this.btnUpdateStatus.BackColor = Color.FromArgb(0, 128, 128);
            this.btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            this.btnUpdateStatus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = Color.White;
            this.btnUpdateStatus.Location = new Point(15, 380);
            this.btnUpdateStatus.Size = new Size(240, 35);
            this.btnUpdateStatus.TabIndex = 3;
            this.btnUpdateStatus.Text = "Save Order Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // OrderManagementForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ClientSize = new Size(950, 510);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.lblHeaderOrders);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OrderManagementForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SmartMed Pharmacy - Order Dispatch Center";
            this.Load += new System.EventHandler(this.OrderManagementForm_Load);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
