using System;

namespace SmartMedPharmacy.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int CustomerID { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
