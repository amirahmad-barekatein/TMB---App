using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.Models.Trip{
    [PrimaryKey(nameof(TripCourseCountId))]
    
    public class TripCourseCount : MiareBaseModel
    {
        public int TripCourseCountId{get; set;}
        [SSDataset(Name = "week", IsDate = true )]
        [Key]
        public string Week{get; set;}
        
        [SSDataset(Name = "course_count")]
        public int? CourseCount{get; set;}
        public TripCourseCount(){
        }
        public TripCourseCount(List<string> recordFromCsv){
            Week = recordFromCsv[0];
            CourseCount = (recordFromCsv[1] == null || recordFromCsv[1] == "")? 0 : Int32.Parse(recordFromCsv[1]);
            this.DateTime = DateTime.ParseExact(Week, "yyyy-MM-dd", null);
        }
    }
    
}