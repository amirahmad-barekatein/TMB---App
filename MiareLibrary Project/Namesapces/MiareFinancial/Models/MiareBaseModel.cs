using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using DatasetAttributsNS;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models{
    public class MiareBaseModel : System.Data.Entity.DbSet
    {   
        public DateTime DateTime {get; set;}
        public MiareBaseModel () 
        {
        }
        
    }
    
}