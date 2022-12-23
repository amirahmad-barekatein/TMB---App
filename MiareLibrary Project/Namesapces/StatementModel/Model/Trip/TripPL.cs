using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatasetAttributsNS;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;
using MiareFinancial.Models;
using MiareFinancial.DAL;

namespace StatementModel.Model.Trip 
{
    [PrimaryKey(nameof(TripPLId))]
    public class TripPL : BaseModel
    {
        public int TripPLId{get; set;}
        public double? VendorFinalPrice{get; set;}

        public double? VendorMiscExpense{get; set;}

        public double? TripDiscountCredit{get; set;}

        public double? TripDiscountVoucher{get; set;}

        public double? CourierTripOnlySalary {get; set;}

        public int? CourseCount {get; set;}

        public double? VendorHarsh{get; set;}

        //Calculated
        public double? HarshBalanceIncome {get; set;}

        public double? CourierCPO {get; set;}

        public double? VendorTotalCPO {get; set;}

        public double? VendorCPO {get; set;}

        public double? TotalRealTripBalance {get; set;}


        
        public TripPL(DateTime week) : base(week)
        {
            SetPropertiesValues(week);
            SetCalculatedFactor();
        }

        public void SetPropertiesValues(DateTime week)
        {
            using var db = new MiareFinancialContext();
            VendorFinalPrice = db.TripVendorFinalPrices.Where(fp => fp.DateTime == week).FirstOrDefault()?.FinalPrice;
            VendorMiscExpense = db.VendorMiscExpenses.Where(me => me.DateTime == week).FirstOrDefault()?.Amount;
            TripDiscountCredit = db.TripDiscounts.Where(td => td.DateTime == week).FirstOrDefault()?.TripDiscountAmount;
            TripDiscountVoucher = db.TripDiscounts.Where(td => td.DateTime == week).FirstOrDefault()?.TripVoucheAmount;
            CourierTripOnlySalary = db.TripCourierSalarys.Where(td => td.DateTime == week).FirstOrDefault()?.FinalSalary;
            CourseCount = db.TripCourseCounts.Where(td => td.DateTime == week).FirstOrDefault()?.CourseCount;
            VendorHarsh = db.TripVendorHarshs.Where(td => td.DateTime == week).FirstOrDefault()?.TripClientHarshAmount;
        }

        public void SetCalculatedFactor()
        {
            HarshBalanceIncome = /*(CourierHarsh ?? 0 )  -*/ (VendorHarsh ?? 0) ;
            VendorTotalCPO = VendorFinalPrice + (VendorMiscExpense ?? 0 ) + (TripDiscountCredit ?? 0);
            CourierCPO = CourierTripOnlySalary / (CourseCount ?? 1);
            VendorCPO = VendorTotalCPO / (CourseCount ?? 1);
            TotalRealTripBalance = VendorFinalPrice - CourierTripOnlySalary; 
        }
    }
    
}