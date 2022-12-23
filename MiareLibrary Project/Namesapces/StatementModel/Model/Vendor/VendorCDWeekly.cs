using Microsoft.EntityFrameworkCore;
using MiareFinancial.DAL;

namespace StatementModel.Model.Vendor
{
    [PrimaryKey(nameof(VendorCDWeeklyId))]
    public class VendorCDWeekly : BaseModel
    {
        public int VendorCDWeeklyId{get; set;}
        public double? ConcurrencyDiscount{get; set;}
        
        public VendorCDWeekly(DateTime week) : base(week)
        {
            SetPropertiesValues(week);
        }

        public void SetPropertiesValues(DateTime week)
        {
            using var db = new MiareFinancialContext();
            ConcurrencyDiscount = db.VendorConcurrencyDiscounts.ToList()
                                    .DistinctBy(vdb => new {vdb.StartDate, vdb.EndDate, vdb.EndDateTime, vdb.DateTime, vdb.DailyDiscountAmount})
                                    .Where(vdb => vdb.DateTime <=  week.AddDays(7))
                                    .Sum(vdb => ((DateTime.Compare(vdb.EndDateTime ?? DateTime.MaxValue, week.AddDays(7)) >= 0 )
                                                 ? DateTime.Compare(vdb.DateTime, week) >= 0 
                                                                        ? (week.AddDays(7) - vdb.DateTime).TotalDays   
                                                                        : (week.AddDays(7) - week).TotalDays
                                                 : DateTime.Compare(vdb.DateTime, week) >= 0 
                                                                        ? ((vdb.EndDateTime ?? DateTime.MaxValue) - vdb.DateTime).TotalDays   
                                                                        : ((vdb.EndDateTime ?? DateTime.MaxValue) - week).TotalDays
                                                ) * vdb.DailyDiscountAmount
                                    );

        }

    }
    
}