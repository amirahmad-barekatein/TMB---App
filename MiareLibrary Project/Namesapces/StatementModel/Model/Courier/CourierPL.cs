using Microsoft.EntityFrameworkCore;
using MiareFinancial.DAL;

namespace StatementModel.Model.Courier
{
    [PrimaryKey(nameof(CourierPLId))]
    public class CourierPL : BaseModel
    {
        public int CourierPLId{get; set;}
        public double? Guarantee{get; set;}

        public double? ShiftSales {get; set;}

        public double? TotalDebt{get; set;}

        public double? TotalCourierAcquisitionCost{get; set;}

        public double? NewCourierAcquisitionCost{get; set;}
        public double? CourierReactivationCost { get; private set; }
        public double? CourierRefferalCost { get; private set; }
        public double? CourierDistibution { get; private set; }
        public double? TotalTripIncentiveCost { get; private set; }
        public double? TripFarAssignCost { get; private set; }
        public double? HurryTripCost { get; private set; }
        public double? RevokeTripCost { get; private set; }

        public CourierPL(DateTime week) : base(week)
        {
            SetPropertiesValues(week);
            SetCalculatedFactor();
        }

        public void SetPropertiesValues(DateTime week)
        {
            using var db = new MiareFinancialContext();
            ShiftSales = db.CourierShiftIncomes
                            .Where(cdb => cdb.DateTime == week)
                            .FirstOrDefault()?.Amount;
            Guarantee = db.CourierGuarantees
                            .Where(cdb => cdb.DateTime == week)
                            .FirstOrDefault()?.GuaranteeAmount;
            TotalDebt = db.CourierPunishmentDebts.ToList()
                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                            .Where(cdb => cdb.DateTime == week)?
                            .Sum(cdb => cdb.Amount);
            TotalCourierAcquisitionCost = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.CourierAcquisitionTotal.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            NewCourierAcquisitionCost = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.NewCourierAcquisition.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            CourierReactivationCost = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.CourierRectivation.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            CourierRefferalCost = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.CourierReferral.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            CourierDistibution = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.CourierDisribution.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            TotalTripIncentiveCost = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.TripInstanceIncentiveTotal.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            TripFarAssignCost = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.TripFarAssign.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            HurryTripCost =  db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.HurryTrip.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            RevokeTripCost = db.CourierScalableBonuss.ToList()
                                            .DistinctBy(cdb => new {cdb.Week, cdb.LedgerId, cdb.Amount})?
                                            .Where(cdb => cdb.DateTime == week)?
                                            .Where(cdb => LedgerAnalyzer.Revoke.Contains((int)cdb.LedgerId))?
                                            .Sum(cdb => cdb.Amount);
            
        }

        public void SetCalculatedFactor()
        {
            
        }
    }
    
}