using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StatementModel
{
    public class BaseModel
    {
        [Key]
        public DateTime Week{get; set;}

        public string WeekJalali{get; set;} 

        public bool AllWeekInMonth{get; set;} = true;

        public int ShareInMonth{get; set;} = 7;
        public string? ToWeekJalali()
        {
            if(Week == null)
                return null;
            var persianCalendar = new System.Globalization.PersianCalendar();
            WeekJalali = string.Format("{0:0000}-{1:00}-{2:00}", 
                                        persianCalendar.GetYear(Week),
                                        persianCalendar.GetMonth(Week),
                                        persianCalendar.GetDayOfMonth(Week)
                                      );
            if(persianCalendar.GetMonth(Week) != persianCalendar.GetMonth(Week.AddDays(7)))
                AllWeekInMonth = false;
            if(AllWeekInMonth == false)
            {
                ShareInMonth = 7 - persianCalendar.GetDayOfMonth(Week.AddDays(7));
            }
            return WeekJalali;
        }
        public BaseModel(DateTime week)
        {
            this.Week = week;
            ToWeekJalali();
        }
    }
    
}