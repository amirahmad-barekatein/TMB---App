using TimeSeriesModel;
using DbRequestModel;
using System.Text.Json;
using StatementModel.Model.Trip;
using StatementModel.Model.Courier;
using StatementModel.Model.Vendor;
using StatementModel.DAL;

namespace MiareLibrary
{
    
    class Program
    {
        
        static async Task Main(string[] args)   
        {
            var weeksList = RequestTimeSeries.YearWeeksDateTime();
            var weeksListString = RequestTimeSeries.YearWeeks();
            var tripRequest = new TripRequest();
            var courierRequest = new CourierRequest();
            var vendorRequest = new VendorRequest(); 
            //Iterate On the list
            // return;
            var maxUpdateWeek = weeksListString.Count;
            int weekIntervalUpdate = 10;
            //Clear Tables
            // courierRequest.ClearTable(nameof(courierRequest.PunishmentDebt));
            // courierRequest.ClearTable(nameof(courierRequest.ScalableBonus));
            // vendorRequest.ClearTable(nameof(vendorRequest.ClientPaymentPayback));
            // Console.WriteLine("Cleat Tables Completed");
            //Update
            // for (int i = 0; i < maxUpdateWeek; i += weekIntervalUpdate)
            // {
            //     var tw = weeksListString[i];
            //     var nw = weeksListString[Math.Min(i + weekIntervalUpdate - 1, weeksListString.Count - 1 )];
            //     // var resultTrip = await tripRequest.Run(tw,nw);
            //     var resultCourier = await courierRequest.Run(tw,nw);
            //     var resultVendor = await vendorRequest.Run(tw,nw);
            // }
            int weekInterval = 1;
            List<TripPL> tripPL = new List<TripPL>();
            List<CourierPL> courierPL = new List<CourierPL>();
            List<VendorPL> vendorPLs = new List<VendorPL>();
            List<VendorCDWeekly> vendorCDWeekly = new List<VendorCDWeekly>();
            var maxCalculateWeek = weeksList.Count;
            for (int i = 0; i < maxCalculateWeek; i += weekInterval)
            {
                var tw = weeksList[i];
                var nw = weeksList[Math.Min(i + weekInterval - 1, weeksList.Count - 1 )];
                tripPL.Add(new TripPL(tw));
                courierPL.Add(new CourierPL(tw));
                vendorPLs.Add(new VendorPL(tw));
                vendorCDWeekly.Add(new VendorCDWeekly(tw));
            }
            
            using var newDb = new MiareStatementContext();
            Console.WriteLine($"New db path: {newDb.DbPath}");
            newDb.TripPLs.AddRange(tripPL);
            newDb.CourierPLs.AddRange(courierPL);
            newDb.VendorPLs.AddRange(vendorPLs);
            newDb.VendorCDWeeklys.AddRange(vendorCDWeekly);
            newDb.SaveChanges();
            // using(var sw = new StreamWriter( typeof(TripPL).Name +  ".json"))
            // {
            //     var json = JsonSerializer.Serialize(tripPL);
            //     sw.Write(json);
            // }
            // using(var sw = new StreamWriter( typeof(CourierPL).Name +  ".json"))
            // {
            //     var json = JsonSerializer.Serialize(courierPL);
            //     sw.Write(json);
            // }

            // using(var sw = new StreamWriter( typeof(VendorPL).Name +  ".json"))
            // {
            //     var json = JsonSerializer.Serialize(vendorPLs);
            //     sw.Write(json);
            // }
            // using(var sw = new StreamWriter( typeof(VendorCDWeekly).Name +  ".json"))
            // {
            //     var json = JsonSerializer.Serialize(vendorCDWeekly);
            //     sw.Write(json);
            // }


            
        }

    }

}
    


