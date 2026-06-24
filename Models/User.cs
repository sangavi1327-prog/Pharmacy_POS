namespace SmartMedPharmacy.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public abstract bool Login(string username, string password);
        public abstract void Logout();
    }
}
