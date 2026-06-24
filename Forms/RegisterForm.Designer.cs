using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private LinkLabel lblLoginLink;
        private Label lblHasAccount;

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
            this.lblTitle = new Label();
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.btnRegister = new Button();
            this.lblLoginLink = new LinkLabel();
            this.lblHasAccount = new Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTitle.ForeColor = Color.FromArgb(0, 128, 128); // Primary Teal
            this.lblTitle.Location = new Point(35, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(247, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Customer Register";

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblFullName.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblFullName.Location = new Point(40, 75);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new Size(130, 17);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Full Name (Required)";

            // txtFullName
            this.txtFullName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtFullName.Location = new Point(40, 95);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new Size(200, 25);
            this.txtFullName.TabIndex = 2;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblEmail.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblEmail.Location = new Point(260, 75);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(102, 17);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email (Required)";

            // txtEmail
            this.txtEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtEmail.Location = new Point(260, 95);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 25);
            this.txtEmail.TabIndex = 4;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblPhone.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblPhone.Location = new Point(40, 135);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(47, 17);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone";

            // txtPhone
            this.txtPhone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPhone.Location = new Point(40, 155);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new Size(200, 25);
            this.txtPhone.TabIndex = 6;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblAddress.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblAddress.Location = new Point(260, 135);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new Size(57, 17);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Address";

            // txtAddress
            this.txtAddress.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtAddress.Location = new Point(260, 155);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new Size(200, 25);
            this.txtAddress.TabIndex = 8;

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblUsername.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblUsername.Location = new Point(40, 205);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(131, 17);
            this.lblUsername.TabIndex = 9;
            this.lblUsername.Text = "Username (Required)";

            // txtUsername
            this.txtUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtUsername.Location = new Point(40, 225);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(420, 25);
            this.txtUsername.TabIndex = 10;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblPassword.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblPassword.Location = new Point(40, 265);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(128, 17);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password (Required)";

            // txtPassword
            this.txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPassword.Location = new Point(40, 285);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new Size(200, 25);
            this.txtPassword.TabIndex = 12;

            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblConfirmPassword.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblConfirmPassword.Location = new Point(260, 265);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(179, 17);
            this.lblConfirmPassword.TabIndex = 13;
            this.lblConfirmPassword.Text = "Confirm Password (Required)";

            // txtConfirmPassword
            this.txtConfirmPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtConfirmPassword.Location = new Point(260, 285);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new Size(200, 25);
            this.txtConfirmPassword.TabIndex = 14;

            // btnRegister
            this.btnRegister.BackColor = Color.FromArgb(0, 128, 128); // Teal
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.Location = new Point(40, 345);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new Size(420, 42);
            this.btnRegister.TabIndex = 15;
            this.btnRegister.Text = "Register Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // lblHasAccount
            this.lblHasAccount.AutoSize = true;
            this.lblHasAccount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblHasAccount.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblHasAccount.Location = new Point(140, 415);
            this.lblHasAccount.Name = "lblHasAccount";
            this.lblHasAccount.Size = new Size(159, 17);
            this.lblHasAccount.TabIndex = 16;
            this.lblHasAccount.Text = "Already have an account? ";

            // lblLoginLink
            this.lblLoginLink.AutoSize = true;
            this.lblLoginLink.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblLoginLink.LinkColor = Color.FromArgb(0, 128, 128);
            this.lblLoginLink.Location = new Point(298, 415);
            this.lblLoginLink.Name = "lblLoginLink";
            this.lblLoginLink.Size = new Size(46, 17);
            this.lblLoginLink.TabIndex = 17;
            this.lblLoginLink.TabStop = true;
            this.lblLoginLink.Text = "Log In";
            this.lblLoginLink.Click += new System.EventHandler(this.lblLoginLink_Click);

            // RegisterForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 470);
            this.Controls.Add(this.lblLoginLink);
            this.Controls.Add(this.lblHasAccount);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SmartMed Pharmacy - Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
