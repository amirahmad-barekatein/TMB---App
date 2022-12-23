using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Trip{
    [PrimaryKey(nameof(TripDiscountId))]
    
    public class TripDiscount : MiareBaseModel
    {
        public int TripDiscountId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        
        [SSDataset(Name = "trip_discount")]
        public double? TripDiscountAmount{get; set;}
        [SSDataset(Name = "trip_voucher")]
        
        public double? TripVoucheAmount{get; set;}
        public TripDiscount(){
        }
        public TripDiscount(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            TripDiscountAmount = (recordFromCsv[1] == null || recordFromCsv[1] == "")? 0 : Double.Parse(recordFromCsv[1]);
            TripVoucheAmount = (recordFromCsv[2] == null || recordFromCsv[2] == "")? 0 : Double.Parse(recordFromCsv[2]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
    
}