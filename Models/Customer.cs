using System;

namespace SmartMedPharmacy.Models
{
    public class Customer : User
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public override bool Login(string username, string password)
        {
            return string.Equals(Username, username, StringComparison.OrdinalIgnoreCase) && Password == password;
        }

        public override void Logout()
        {
            // Handled by application session management
        }
    }
}
