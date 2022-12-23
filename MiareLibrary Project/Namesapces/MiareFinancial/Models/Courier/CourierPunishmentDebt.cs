using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;


namespace MiareFinancial.Models.Courier
{
    [PrimaryKey(nameof(CourierPunishmentDebtId))]
    
    public class CourierPunishmentDebt : MiareBaseModel
    {
        //Identifier
        public int CourierPunishmentDebtId{get; set;}
        //Key Identifire
        [SSDataset(Name = "week", IsDate = true )]
        public string Week{get; set;}
        
        [SSDataset(Name = "ledger")]
        public string? LedgerName{get; set;}
        
        [SSDataset(Name = "ledger_id")]
        public int? LedgerId{get; set;}

        [SSDataset(Name = "amount")]
        public int? Amount{get; set;}
        public CourierPunishmentDebt(){
        }
        public CourierPunishmentDebt(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            LedgerName = recordFromCsv[1];
            LedgerId = (recordFromCsv[2] == null || recordFromCsv[2] == "")? 0 : Int32.Parse(recordFromCsv[2]);
            Amount = (recordFromCsv[3] == null || recordFromCsv[3] == "")? 0 : Int32.Parse(recordFromCsv[3]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
}