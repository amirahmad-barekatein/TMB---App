using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Courier{
    [PrimaryKey(nameof(CourierShiftIncomeId))]
    public class CourierShiftIncome : MiareBaseModel
    {
        public int CourierShiftIncomeId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        [SSDataset(Name = "sum")]
        public double? Amount{get; set;}
        public CourierShiftIncome(){
        }
        public CourierShiftIncome(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            Amount = (recordFromCsv[1] == null || recordFromCsv[1] == "") ? 0 : Double.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
}