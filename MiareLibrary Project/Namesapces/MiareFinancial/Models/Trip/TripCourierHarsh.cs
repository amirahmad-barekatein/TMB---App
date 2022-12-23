using System.ComponentModel.DataAnnotations;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;

namespace MiareFinancial.Models.Trip
{
    [PrimaryKey(nameof(TripCourierHarshId))]
    public class TripCourierHarsh : MiareBaseModel
    {
        public int TripCourierHarshId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        
        [SSDataset(Name = "driver_harsh")]
        public double? TripCourierHarshAmount{get; set;}
        public TripCourierHarsh(){
        }
        public TripCourierHarsh(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            TripCourierHarshAmount = (recordFromCsv[1] == null || recordFromCsv[1] == "")? 0 : Double.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
    
}