using MiareFinancial.Models.Trip;
using MiareFinancial.Models.Courier;
using MiareFinancial.Models.Vendor;

namespace MiareFinancial.RequestModels.Financial
{
    //Trips
    public class TripFinancialRequestModel : BaseRequestModel<TripFinancial>
    {
        public override int DatasetId => 3609;
        public override string FilterColumnName { get => "date"; set => base.FilterColumnName = value; }
    }
    public class TripDiscountRequestModel : BaseRequestModel<TripDiscount>
    {
        public override int DatasetId => 2898;
    }

    // public class TripCourierHarshRequestModel : BaseRequestModel<TripCourierHarsh>
    // {
    //     public override int DatasetId => 3638;
    // }

    public class TripCourierSalaryRequestModel : BaseRequestModel<TripCourierSalary>
    {
        public override int DatasetId => 3642;
        public Dictionary<string, string> GetUrlParamsQuery(string startDate, string endDate){
            var  queryUrlParams = new Dictionary<string, string> ();
             queryUrlParams.Add("start_date", startDate);
             queryUrlParams.Add("end_date", endDate);
             return queryUrlParams;
        }
    }

    public class TripCourseCountRequestModel : BaseRequestModel<TripCourseCount>
    {
        public override int DatasetId => 3634;
    }
    public class TripVendorHarshRequestModel : BaseRequestModel<TripVendorHarsh>
    {
        public override int DatasetId => 3633;
    }

    public class TripVendorFinalPriceRequestModel : BaseRequestModel<TripVendorFinalPrice>
    {
        public override int DatasetId => 3635;
    }

    //Courier
    public class CourierGuaranteeRequestModel : BaseRequestModel<CourierGuarantee>
    {
        public override int DatasetId => 1963;
    }
    public class CourierPunishmentDebtRequestModel : BaseRequestModel<CourierPunishmentDebt>
    {
        public override int DatasetId => 2899;
    }
    public class CourierScalableBonusRequestModel : BaseRequestModel<CourierScalableBonus>
    {
        public override int DatasetId => 1965;
    }
    public class CourierShiftIncomeRequestModel : BaseRequestModel<CourierShiftIncome>
    {
        public override int DatasetId => 1966;
    }

    //Vendor
    public class VendorClientPaymentPaybackRequestModel : BaseRequestModel<VendorClientPaymentPayback>
    {
        public override int DatasetId => 2896;
    }
    public class VendorConcurrencyDiscountRequestModel : BaseRequestModel<VendorConcurrencyDiscount>
    {
        public override int DatasetId => 1968;
    }
    public class VendorConcurrencyIncomeRequestModel : BaseRequestModel<VendorConcurrencyIncome>
    {
        public override int DatasetId => 1958;
    }
    public class VendorMiscExpenseRequestModel : BaseRequestModel<VendorMiscExpense>
    {
        public override int DatasetId => 1967;
    }
    public class VendorSameServicePaybackRequestModel : BaseRequestModel<VendorSameServicePayback>
    {
        public override int DatasetId => 1970;
    }
    public class VendorSLAPaybackRequestModel : BaseRequestModel<VendorSLAPayback>
    {
        public override int DatasetId => 1969;
    }

    
}