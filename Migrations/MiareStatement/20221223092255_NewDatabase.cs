using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations.MiareStatement
{
    /// <inheritdoc />
    public partial class NewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourierPLs",
                columns: table => new
                {
                    CourierPLId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Guarantee = table.Column<double>(type: "REAL", nullable: true),
                    ShiftSales = table.Column<double>(type: "REAL", nullable: true),
                    TotalDebt = table.Column<double>(type: "REAL", nullable: true),
                    TotalCourierAcquisitionCost = table.Column<double>(type: "REAL", nullable: true),
                    NewCourierAcquisitionCost = table.Column<double>(type: "REAL", nullable: true),
                    CourierReactivationCost = table.Column<double>(type: "REAL", nullable: true),
                    CourierRefferalCost = table.Column<double>(type: "REAL", nullable: true),
                    CourierDistibution = table.Column<double>(type: "REAL", nullable: true),
                    TotalTripIncentiveCost = table.Column<double>(type: "REAL", nullable: true),
                    TripFarAssignCost = table.Column<double>(type: "REAL", nullable: true),
                    HurryTripCost = table.Column<double>(type: "REAL", nullable: true),
                    RevokeTripCost = table.Column<double>(type: "REAL", nullable: true),
                    Week = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WeekJalali = table.Column<string>(type: "TEXT", nullable: false),
                    AllWeekInMonth = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShareInMonth = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierPLs", x => x.CourierPLId);
                });

            migrationBuilder.CreateTable(
                name: "TripPLs",
                columns: table => new
                {
                    TripPLId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VendorFinalPrice = table.Column<double>(type: "REAL", nullable: true),
                    VendorMiscExpense = table.Column<double>(type: "REAL", nullable: true),
                    TripDiscountCredit = table.Column<double>(type: "REAL", nullable: true),
                    TripDiscountVoucher = table.Column<double>(type: "REAL", nullable: true),
                    CourierTripOnlySalary = table.Column<double>(type: "REAL", nullable: true),
                    CourseCount = table.Column<int>(type: "INTEGER", nullable: true),
                    VendorHarsh = table.Column<double>(type: "REAL", nullable: true),
                    HarshBalanceIncome = table.Column<double>(type: "REAL", nullable: true),
                    CourierCPO = table.Column<double>(type: "REAL", nullable: true),
                    VendorTotalCPO = table.Column<double>(type: "REAL", nullable: true),
                    VendorCPO = table.Column<double>(type: "REAL", nullable: true),
                    TotalRealTripBalance = table.Column<double>(type: "REAL", nullable: true),
                    Week = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WeekJalali = table.Column<string>(type: "TEXT", nullable: false),
                    AllWeekInMonth = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShareInMonth = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPLs", x => x.TripPLId);
                });

            migrationBuilder.CreateTable(
                name: "VendorCDWeeklys",
                columns: table => new
                {
                    VendorCDWeeklyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConcurrencyDiscount = table.Column<double>(type: "REAL", nullable: true),
                    Week = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WeekJalali = table.Column<string>(type: "TEXT", nullable: false),
                    AllWeekInMonth = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShareInMonth = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCDWeeklys", x => x.VendorCDWeeklyId);
                });

            migrationBuilder.CreateTable(
                name: "VendorPLs",
                columns: table => new
                {
                    VendorPLId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConcurrencySales = table.Column<double>(type: "REAL", nullable: true),
                    ConcurrencyDiscount = table.Column<double>(type: "REAL", nullable: true),
                    Week = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WeekJalali = table.Column<string>(type: "TEXT", nullable: false),
                    AllWeekInMonth = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShareInMonth = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorPLs", x => x.VendorPLId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourierPLs");

            migrationBuilder.DropTable(
                name: "TripPLs");

            migrationBuilder.DropTable(
                name: "VendorCDWeeklys");

            migrationBuilder.DropTable(
                name: "VendorPLs");
        }
    }
}
