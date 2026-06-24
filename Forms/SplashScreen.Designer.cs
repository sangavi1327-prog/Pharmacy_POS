using System.Drawing;
using System.Windows.Forms;

namespace SmartMedPharmacy.Forms
{
    partial class SplashScreen
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblSubtitle;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Panel headerPanel;

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
            this.lblSubtitle = new Label();
            this.progressBar = new ProgressBar();
            this.lblStatus = new Label();
            this.headerPanel = new Panel();
            
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();

            // headerPanel
            this.headerPanel.BackColor = Color.FromArgb(0, 128, 128); // Primary Teal
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Location = new Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new Size(550, 100);
            this.headerPanel.TabIndex = 0;

            // lblTitle
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(550, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SmartMed Pharmacy";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSubtitle.ForeColor = Color.FromArgb(170, 190, 200);
            this.lblSubtitle.Location = new Point(0, 120);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(550, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Advanced Pharmacy Management System";
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // progressBar
            this.progressBar.Location = new Point(40, 200);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(470, 18);
            this.progressBar.TabIndex = 2;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.lblStatus.ForeColor = Color.FromArgb(130, 150, 160);
            this.lblStatus.Location = new Point(40, 230);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(130, 15);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Initializing modules...";

            // SplashScreen
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(24, 33, 43); // Dark Slate background
            this.ClientSize = new Size(550, 300);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SmartMed Pharmacy";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
