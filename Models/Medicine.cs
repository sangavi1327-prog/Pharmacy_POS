using System;

namespace SmartMedPharmacy.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string Category { get; set; }
        public string Dosage { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Supplier { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Discount { get; set; } // Discount percentage (e.g. 10.00 for 10%)

        public decimal FinalPrice
        {
            get
            {
                return CalculateFinalPrice();
            }
        }

        public decimal CalculateFinalPrice()
        {
            if (Discount < 0) return Price;
            if (Discount > 100) return 0;
            return Price - (Price * (Discount / 100m));
        }

        public bool IsExpiringSoon()
        {
            return (ExpiryDate - DateTime.Today).TotalDays <= 30 && ExpiryDate >= DateTime.Today;
        }

        public bool IsExpired()
        {
            return ExpiryDate < DateTime.Today;
        }

        public bool IsLowStock(int threshold = 10)
        {
            return Stock <= threshold;
        }
    }
}
