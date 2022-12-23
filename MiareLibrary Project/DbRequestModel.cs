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
using MiareFinancial.Models;

namespace DbRequestModel 
{
    public static class TableAction
    {
        public static string DeleteAll  { get { return "ClearAllDB"; } }
        public static string InsertQuery { get { return "RunAndAddToDB"; } }
    }
    public class BaseDbRequest
    {
        public  object ActionToTable(string tableName, string action, object[] arguments = null){
            var prop =  this.GetType().GetFields().Where(filed => filed.Name.Contains(tableName) ).First().GetValue(this);
            Console.WriteLine($"Prop Name {prop.GetType().Name}");
            return prop.GetType().GetMethod(action).Invoke(prop, arguments);
        }
        public bool ClearAllTables()
        {
            return this.GetType().GetProperties().Any(p => ClearTable(p.Name));
        }
        public bool ClearTable(string tableName)
        {
            return (bool)ActionToTable(tableName, TableAction.DeleteAll);
        }
    }
    public class TripRequest : BaseDbRequest
    {
        public TripDiscountRequestModel TripDiscount = new TripDiscountRequestModel();
        // public TripCourierHarshRequestModel CourierHarsh = new TripCourierHarshRequestModel();
        public TripCourierSalaryRequestModel CourierSalary = new TripCourierSalaryRequestModel();
        public TripCourseCountRequestModel CourseCount = new TripCourseCountRequestModel();
        public TripVendorFinalPriceRequestModel VendorFinalPrice = new TripVendorFinalPriceRequestModel();
        public TripVendorHarshRequestModel VendorHarsh = new TripVendorHarshRequestModel();

        public TripRequest()
        {

        }

        public async Task<bool[]> Run(string startDate, string endDate )
        {
            object[] arguments = new object[2] {
                startDate , endDate
            };
            object[] csArguments = new object[3] {
                startDate , endDate, CourierSalary.GetUrlParamsQuery(startDate, endDate)
            };
            List<Task<bool>> updateFMTasks = new List<Task<bool>>() {
                    Task<bool>.Run(() => TripDiscount.RunAndAddToDB(arguments)),
                    // Task<bool>.Run(() => requestTripCourierHarsh.RunAndAddToDB(startDate, endDate)),
                    Task<bool>.Run(() => CourierSalary.RunAndAddToDB(csArguments)),
                    Task<bool>.Run(() => CourseCount.RunAndAddToDB(arguments)),
                    Task<bool>.Run(() => VendorFinalPrice.RunAndAddToDB(arguments)),
                    Task<bool>.Run(() => VendorHarsh.RunAndAddToDB(arguments))
                };
            var result = await Task.WhenAll(updateFMTasks);
            return result;
        }
    }

    public class CourierRequest : BaseDbRequest
    {
        public CourierGuaranteeRequestModel Guarantee = new CourierGuaranteeRequestModel();
        public CourierPunishmentDebtRequestModel PunishmentDebt = new CourierPunishmentDebtRequestModel();
        public CourierScalableBonusRequestModel ScalableBonus = new CourierScalableBonusRequestModel();
        public CourierShiftIncomeRequestModel ShiftIncome = new CourierShiftIncomeRequestModel();
        public CourierRequest()
        {

        }
        public async Task<bool[]> Run(string startDate, string endDate )
        {
            object[] arguments = new object[2] {
                startDate , endDate
            };
            List<Task<bool>> updateFMTasks = new List<Task<bool>>() {
                    // Task<bool>.Run(() => Guarantee.RunAndAddToDB(arguments)),
                    Task<bool>.Run(() => PunishmentDebt.RunAndAddToDB(arguments)),
                    Task<bool>.Run(() => ScalableBonus.RunAndAddToDB(arguments)),
                    // Task<bool>.Run(() => ShiftIncome.RunAndAddToDB(arguments))
                };
            var result = await Task.WhenAll(updateFMTasks);
            return result;
        }
        
    }

    public class VendorRequest : BaseDbRequest
    {
        public VendorClientPaymentPaybackRequestModel ClientPaymentPayback = new VendorClientPaymentPaybackRequestModel();
        public VendorConcurrencyDiscountRequestModel ConcurrencyDiscount = new VendorConcurrencyDiscountRequestModel();
        public VendorConcurrencyIncomeRequestModel ConcurrencyIncome = new VendorConcurrencyIncomeRequestModel();
        public VendorMiscExpenseRequestModel MiscExpense = new VendorMiscExpenseRequestModel();
        public VendorSameServicePaybackRequestModel SameServicePayback = new VendorSameServicePaybackRequestModel();
        public VendorSLAPaybackRequestModel SLAPayback = new VendorSLAPaybackRequestModel(); 

        public VendorRequest()
        {
            
        }

        public async Task<bool[]> Run(string startDate, string endDate )
        {
            object[] arguments = new object[2] {
                startDate , endDate
            };
            List<Task<bool>> updateFMTasks = new List<Task<bool>>() {
                    Task<bool>.Run(() => ClientPaymentPayback.RunAndAddToDB(arguments)),
                    // Task<bool>.Run(() => ConcurrencyDiscount.RunAndAddToDB(arguments)),
                    // Task<bool>.Run(() => ConcurrencyIncome.RunAndAddToDB(arguments)),
                    // Task<bool>.Run(() => MiscExpense.RunAndAddToDB(arguments)),
                    // Task<bool>.Run(() => SameServicePayback.RunAndAddToDB(arguments)),
                    // Task<bool>.Run(() => SLAPayback.RunAndAddToDB(arguments))
                };
            var result = await Task.WhenAll(updateFMTasks);
            return result;
        }
    }

}