using System;

namespace SmartMedPharmacy.Models
{
    public class Admin : User
    {
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
