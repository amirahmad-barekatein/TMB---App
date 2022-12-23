using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;


namespace MiareFinancial.Models.Courier{
    [PrimaryKey(nameof(CourierGuaranteeId))]
    
    public class CourierGuarantee : MiareBaseModel
    {
        public int CourierGuaranteeId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        [SSDataset(Name = "sum_guarantee")]
        public int? GuaranteeAmount{get; set;}

        public CourierGuarantee(){
        }
        public CourierGuarantee(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            GuaranteeAmount = (recordFromCsv[1] == null || recordFromCsv[1] == "")? 0 : Int32.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
}