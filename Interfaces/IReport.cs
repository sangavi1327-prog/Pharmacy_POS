using System.Data;

namespace SmartMedPharmacy.Interfaces
{
    public interface IReport
    {
        DataTable GenerateSalesReport();
        DataTable GenerateStockReport();
        DataTable GenerateCustomerReport();
    }
}
