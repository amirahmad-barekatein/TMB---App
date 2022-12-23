using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Trip{
    [PrimaryKey(nameof(TripCourierSalaryId))]
    public class TripCourierSalary : MiareBaseModel
    {
        public int TripCourierSalaryId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        
        [SSDataset(Name = "final_salary_with_harsh")]
        public double? FinalSalary{get; set;}
        public TripCourierSalary(){
        }
        public TripCourierSalary(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            FinalSalary = (recordFromCsv[1] == null || recordFromCsv[1] == "")? 0 : Double.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
    
}