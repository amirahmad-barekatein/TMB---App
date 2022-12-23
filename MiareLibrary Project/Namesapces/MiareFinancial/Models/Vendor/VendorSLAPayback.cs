using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Vendor
{
    [PrimaryKey(nameof(VendorSLAPaybackId))]
    public class VendorSLAPayback : MiareBaseModel
    {
        public int VendorSLAPaybackId{get; set;}
        [SSDataset(Name = "week", IsDate = true ), Key]
        public string Week{get; set;}
        
        [SSDataset(Name = "sum_amount")]
        public double? Amount{get; set;}
        public VendorSLAPayback(){
        }
        public VendorSLAPayback(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            Amount = (recordFromCsv[1] == null || recordFromCsv[1] == "") ? 0 : Double.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
}