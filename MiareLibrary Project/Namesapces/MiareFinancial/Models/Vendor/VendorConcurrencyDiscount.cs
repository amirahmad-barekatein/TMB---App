using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Vendor
{
    [PrimaryKey(nameof(VendorConcurrencyDiscountId))]
    public class VendorConcurrencyDiscount : MiareBaseModel
    {
        public int VendorConcurrencyDiscountId{get; set;}
        [SSDataset(Name = "start_date", IsDate = true ), Key]
        public string StartDate{get; set;}
        
        [SSDataset(Name = "end_date", IsDate = true )]
        public string? EndDate{get; set;}

        [SSDataset(Name = "sum_amount" )]
        public double? PeriodDiscountAmount{get; set;}

        [SSDataset(Name = "daily")]
        public double? DailyDiscountAmount{get; set;}
        public DateTime? EndDateTime {get; set;}
        public VendorConcurrencyDiscount()
        {
        }
        public VendorConcurrencyDiscount(List<string> recordFromCsv)
        {
            StartDate = recordFromCsv[0];
            EndDate = recordFromCsv[1];
            PeriodDiscountAmount = (recordFromCsv[2] == null || recordFromCsv[2] == "") ? 0 : Double.Parse(recordFromCsv[2]);
            DailyDiscountAmount = (recordFromCsv[3] == null || recordFromCsv[3] == "") ? 0 : Double.Parse(recordFromCsv[3]);
            this.DateTime = DateTime.ParseExact(StartDate, "yyyy-MM-dd", null);
            EndDateTime = (EndDate == null || EndDate == "") ? this.DateTime.AddDays(30) : DateTime.ParseExact(EndDate, "yyyy-MM-dd", null);
        }
    }
}