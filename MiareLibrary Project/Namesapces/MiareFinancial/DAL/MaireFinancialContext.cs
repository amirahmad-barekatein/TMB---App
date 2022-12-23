using MiareFinancial.Models.Courier;
using MiareFinancial.Models.Trip;
using MiareFinancial.Models.Vendor;
using Microsoft.EntityFrameworkCore;

namespace MiareFinancial.DAL
{
    public class MiareFinancialContext : DbContext
    {
        //Trip
        public DbSet<TripFinancial> TripFinancials { get; set; }
        // public DbSet<TripCourierHarsh> TripCourierHarshs { get; set; }
        public DbSet<TripCourierSalary> TripCourierSalarys { get; set; }
        public DbSet<TripCourseCount> TripCourseCounts { get; set; }
        public DbSet<TripVendorHarsh> TripVendorHarshs { get; set; }
        public DbSet<TripVendorFinalPrice> TripVendorFinalPrices { get; set; }
        public DbSet<TripDiscount> TripDiscounts { get; set; }
        
        //Courier
        public DbSet<CourierPunishmentDebt> CourierPunishmentDebts { get; set; }
        public DbSet<CourierGuarantee> CourierGuarantees { get; set; }
        public DbSet<CourierScalableBonus> CourierScalableBonuss { get; set; }
        public DbSet<CourierShiftIncome> CourierShiftIncomes { get; set; }
        //Vendor
        public DbSet<VendorClientPaymentPayback> VendorClientPaymentPaybacks { get; set; }
        public DbSet<VendorConcurrencyDiscount> VendorConcurrencyDiscounts { get; set; }
        public DbSet<VendorConcurrencyIncome> VendorConcurrencyIncomes { get; set; }
        public DbSet<VendorMiscExpense> VendorMiscExpenses { get; set; }
        public DbSet<VendorSameServicePayback> VendorSameServicePaybacks { get; set; }
        public DbSet<VendorSLAPayback> VendorSLAPaybacks { get; set; }
        public string DbPath { get; }
        public MiareFinancialContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "MiareFinancialRaw.db");
            // Console.Write(DbPath);
            // if(this.Database.EnsureCreated() == false)
            //     this.Database.Migrate();
        }
         protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");



    }
}