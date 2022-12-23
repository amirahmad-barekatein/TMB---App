using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;

namespace MiareFinancial.Models.Vendor
{
    [PrimaryKey(nameof(VendorConcurrencyIncomeId))]
    public class VendorConcurrencyIncome : MiareBaseModel
    {
        public int VendorConcurrencyIncomeId{get; set;}
        [SSDataset(Name = "week", IsDate = true ), Key]
        public string Week {get; set;}
        
        [SSDataset(Name = "cc_income")]
        public double? Income {get; set;}

        [SSDataset(Name = "discount")]
        public double? DiscountAmount {get; set;}
        public VendorConcurrencyIncome()
        {
        }
        public VendorConcurrencyIncome(List<string> recordFromCsv)
        {
            Week = recordFromCsv[0];
            Income = (recordFromCsv[1] == null || recordFromCsv[1] == "") ? 0 : Double.Parse(recordFromCsv[1]);
            DiscountAmount = (recordFromCsv[2] != null && recordFromCsv[2] != "") ? Double.Parse(recordFromCsv[2]) : 0 ;
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
}