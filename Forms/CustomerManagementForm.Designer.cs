using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class CustomerManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlInput;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnUpdate;
        private Button btnClear;
        
        private Panel pnlGridContainer;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvCustomers;

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
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnUpdate = new Button();
            this.btnClear = new Button();
            
            this.pnlGridContainer = new Panel();
            this.dgvCustomers = new DataGridView();
            this.pnlSearch = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();

            this.pnlInput.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();

            // pnlInput (Left Side Panel)
            this.pnlInput.BackColor = Color.White;
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Controls.Add(this.btnUpdate);
            this.pnlInput.Controls.Add(this.txtPassword);
            this.pnlInput.Controls.Add(this.lblPassword);
            this.pnlInput.Controls.Add(this.txtAddress);
            this.pnlInput.Controls.Add(this.lblAddress);
            this.pnlInput.Controls.Add(this.txtPhone);
            this.pnlInput.Controls.Add(this.lblPhone);
            this.pnlInput.Controls.Add(this.txtEmail);
            this.pnlInput.Controls.Add(this.lblEmail);
            this.pnlInput.Controls.Add(this.txtFullName);
            this.pnlInput.Controls.Add(this.lblFullName);
            this.pnlInput.Dock = DockStyle.Left;
            this.pnlInput.Location = new Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new Size(260, 480);
            this.pnlInput.TabIndex = 0;

            int lblX = 15;
            int txtX = 15;
            int inputWidth = 225;
            int curY = 20;
            int rowHeight = 55;

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblFullName.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblFullName.Location = new Point(lblX, curY);
            this.lblFullName.Text = "Full Name";

            curY += 18;
            // txtFullName
            this.txtFullName.Font = new Font("Segoe UI", 9.5F);
            this.txtFullName.Location = new Point(txtX, curY);
            this.txtFullName.Size = new Size(inputWidth, 23);

            curY += rowHeight - 18;
            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblEmail.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblEmail.Location = new Point(lblX, curY);
            this.lblEmail.Text = "Email Address";

            curY += 18;
            // txtEmail
            this.txtEmail.Font = new Font("Segoe UI", 9.5F);
            this.txtEmail.Location = new Point(txtX, curY);
            this.txtEmail.Size = new Size(inputWidth, 23);

            curY += rowHeight - 18;
            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblPhone.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblPhone.Location = new Point(lblX, curY);
            this.lblPhone.Text = "Phone Number";

            curY += 18;
            // txtPhone
            this.txtPhone.Font = new Font("Segoe UI", 9.5F);
            this.txtPhone.Location = new Point(txtX, curY);
            this.txtPhone.Size = new Size(inputWidth, 23);

            curY += rowHeight - 18;
            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblAddress.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblAddress.Location = new Point(lblX, curY);
            this.lblAddress.Text = "Address";

            curY += 18;
            // txtAddress
            this.txtAddress.Font = new Font("Segoe UI", 9.5F);
            this.txtAddress.Location = new Point(txtX, curY);
            this.txtAddress.Size = new Size(inputWidth, 23);

            curY += rowHeight - 18;
            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblPassword.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblPassword.Location = new Point(lblX, curY);
            this.lblPassword.Text = "Account Password";

            curY += 18;
            // txtPassword
            this.txtPassword.Font = new Font("Segoe UI", 9.5F);
            this.txtPassword.Location = new Point(txtX, curY);
            this.txtPassword.Size = new Size(inputWidth, 23);

            curY += 40;
            // btnUpdate
            this.btnUpdate.BackColor = Color.FromArgb(0, 128, 128); // Teal
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.Location = new Point(15, curY);
            this.btnUpdate.Size = new Size(105, 33);
            this.btnUpdate.Text = "Update Profile";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnClear
            this.btnClear.BackColor = Color.FromArgb(127, 140, 141);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(135, curY);
            this.btnClear.Size = new Size(105, 33);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // pnlGridContainer
            this.pnlGridContainer.Controls.Add(this.dgvCustomers);
            this.pnlGridContainer.Controls.Add(this.pnlSearch);
            this.pnlGridContainer.Dock = DockStyle.Fill;
            this.pnlGridContainer.Location = new Point(260, 0);
            this.pnlGridContainer.Size = new Size(540, 480);

            // pnlSearch (Top panel on right side)
            this.pnlSearch.BackColor = Color.FromArgb(240, 244, 248);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Location = new Point(0, 0);
            this.pnlSearch.Size = new Size(540, 60);
            this.pnlSearch.TabIndex = 0;

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblSearch.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblSearch.Location = new Point(15, 23);
            this.lblSearch.Text = "Search Keyword";

            // txtSearch
            this.txtSearch.Font = new Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new Point(125, 20);
            this.txtSearch.Size = new Size(240, 23);

            // btnSearch
            this.btnSearch.BackColor = Color.FromArgb(0, 128, 128);
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new Point(380, 18);
            this.btnSearch.Size = new Size(80, 26);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // dgvCustomers
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.BackgroundColor = Color.White;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = DockStyle.Fill;
            this.dgvCustomers.Location = new Point(0, 60);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new Size(540, 420);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

            // CustomerManagementForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ClientSize = new Size(800, 480);
            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.pnlInput);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomerManagementForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SmartMed Pharmacy - Customer Directory";
            this.Load += new System.EventHandler(this.CustomerManagementForm_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
