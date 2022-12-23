using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Trip{
    [PrimaryKey(nameof(TripFinancialId))]
    public class TripFinancial : MiareBaseModel
    {
        public int TripFinancialId{get; set;}
        [SSDataset(Name = "date", IsDate = true ), Key]
        public string Date{get; set;}
        [SSDataset(Name = "course_count")]
        public int? CourseCount{get; set;}
        [SSDataset(Name = "final_price")]
        public int? FinalPrice{get; set;}
        [SSDataset(Name = "final_salary")]
        public int? FinalSalary{get; set;}
        [SSDataset(Name = "client_harsh")]
        public int? ClientHarshAmount{get; set;}
        [SSDataset(Name = "driver_harsh")]
        public int? DriverHarshAmount{get; set;}
        public TripFinancial()
        {
        }
        public TripFinancial(List<string> recordFromCsv)
        {
            Date = recordFromCsv[0];
            CourseCount = Int32.Parse(recordFromCsv[1]);
            FinalPrice = Int32.Parse(recordFromCsv[2]);
            FinalSalary = Int32.Parse(recordFromCsv[3]);
            ClientHarshAmount = (recordFromCsv[4] != "") ? Int32.Parse(recordFromCsv[4]) : 0;
            DriverHarshAmount = (recordFromCsv[5] != "") ? Int32.Parse(recordFromCsv[5]) : 0;
            this.DateTime = DateTime.ParseExact(Date, "yyyy-MM-dd", null);
        }
    }
    
}