using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Trip{
    [PrimaryKey(nameof(TripVendorFinalPriceId))]
    
    public class TripVendorFinalPrice : MiareBaseModel
    {
        public int TripVendorFinalPriceId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        
        [SSDataset(Name = "final_price_with_harsh")]
        public double? FinalPrice{get; set;}
        public TripVendorFinalPrice(){
        }
        public TripVendorFinalPrice(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            FinalPrice = (recordFromCsv[1] == null || recordFromCsv[1] == "")? 0 : Double.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
    
}