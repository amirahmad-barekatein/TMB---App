using Microsoft.EntityFrameworkCore;
using MiareFinancial.DAL;

namespace StatementModel.Model.Vendor
{
    [PrimaryKey(nameof(VendorPLId))]
    public class VendorPL : BaseModel
    {
        public int VendorPLId{get; set;}
        public double? ConcurrencySales{get; set;}
        public double? ConcurrencyDiscount{get; set;}

        public VendorPL(DateTime week) : base(week)
        {
            SetPropertiesValues(week);
            SetCalculatedFactor();
        }

        public void SetPropertiesValues(DateTime week)
        {
            using var db = new MiareFinancialContext();
            ConcurrencySales = db.VendorConcurrencyIncomes.Where(vdb => vdb.DateTime == week).FirstOrDefault()?.Income;
            ConcurrencyDiscount = db.VendorConcurrencyIncomes.Where(vdb => vdb.DateTime == week).FirstOrDefault()?.DiscountAmount;
        }

        public void SetCalculatedFactor()
        {
            
        }
    }
    
}