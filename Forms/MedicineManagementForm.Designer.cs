using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class MedicineManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlInput;
        private Label lblMedicineName;
        private TextBox txtMedicineName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblDosage;
        private TextBox txtDosage;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblSupplier;
        private TextBox txtSupplier;
        private Label lblExpiryDate;
        private DateTimePicker dtpExpiryDate;
        private Label lblDiscount;
        private TextBox txtDiscount;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        
        private Panel pnlGridContainer;
        private Panel pnlSearchFilter;
        private Label lblSearch;
        private TextBox txtSearchKeyword;
        private Button btnSearch;
        private ComboBox cmbFilterCategory;
        private CheckBox chkLowStock;
        private CheckBox chkExpiringSoon;
        private Button btnFilter;
        private DataGridView dgvMedicines;

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
            this.pnlInput = new Panel();
            this.lblMedicineName = new Label();
            this.txtMedicineName = new TextBox();
            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();
            this.lblDosage = new Label();
            this.txtDosage = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblStock = new Label();
            this.txtStock = new TextBox();
            this.lblSupplier = new Label();
            this.txtSupplier = new TextBox();
            this.lblExpiryDate = new Label();
            this.dtpExpiryDate = new DateTimePicker();
            this.lblDiscount = new Label();
            this.txtDiscount = new TextBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            
            this.pnlGridContainer = new Panel();
            this.dgvMedicines = new DataGridView();
            this.pnlSearchFilter = new Panel();
            this.lblSearch = new Label();
            this.txtSearchKeyword = new TextBox();
            this.btnSearch = new Button();
            this.cmbFilterCategory = new ComboBox();
            this.chkLowStock = new CheckBox();
            this.chkExpiringSoon = new CheckBox();
            this.btnFilter = new Button();

            this.pnlInput.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.pnlSearchFilter.SuspendLayout();
            this.SuspendLayout();

            // pnlInput (Left Side Panel)
            this.pnlInput.BackColor = Color.White;
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Controls.Add(this.btnDelete);
            this.pnlInput.Controls.Add(this.btnUpdate);
            this.pnlInput.Controls.Add(this.btnAdd);
            this.pnlInput.Controls.Add(this.txtDiscount);
            this.pnlInput.Controls.Add(this.lblDiscount);
            this.pnlInput.Controls.Add(this.dtpExpiryDate);
            this.pnlInput.Controls.Add(this.lblExpiryDate);
            this.pnlInput.Controls.Add(this.txtSupplier);
            this.pnlInput.Controls.Add(this.lblSupplier);
            this.pnlInput.Controls.Add(this.txtStock);
            this.pnlInput.Controls.Add(this.lblStock);
            this.pnlInput.Controls.Add(this.txtPrice);
            this.pnlInput.Controls.Add(this.lblPrice);
            this.pnlInput.Controls.Add(this.txtDosage);
            this.pnlInput.Controls.Add(this.lblDosage);
            this.pnlInput.Controls.Add(this.cmbCategory);
            this.pnlInput.Controls.Add(this.lblCategory);
            this.pnlInput.Controls.Add(this.txtMedicineName);
            this.pnlInput.Controls.Add(this.lblMedicineName);
            this.pnlInput.Dock = DockStyle.Left;
            this.pnlInput.Location = new Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new Size(280, 560);
            this.pnlInput.TabIndex = 0;

            int lblX = 15;
            int txtX = 15;
            int inputWidth = 245;
            int curY = 15;
            int rowHeight = 45;

            // lblMedicineName
            this.lblMedicineName.AutoSize = true;
            this.lblMedicineName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblMedicineName.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblMedicineName.Location = new Point(lblX, curY);
            this.lblMedicineName.Text = "Medicine Name";

            curY += 15;
            // txtMedicineName
            this.txtMedicineName.Font = new Font("Segoe UI", 9.5F);
            this.txtMedicineName.Location = new Point(txtX, curY);
            this.txtMedicineName.Size = new Size(inputWidth, 23);

            curY += rowHeight - 15;
            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblCategory.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblCategory.Location = new Point(lblX, curY);
            this.lblCategory.Text = "Category";

            curY += 15;
            // cmbCategory
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new Font("Segoe UI", 9.5F);
            this.cmbCategory.Location = new Point(txtX, curY);
            this.cmbCategory.Size = new Size(inputWidth, 23);

            curY += rowHeight - 15;
            // lblDosage
            this.lblDosage.AutoSize = true;
            this.lblDosage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblDosage.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblDosage.Location = new Point(lblX, curY);
            this.lblDosage.Text = "Dosage";

            curY += 15;
            // txtDosage
            this.txtDosage.Font = new Font("Segoe UI", 9.5F);
            this.txtDosage.Location = new Point(txtX, curY);
            this.txtDosage.Size = new Size(inputWidth, 23);

            curY += rowHeight - 15;
            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblPrice.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblPrice.Location = new Point(lblX, curY);
            this.lblPrice.Text = "Price ($)";

            curY += 15;
            // txtPrice
            this.txtPrice.Font = new Font("Segoe UI", 9.5F);
            this.txtPrice.Location = new Point(txtX, curY);
            this.txtPrice.Size = new Size(inputWidth, 23);

            curY += rowHeight - 15;
            // lblStock
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblStock.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblStock.Location = new Point(lblX, curY);
            this.lblStock.Text = "Stock Quantity";

            curY += 15;
            // txtStock
            this.txtStock.Font = new Font("Segoe UI", 9.5F);
            this.txtStock.Location = new Point(txtX, curY);
            this.txtStock.Size = new Size(inputWidth, 23);

            curY += rowHeight - 15;
            // lblSupplier
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblSupplier.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSupplier.Location = new Point(lblX, curY);
            this.lblSupplier.Text = "Supplier";

            curY += 15;
            // txtSupplier
            this.txtSupplier.Font = new Font("Segoe UI", 9.5F);
            this.txtSupplier.Location = new Point(txtX, curY);
            this.txtSupplier.Size = new Size(inputWidth, 23);

            curY += rowHeight - 15;
            // lblExpiryDate
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblExpiryDate.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblExpiryDate.Location = new Point(lblX, curY);
            this.lblExpiryDate.Text = "Expiry Date";

            curY += 15;
            // dtpExpiryDate
            this.dtpExpiryDate.Font = new Font("Segoe UI", 9.5F);
            this.dtpExpiryDate.Format = DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new Point(txtX, curY);
            this.dtpExpiryDate.Size = new Size(inputWidth, 23);

            curY += rowHeight - 15;
            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblDiscount.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblDiscount.Location = new Point(lblX, curY);
            this.lblDiscount.Text = "Discount (%)";

            curY += 15;
            // txtDiscount
            this.txtDiscount.Font = new Font("Segoe UI", 9.5F);
            this.txtDiscount.Location = new Point(txtX, curY);
            this.txtDiscount.Size = new Size(inputWidth, 23);

            curY += 40;
            // Action Buttons
            this.btnAdd.BackColor = Color.FromArgb(0, 128, 128); // Teal
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(15, curY);
            this.btnAdd.Size = new Size(115, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor = Color.FromArgb(31, 40, 51);
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.Location = new Point(145, curY);
            this.btnUpdate.Size = new Size(115, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            curY += 36;
            this.btnDelete.BackColor = Color.FromArgb(235, 104, 76);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(15, curY);
            this.btnDelete.Size = new Size(115, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.BackColor = Color.FromArgb(127, 140, 141);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(145, curY);
            this.btnClear.Size = new Size(115, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // pnlGridContainer
            this.pnlGridContainer.Controls.Add(this.dgvMedicines);
            this.pnlGridContainer.Controls.Add(this.pnlSearchFilter);
            this.pnlGridContainer.Dock = DockStyle.Fill;
            this.pnlGridContainer.Location = new Point(280, 0);
            this.pnlGridContainer.Size = new Size(720, 560);

            // pnlSearchFilter (Top panel on right side)
            this.pnlSearchFilter.BackColor = Color.FromArgb(240, 244, 248);
            this.pnlSearchFilter.Controls.Add(this.btnFilter);
            this.pnlSearchFilter.Controls.Add(this.chkExpiringSoon);
            this.pnlSearchFilter.Controls.Add(this.chkLowStock);
            this.pnlSearchFilter.Controls.Add(this.cmbFilterCategory);
            this.pnlSearchFilter.Controls.Add(this.btnSearch);
            this.pnlSearchFilter.Controls.Add(this.txtSearchKeyword);
            this.pnlSearchFilter.Controls.Add(this.lblSearch);
            this.pnlSearchFilter.Dock = DockStyle.Top;
            this.pnlSearchFilter.Location = new Point(0, 0);
            this.pnlSearchFilter.Size = new Size(720, 85);
            this.pnlSearchFilter.TabIndex = 0;

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblSearch.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblSearch.Location = new Point(15, 18);
            this.lblSearch.Text = "Search Medicine";

            // txtSearchKeyword
            this.txtSearchKeyword.Font = new Font("Segoe UI", 9.5F);
            this.txtSearchKeyword.Location = new Point(115, 15);
            this.txtSearchKeyword.Size = new Size(200, 23);

            // btnSearch
            this.btnSearch.BackColor = Color.FromArgb(0, 128, 128);
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new Point(325, 13);
            this.btnSearch.Size = new Size(80, 26);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // cmbFilterCategory
            this.cmbFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Font = new Font("Segoe UI", 9F);
            this.cmbFilterCategory.Location = new Point(15, 48);
            this.cmbFilterCategory.Size = new Size(130, 23);

            // chkLowStock
            this.chkLowStock.AutoSize = true;
            this.chkLowStock.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.chkLowStock.ForeColor = Color.FromArgb(235, 104, 76);
            this.chkLowStock.Location = new Point(160, 50);
            this.chkLowStock.Text = "Low Stock";

            // chkExpiringSoon
            this.chkExpiringSoon.AutoSize = true;
            this.chkExpiringSoon.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.chkExpiringSoon.ForeColor = Color.FromArgb(44, 62, 80);
            this.chkExpiringSoon.Location = new Point(255, 50);
            this.chkExpiringSoon.Text = "Expiring soon (<30d)";

            // btnFilter
            this.btnFilter.BackColor = Color.FromArgb(31, 40, 51);
            this.btnFilter.FlatStyle = FlatStyle.Flat;
            this.btnFilter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnFilter.ForeColor = Color.White;
            this.btnFilter.Location = new Point(410, 46);
            this.btnFilter.Size = new Size(95, 26);
            this.btnFilter.Text = "Apply Filters";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // dgvMedicines
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.BackgroundColor = Color.White;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Dock = DockStyle.Fill;
            this.dgvMedicines.Location = new Point(0, 85);
            this.dgvMedicines.MultiSelect = false;
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.Size = new Size(720, 475);
            this.dgvMedicines.TabIndex = 1;
            this.dgvMedicines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicines_CellClick);

            // MedicineManagementForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ClientSize = new Size(1000, 560);
            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.pnlInput);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MedicineManagementForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SmartMed Pharmacy - Medicine Inventory Portal";
            this.Load += new System.EventHandler(this.MedicineManagementForm_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.pnlSearchFilter.ResumeLayout(false);
            this.pnlSearchFilter.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
