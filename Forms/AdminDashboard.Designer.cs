using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartMedPharmacy.Forms
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel sidePanel;
        private Panel topPanel;
        private Label lblHeader;
        private Label lblWelcome;
        private Button btnManageMedicines;
        private Button btnManageCustomers;
        private Button btnManageOrders;
        private Button btnReports;
        private Button btnProfile;
        private Button btnLogout;
        
        // Stats Cards
        private Panel pnlSales;
        private Label lblSalesTitle;
        private Label lblSalesVal;
        
        private Panel pnlOrders;
        private Label lblOrdersTitle;
        private Label lblOrdersVal;
        
        private Panel pnlCustomers;
        private Label lblCustomersTitle;
        private Label lblCustomersVal;
        
        private Panel pnlMedicines;
        private Label lblMedicinesTitle;
        private Label lblMedicinesVal;
        
        private Panel pnlLowStock;
        private Label lblLowStockTitle;
        private Label lblLowStockVal;

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
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
            ChartArea chartArea = new ChartArea();
            Legend legend = new Legend();
            this.sidePanel = new Panel();
            this.btnManageMedicines = new Button();
            this.btnManageCustomers = new Button();
            this.btnManageOrders = new Button();
            this.btnReports = new Button();
            this.btnProfile = new Button();
            this.btnLogout = new Button();
            this.topPanel = new Panel();
            this.lblHeader = new Label();
            this.lblWelcome = new Label();
            this.pnlSales = new Panel();
            this.lblSalesTitle = new Label();
            this.lblSalesVal = new Label();
            this.pnlOrders = new Panel();
            this.lblOrdersTitle = new Label();
            this.lblOrdersVal = new Label();
            this.pnlCustomers = new Panel();
            this.lblCustomersTitle = new Label();
            this.lblCustomersVal = new Label();
            this.pnlMedicines = new Panel();
            this.lblMedicinesTitle = new Label();
            this.lblMedicinesVal = new Label();
            this.pnlLowStock = new Panel();
            this.lblLowStockTitle = new Label();
            this.lblLowStockVal = new Label();
            this.chartSales = new Chart();
            
            this.sidePanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.pnlSales.SuspendLayout();
            this.pnlOrders.SuspendLayout();
            this.pnlCustomers.SuspendLayout();
            this.pnlMedicines.SuspendLayout();
            this.pnlLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            this.SuspendLayout();

            // sidePanel
            this.sidePanel.BackColor = Color.FromArgb(31, 40, 51);
            this.sidePanel.Controls.Add(this.btnManageMedicines);
            this.sidePanel.Controls.Add(this.btnManageCustomers);
            this.sidePanel.Controls.Add(this.btnManageOrders);
            this.sidePanel.Controls.Add(this.btnReports);
            this.sidePanel.Controls.Add(this.btnProfile);
            this.sidePanel.Controls.Add(this.btnLogout);
            this.sidePanel.Dock = DockStyle.Left;
            this.sidePanel.Location = new Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new Size(220, 600);
            this.sidePanel.TabIndex = 0;

            // Nav buttons styling helper
            int btnY = 100;
            int btnHeight = 50;
            int btnSpacing = 15;

            // btnManageMedicines
            this.btnManageMedicines.BackColor = Color.FromArgb(41, 53, 65);
            this.btnManageMedicines.FlatStyle = FlatStyle.Flat;
            this.btnManageMedicines.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnManageMedicines.ForeColor = Color.White;
            this.btnManageMedicines.Location = new Point(10, btnY);
            this.btnManageMedicines.Name = "btnManageMedicines";
            this.btnManageMedicines.Size = new Size(200, btnHeight);
            this.btnManageMedicines.TabIndex = 0;
            this.btnManageMedicines.Text = "💊 Manage Medicines";
            this.btnManageMedicines.UseVisualStyleBackColor = false;
            this.btnManageMedicines.Click += new System.EventHandler(this.btnManageMedicines_Click);

            btnY += btnHeight + btnSpacing;
            // btnManageCustomers
            this.btnManageCustomers.BackColor = Color.FromArgb(41, 53, 65);
            this.btnManageCustomers.FlatStyle = FlatStyle.Flat;
            this.btnManageCustomers.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnManageCustomers.ForeColor = Color.White;
            this.btnManageCustomers.Location = new Point(10, btnY);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new Size(200, btnHeight);
            this.btnManageCustomers.TabIndex = 1;
            this.btnManageCustomers.Text = "👥 Manage Customers";
            this.btnManageCustomers.UseVisualStyleBackColor = false;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);

            btnY += btnHeight + btnSpacing;
            // btnManageOrders
            this.btnManageOrders.BackColor = Color.FromArgb(41, 53, 65);
            this.btnManageOrders.FlatStyle = FlatStyle.Flat;
            this.btnManageOrders.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnManageOrders.ForeColor = Color.White;
            this.btnManageOrders.Location = new Point(10, btnY);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.Size = new Size(200, btnHeight);
            this.btnManageOrders.TabIndex = 2;
            this.btnManageOrders.Text = "📦 Manage Orders";
            this.btnManageOrders.UseVisualStyleBackColor = false;
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);

            btnY += btnHeight + btnSpacing;
            // btnReports
            this.btnReports.BackColor = Color.FromArgb(41, 53, 65);
            this.btnReports.FlatStyle = FlatStyle.Flat;
            this.btnReports.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnReports.ForeColor = Color.White;
            this.btnReports.Location = new Point(10, btnY);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new Size(200, btnHeight);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "📊 Generate Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            btnY += btnHeight + btnSpacing;
            // btnProfile
            this.btnProfile.BackColor = Color.FromArgb(41, 53, 65);
            this.btnProfile.FlatStyle = FlatStyle.Flat;
            this.btnProfile.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnProfile.ForeColor = Color.White;
            this.btnProfile.Location = new Point(10, btnY);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new Size(200, btnHeight);
            this.btnProfile.TabIndex = 4;
            this.btnProfile.Text = "👤 Admin Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // btnLogout
            this.btnLogout.BackColor = Color.FromArgb(235, 104, 76);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(10, 530);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(200, 45);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // topPanel
            this.topPanel.BackColor = Color.FromArgb(0, 128, 128); // Teal
            this.topPanel.Controls.Add(this.lblHeader);
            this.topPanel.Controls.Add(this.lblWelcome);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new Point(220, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new Size(730, 60);
            this.topPanel.TabIndex = 1;

            // lblHeader
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.White;
            this.lblHeader.Location = new Point(15, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new Size(330, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "SmartMed Pharmacy Management";

            // lblWelcome
            this.lblWelcome.Anchor = AnchorStyles.Right;
            this.lblWelcome.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(515, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(200, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Administrator";
            this.lblWelcome.TextAlign = ContentAlignment.MiddleRight;

            // Card configuration (Teal details)
            int cardY = 80;
            int cardWidth = 125;
            int cardHeight = 80;
            int cardSpacing = 16;
            int cardX = 240;

            // pnlSales
            this.pnlSales.BackColor = Color.White;
            this.pnlSales.BorderStyle = BorderStyle.FixedSingle;
            this.pnlSales.Controls.Add(this.lblSalesTitle);
            this.pnlSales.Controls.Add(this.lblSalesVal);
            this.pnlSales.Location = new Point(cardX, cardY);
            this.pnlSales.Name = "pnlSales";
            this.pnlSales.Size = new Size(cardWidth + 10, cardHeight);
            this.pnlSales.TabIndex = 2;

            this.lblSalesTitle.AutoSize = true;
            this.lblSalesTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblSalesTitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSalesTitle.Location = new Point(5, 10);
            this.lblSalesTitle.Text = "Total Sales";

            this.lblSalesVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblSalesVal.ForeColor = Color.FromArgb(0, 128, 128);
            this.lblSalesVal.Location = new Point(5, 35);
            this.lblSalesVal.Size = new Size(125, 30);
            this.lblSalesVal.Text = "$0.00";

            cardX += cardWidth + cardSpacing + 10;
            // pnlOrders
            this.pnlOrders.BackColor = Color.White;
            this.pnlOrders.BorderStyle = BorderStyle.FixedSingle;
            this.pnlOrders.Controls.Add(this.lblOrdersTitle);
            this.pnlOrders.Controls.Add(this.lblOrdersVal);
            this.pnlOrders.Location = new Point(cardX, cardY);
            this.pnlOrders.Size = new Size(cardWidth, cardHeight);

            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new Font("Segoe UI", 9F);
            this.lblOrdersTitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblOrdersTitle.Location = new Point(5, 10);
            this.lblOrdersTitle.Text = "Total Orders";

            this.lblOrdersVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblOrdersVal.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblOrdersVal.Location = new Point(5, 35);
            this.lblOrdersVal.Size = new Size(115, 30);
            this.lblOrdersVal.Text = "0";

            cardX += cardWidth + cardSpacing;
            // pnlCustomers
            this.pnlCustomers.BackColor = Color.White;
            this.pnlCustomers.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCustomers.Controls.Add(this.lblCustomersTitle);
            this.pnlCustomers.Controls.Add(this.lblCustomersVal);
            this.pnlCustomers.Location = new Point(cardX, cardY);
            this.pnlCustomers.Size = new Size(cardWidth, cardHeight);

            this.lblCustomersTitle.AutoSize = true;
            this.lblCustomersTitle.Font = new Font("Segoe UI", 9F);
            this.lblCustomersTitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblCustomersTitle.Location = new Point(5, 10);
            this.lblCustomersTitle.Text = "Customers";

            this.lblCustomersVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblCustomersVal.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblCustomersVal.Location = new Point(5, 35);
            this.lblCustomersVal.Size = new Size(115, 30);
            this.lblCustomersVal.Text = "0";

            cardX += cardWidth + cardSpacing;
            // pnlMedicines
            this.pnlMedicines.BackColor = Color.White;
            this.pnlMedicines.BorderStyle = BorderStyle.FixedSingle;
            this.pnlMedicines.Controls.Add(this.lblMedicinesTitle);
            this.pnlMedicines.Controls.Add(this.lblMedicinesVal);
            this.pnlMedicines.Location = new Point(cardX, cardY);
            this.pnlMedicines.Size = new Size(cardWidth, cardHeight);

            this.lblMedicinesTitle.AutoSize = true;
            this.lblMedicinesTitle.Font = new Font("Segoe UI", 9F);
            this.lblMedicinesTitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblMedicinesTitle.Location = new Point(5, 10);
            this.lblMedicinesTitle.Text = "Medicines";

            this.lblMedicinesVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblMedicinesVal.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblMedicinesVal.Location = new Point(5, 35);
            this.lblMedicinesVal.Size = new Size(115, 30);
            this.lblMedicinesVal.Text = "0";

            cardX += cardWidth + cardSpacing;
            // pnlLowStock
            this.pnlLowStock.BackColor = Color.White;
            this.pnlLowStock.BorderStyle = BorderStyle.FixedSingle;
            this.pnlLowStock.Controls.Add(this.lblLowStockTitle);
            this.pnlLowStock.Controls.Add(this.lblLowStockVal);
            this.pnlLowStock.Location = new Point(cardX, cardY);
            this.pnlLowStock.Size = new Size(cardWidth, cardHeight);

            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new Font("Segoe UI", 9F);
            this.lblLowStockTitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblLowStockTitle.Location = new Point(5, 10);
            this.lblLowStockTitle.Text = "Low Stock";

            this.lblLowStockVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblLowStockVal.ForeColor = Color.FromArgb(235, 104, 76);
            this.lblLowStockVal.Location = new Point(5, 35);
            this.lblLowStockVal.Size = new Size(115, 30);
            this.lblLowStockVal.Text = "0";

            // chartSales
            chartArea.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea);
            legend.Name = "Legend1";
            this.chartSales.Legends.Add(legend);
            this.chartSales.Location = new Point(240, 180);
            this.chartSales.Name = "chartSales";
            this.chartSales.Size = new Size(680, 390);
            this.chartSales.TabIndex = 7;
            this.chartSales.Text = "Sales Dynamics Chart";

            // AdminDashboard
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.ClientSize = new Size(950, 600);
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.pnlLowStock);
            this.Controls.Add(this.pnlMedicines);
            this.Controls.Add(this.pnlCustomers);
            this.Controls.Add(this.pnlOrders);
            this.Controls.Add(this.pnlSales);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.Name = "AdminDashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();

          

            // chart settings here...
            this.chartSales.Location = new Point(240, 180);
            this.chartSales.Size = new Size(600, 300);
            this.chartSales.Name = "chartSales";

            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.Controls.Add(this.chartSales);

            this.Text = "SmartMed Pharmacy - Dashboard Portal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDashboard_FormClosed);
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.sidePanel.ResumeLayout(false);
            this.Controls.Add(this.chartSales);
            this.topPanel.PerformLayout();
            this.pnlSales.ResumeLayout(false);
         
            this.pnlSales.PerformLayout();
         
            this.pnlOrders.ResumeLayout(false);
            this.pnlOrders.PerformLayout();
            this.pnlCustomers.ResumeLayout(false);
            this.pnlCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.chartSales);
            this.pnlMedicines.ResumeLayout(false);
            this.pnlMedicines.PerformLayout();
            this.pnlLowStock.ResumeLayout(false);
            this.pnlLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
