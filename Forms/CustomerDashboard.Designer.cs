using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class CustomerDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel leftPanel;
        private Panel topPanel;
        private Label lblHeader;
        private Label lblWelcome;
        private Label lblEmail;
        private Button btnSearchMedicines;
        private Button btnCart;
        private Button btnTrackOrders;
        private Button btnUploadPrescription;
        private Button btnProfile;
        private Button btnLogout;
        
        // Promotion panel
        private Panel pnlPromo;
        private Label lblPromoTitle;
        private Label lblPromoText;
        private Panel pnlAdvice;
        private Label lblAdviceTitle;
        private Label lblAdviceText;

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
            this.leftPanel = new Panel();
            this.lblWelcome = new Label();
            this.lblEmail = new Label();
            this.btnSearchMedicines = new Button();
            this.btnCart = new Button();
            this.btnTrackOrders = new Button();
            this.btnUploadPrescription = new Button();
            this.btnProfile = new Button();
            this.btnLogout = new Button();
            this.topPanel = new Panel();
            this.lblHeader = new Label();
            this.pnlPromo = new Panel();
            this.lblPromoTitle = new Label();
            this.lblPromoText = new Label();
            this.pnlAdvice = new Panel();
            this.lblAdviceTitle = new Label();
            this.lblAdviceText = new Label();
            
            this.leftPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.pnlPromo.SuspendLayout();
            this.pnlAdvice.SuspendLayout();
            this.SuspendLayout();

            // leftPanel
            this.leftPanel.BackColor = Color.FromArgb(31, 40, 51); // Dark Gray
            this.leftPanel.Controls.Add(this.lblWelcome);
            this.leftPanel.Controls.Add(this.lblEmail);
            this.leftPanel.Controls.Add(this.btnSearchMedicines);
            this.leftPanel.Controls.Add(this.btnCart);
            this.leftPanel.Controls.Add(this.btnTrackOrders);
            this.leftPanel.Controls.Add(this.btnUploadPrescription);
            this.leftPanel.Controls.Add(this.btnProfile);
            this.leftPanel.Controls.Add(this.btnLogout);
            this.leftPanel.Dock = DockStyle.Left;
            this.leftPanel.Location = new Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new Size(220, 500);
            this.leftPanel.TabIndex = 0;

            // lblWelcome
            this.lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(10, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(200, 30);
            this.lblWelcome.Text = "Welcome, Customer";
            this.lblWelcome.TextAlign = ContentAlignment.MiddleLeft;

            // lblEmail
            this.lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblEmail.ForeColor = Color.FromArgb(170, 185, 200);
            this.lblEmail.Location = new Point(10, 45);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(200, 20);
            this.lblEmail.Text = "email@example.com";

            int btnY = 90;
            int btnHeight = 45;
            int btnSpacing = 12;

            // btnSearchMedicines
            this.btnSearchMedicines.BackColor = Color.FromArgb(41, 53, 65);
            this.btnSearchMedicines.FlatStyle = FlatStyle.Flat;
            this.btnSearchMedicines.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.btnSearchMedicines.ForeColor = Color.White;
            this.btnSearchMedicines.Location = new Point(10, btnY);
            this.btnSearchMedicines.Name = "btnSearchMedicines";
            this.btnSearchMedicines.Size = new Size(200, btnHeight);
            this.btnSearchMedicines.Text = "🔍 Search Medicines";
            this.btnSearchMedicines.UseVisualStyleBackColor = false;
            this.btnSearchMedicines.Click += new System.EventHandler(this.btnSearchMedicines_Click);

            btnY += btnHeight + btnSpacing;
            // btnCart
            this.btnCart.BackColor = Color.FromArgb(41, 53, 65);
            this.btnCart.FlatStyle = FlatStyle.Flat;
            this.btnCart.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.btnCart.ForeColor = Color.White;
            this.btnCart.Location = new Point(10, btnY);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new Size(200, btnHeight);
            this.btnCart.Text = "🛒 Shopping Cart";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);

            btnY += btnHeight + btnSpacing;
            // btnTrackOrders
            this.btnTrackOrders.BackColor = Color.FromArgb(41, 53, 65);
            this.btnTrackOrders.FlatStyle = FlatStyle.Flat;
            this.btnTrackOrders.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.btnTrackOrders.ForeColor = Color.White;
            this.btnTrackOrders.Location = new Point(10, btnY);
            this.btnTrackOrders.Name = "btnTrackOrders";
            this.btnTrackOrders.Size = new Size(200, btnHeight);
            this.btnTrackOrders.Text = "📦 Track Orders";
            this.btnTrackOrders.UseVisualStyleBackColor = false;
            this.btnTrackOrders.Click += new System.EventHandler(this.btnTrackOrders_Click);

            btnY += btnHeight + btnSpacing;
            // btnUploadPrescription
            this.btnUploadPrescription.BackColor = Color.FromArgb(41, 53, 65);
            this.btnUploadPrescription.FlatStyle = FlatStyle.Flat;
            this.btnUploadPrescription.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.btnUploadPrescription.ForeColor = Color.White;
            this.btnUploadPrescription.Location = new Point(10, btnY);
            this.btnUploadPrescription.Name = "btnUploadPrescription";
            this.btnUploadPrescription.Size = new Size(200, btnHeight);
            this.btnUploadPrescription.Text = "📄 Upload Prescription";
            this.btnUploadPrescription.UseVisualStyleBackColor = false;
            this.btnUploadPrescription.Click += new System.EventHandler(this.btnUploadPrescription_Click);

            btnY += btnHeight + btnSpacing;
            // btnProfile
            this.btnProfile.BackColor = Color.FromArgb(41, 53, 65);
            this.btnProfile.FlatStyle = FlatStyle.Flat;
            this.btnProfile.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.btnProfile.ForeColor = Color.White;
            this.btnProfile.Location = new Point(10, btnY);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new Size(200, btnHeight);
            this.btnProfile.Text = "👤 Manage Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // btnLogout
            this.btnLogout.BackColor = Color.FromArgb(235, 104, 76);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(10, 440);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(200, 40);
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // topPanel
            this.topPanel.BackColor = Color.FromArgb(0, 128, 128); // Teal
            this.topPanel.Controls.Add(this.lblHeader);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new Point(220, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new Size(630, 60);
            this.topPanel.TabIndex = 1;

            // lblHeader
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.White;
            this.lblHeader.Location = new Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new Size(330, 30);
            this.lblHeader.Text = "SmartMed Pharmacy Patient Portal";

            // pnlPromo
            this.pnlPromo.BackColor = Color.White;
            this.pnlPromo.BorderStyle = BorderStyle.FixedSingle;
            this.pnlPromo.Controls.Add(this.lblPromoTitle);
            this.pnlPromo.Controls.Add(this.lblPromoText);
            this.pnlPromo.Location = new Point(250, 90);
            this.pnlPromo.Name = "pnlPromo";
            this.pnlPromo.Size = new Size(560, 150);
            this.pnlPromo.TabIndex = 2;

            // lblPromoTitle
            this.lblPromoTitle.AutoSize = true;
            this.lblPromoTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            this.lblPromoTitle.ForeColor = Color.FromArgb(0, 128, 128);
            this.lblPromoTitle.Location = new Point(15, 15);
            this.lblPromoTitle.Text = "🌟 Health & Savings Discount Scheme";

            // lblPromoText
            this.lblPromoText.Font = new Font("Segoe UI", 10F);
            this.lblPromoText.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblPromoText.Location = new Point(15, 50);
            this.lblPromoText.Size = new Size(520, 80);
            this.lblPromoText.Text = "We are pleased to introduce our automatic discount program! Medicines marked with a discount percentage will calculate prices on checkout automatically. Make sure to upload your active physician prescriptions to ensure fast checkout approvals.";

            // pnlAdvice
            this.pnlAdvice.BackColor = Color.White;
            this.pnlAdvice.BorderStyle = BorderStyle.FixedSingle;
            this.pnlAdvice.Controls.Add(this.lblAdviceTitle);
            this.pnlAdvice.Controls.Add(this.lblAdviceText);
            this.pnlAdvice.Location = new Point(250, 265);
            this.pnlAdvice.Name = "pnlAdvice";
            this.pnlAdvice.Size = new Size(560, 150);
            this.pnlAdvice.TabIndex = 3;

            // lblAdviceTitle
            this.lblAdviceTitle.AutoSize = true;
            this.lblAdviceTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            this.lblAdviceTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblAdviceTitle.Location = new Point(15, 15);
            this.lblAdviceTitle.Text = "🩺 Health Advisory Notification";

            // lblAdviceText
            this.lblAdviceText.Font = new Font("Segoe UI", 10F);
            this.lblAdviceText.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblAdviceText.Location = new Point(15, 50);
            this.lblAdviceText.Size = new Size(520, 80);
            this.lblAdviceText.Text = "Please double-check dosage specifications when uploading prescriptions. Our licensed pharmacist will review prescription uploads prior to medicine pickup dispatch. Keep your demographic profile up to date for urgent contact details.";

            // CustomerDashboard
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.ClientSize = new Size(850, 500);
            this.Controls.Add(this.pnlAdvice);
            this.Controls.Add(this.pnlPromo);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomerDashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SmartMed Pharmacy - Customer Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerDashboard_FormClosed);
            this.Load += new System.EventHandler(this.CustomerDashboard_Load);
            this.leftPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.pnlPromo.ResumeLayout(false);
            this.pnlPromo.PerformLayout();
            this.pnlAdvice.ResumeLayout(false);
            this.pnlAdvice.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
