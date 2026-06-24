using System;
using System.Windows.Forms;
using SmartMedPharmacy.Services;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Forms
{
    public partial class CustomerDashboard : Form
    {
        private Customer _customer;

        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            _customer = AuthenticationService.CurrentUser as Customer;
            if (_customer != null)
            {
                lblWelcome.Text = $"Welcome, {_customer.FullName}";
                lblEmail.Text = $"Email: {_customer.Email}";
            }
            else
            {
                lblWelcome.Text = "Welcome, Customer";
            }
        }

        private void btnSearchMedicines_Click(object sender, EventArgs e)
        {
            SearchMedicineForm frm = new SearchMedicineForm();
            frm.ShowDialog();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartForm frm = new CartForm();
            frm.ShowDialog();
        }

        private void btnTrackOrders_Click(object sender, EventArgs e)
        {
           // TrackOrderForm frm = new TrackOrderForm();
            //frm.ShowDialog();
        }

        private void btnUploadPrescription_Click(object sender, EventArgs e)
        {
            //PrescriptionUploadForm frm = new PrescriptionUploadForm();
           // frm.ShowDialog();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            //ProfileForm frm = new ProfileForm();
            //frm.ShowDialog();
            // Refresh details in case they changed
            CustomerDashboard_Load(sender, e);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthenticationService.Logout();
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void CustomerDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
