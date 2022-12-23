using StatementModel.Model.Courier;
using StatementModel.Model.Trip;
using StatementModel.Model.Vendor;
using Microsoft.EntityFrameworkCore;

namespace StatementModel.DAL
{
    public class MiareStatementContext : DbContext
    {
        //Trip
        public DbSet<TripPL> TripPLs { get; set; }
        public DbSet<CourierPL> CourierPLs { get; set; }
        public DbSet<VendorPL> VendorPLs { get; set; }
        public DbSet<VendorCDWeekly> VendorCDWeeklys { get; set; }
        public string DbPath { get; }
        public MiareStatementContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "MiareStatementRaw.db");
            // Console.Write(DbPath);
            // if(this.Database.EnsureCreated() == false)
            //     this.Database.Migrate();
        }
         protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");



    }
}