using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartMedPharmacy.Database;

namespace SmartMedPharmacy.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Initializing application database...";
            progressBar.Value = 10;

            try
            {
                // Run database initialization asynchronously so the UI does not freeze
                await Task.Run(() => DatabaseInitializer.InitializeDatabase());
                progressBar.Value = 50;

                lblStatus.Text = "Loading system configurations...";
                for (int i = 51; i <= 100; i++)
                {
                    await Task.Delay(15);
                    progressBar.Value = i;
                }

                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Database initialization failed.";
                MessageBox.Show($"Startup Error: {ex.Message}\n\nPlease check SQL Server LocalDB connection and restart.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
