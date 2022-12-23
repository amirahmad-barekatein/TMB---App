using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Trip{
    [PrimaryKey(nameof(TripVendorHarshId))]
    
    public class TripVendorHarsh : MiareBaseModel
    {
        public int TripVendorHarshId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        
        [SSDataset(Name = "client_harsh")]
        public double? TripClientHarshAmount{get; set;}
        public TripVendorHarsh(){
        }
        public TripVendorHarsh(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            TripClientHarshAmount = (recordFromCsv[1] == null || recordFromCsv[1] == "")? 0 : Double.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
    
}