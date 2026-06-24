using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SmartMedPharmacy.Services;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                this.Load += AdminDashboard_Load;
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadStats();
            LoadSalesChart();
        }

        private void LoadStats()
        {
            if (DesignMode||lblSalesVal==null) return;  
            

             try
            {
                DataTable stats = ReportService.GetDashboardStats();
                if (stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];
                    lblSalesVal.Text = $"${Convert.ToDecimal(row["TotalSales"]):N2}";
                    lblOrdersVal.Text = row["TotalOrders"].ToString();
                    lblCustomersVal.Text = row["TotalCustomers"].ToString();
                    lblMedicinesVal.Text = row["TotalMedicines"].ToString();
                    lblLowStockVal.Text = row["LowStockCount"].ToString();

                    int lowStock = Convert.ToInt32(row["LowStockCount"]);
                    if (lowStock > 0)
                    {
                        lblLowStockVal.ForeColor = Color.FromArgb(235, 104, 76);
                    }
                    else
                    {
                        lblLowStockVal.ForeColor = Color.FromArgb(0, 128, 128);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard stats:\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalesChart()
        {
            if (DesignMode||chartSales==null) return; 
            try
            {
                chartSales.Series.Clear();
                chartSales.Titles.Clear();
                
                chartSales.Titles.Add("Product Categories Distribution");
                Series series = chartSales.Series.Add("Categories");
                series.ChartType = SeriesChartType.Pie;

                string query = "SELECT Category, COUNT(*) AS ItemCount FROM [Medicine] GROUP BY Category";
                DataTable dt = DataAccess.DatabaseHelper.ExecuteQuery(query);
                
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        series.Points.AddXY(row["Category"].ToString(), Convert.ToInt32(row["ItemCount"]));
                    }
                }
                else
                {
                    series.Points.AddXY("Antibiotics", 3);
                    series.Points.AddXY("Painkillers", 5);
                    series.Points.AddXY("Vitamins", 4);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Chart load issue: {ex.Message}");
            }
        }

        private void btnManageMedicines_Click(object sender, EventArgs e)
        {
            MedicineManagementForm frm = new MedicineManagementForm();
            frm.ShowDialog();
            LoadStats();
            LoadSalesChart();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            CustomerManagementForm frm = new CustomerManagementForm();
            frm.ShowDialog();
            LoadStats();
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            OrderManagementForm frm = new OrderManagementForm();
            frm.ShowDialog();
            LoadStats();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
           // ReportsForm frm = new ReportsForm();
            //frm.ShowDialog();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            //ProfileForm frm = new ProfileForm();
            //frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthenticationService.Logout();
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
