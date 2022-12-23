
using System.Net;
using System.Net.Http.Json;
using MiareFinancial.SupersetModels;
using CSVParserNS;
using MiareFinancial.RequestModels;
using MiareFinancial.Models.Trip;
using MiareFinancial.Models.Courier;
using MiareFinancial.Models.Vendor;
using MiareFinancial.DAL;
using System.Reflection;
using MiareFinancial.RequestModels.Financial;
namespace TimeSeriesModel 
{
    public static class RequestTimeSeries
    {
        public static string FirstWeek = "2021-03-21";
        public static string LastWeek = "2022-12-18";

        public static string DateTimeFormat = "yyyy-MM-dd";

        public static List<string> GenerateWeeksList(DateTime startDate, DateTime endDate)
        {
            var startDateSaturday = GetSaturday(startDate);
            var endDateSaturday = GetSaturday(endDate);
            if(endDateSaturday < startDate)
                return new List<string>();
            var weeksDates = new List<string>();
            var weeks_count = (int)((endDateSaturday - startDateSaturday).TotalDays / 7);
            for(int i = 0; i < weeks_count + 1; i += 1 )
                weeksDates.Add(startDateSaturday.AddDays(7 * i ).ToString(DateTimeFormat) );
            return weeksDates;

        }
        public static List<DateTime> GenerateWeeksDateTimeList(DateTime startDate, DateTime endDate)
        {
            var startDateSaturday = GetSaturday(startDate);
            var endDateSaturday = GetSaturday(endDate);
            if(endDateSaturday < startDate)
                return new List<DateTime>();
            var weeksDates = new List<DateTime>();
            var weeks_count = (int)((endDateSaturday - startDateSaturday).TotalDays / 7);
            for(int i = 0; i < weeks_count + 1; i += 1 )
                weeksDates.Add(startDateSaturday.AddDays(7 * i ));
            return weeksDates;

        }
        public static DateTime GetSaturday(DateTime date)
        {
            int datediff = date.DayOfWeek - DayOfWeek.Saturday;
            DateTime Saturday = date.AddDays(-datediff);
            return Saturday;
        }

        public static List<string> YearWeeks()
        {
            var weeksList = GenerateWeeksList(DateTime.ParseExact(FirstWeek, DateTimeFormat, null),
                                              DateTime.ParseExact(LastWeek, DateTimeFormat, null) );
            return weeksList;
        }

        public static List<DateTime> YearWeeksDateTime()
        {
            var weeksList = GenerateWeeksDateTimeList(DateTime.ParseExact(FirstWeek, "yyyy-MM-dd", null),
                                                      DateTime.ParseExact(LastWeek, "yyyy-MM-dd", null) );
            return weeksList;
        }
    }
}