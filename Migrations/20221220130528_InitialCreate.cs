using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourierGuarantees",
                columns: table => new
                {
                    CourierGuaranteeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    GuaranteeAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierGuarantees", x => x.CourierGuaranteeId);
                });

            migrationBuilder.CreateTable(
                name: "CourierPunishmentDebts",
                columns: table => new
                {
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    LedgerName = table.Column<string>(type: "TEXT", nullable: false),
                    LedgerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    CourierPunishmentDebtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierPunishmentDebts", x => x.CourierPunishmentDebtId);
                });

            migrationBuilder.CreateTable(
                name: "CourierScalableBonuss",
                columns: table => new
                {
                    CourierScalableBonusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    LedgerName = table.Column<string>(type: "TEXT", nullable: false),
                    LedgerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierScalableBonuss", x => x.CourierScalableBonusId);
                });

            migrationBuilder.CreateTable(
                name: "CourierShiftIncomes",
                columns: table => new
                {
                    CourierShiftIncomeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierShiftIncomes", x => x.CourierShiftIncomeId);
                });

            migrationBuilder.CreateTable(
                name: "TripDiscounts",
                columns: table => new
                {
                    TripDiscountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    TripDiscountAmount = table.Column<double>(type: "REAL", nullable: false),
                    TripVoucheAmount = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDiscounts", x => x.TripDiscountId);
                });

            migrationBuilder.CreateTable(
                name: "TripFinancials",
                columns: table => new
                {
                    TripFinancialId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    CourseCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalSalary = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientHarshAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverHarshAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripFinancials", x => x.TripFinancialId);
                });

            migrationBuilder.CreateTable(
                name: "VendorClientPaymentPaybacks",
                columns: table => new
                {
                    VendorClientPaymentPaybackId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    LedgerName = table.Column<string>(type: "TEXT", nullable: false),
                    LedgerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorClientPaymentPaybacks", x => x.VendorClientPaymentPaybackId);
                });

            migrationBuilder.CreateTable(
                name: "VendorConcurrencyDiscounts",
                columns: table => new
                {
                    VendorConcurrencyDiscountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<string>(type: "TEXT", nullable: false),
                    EndDate = table.Column<string>(type: "TEXT", nullable: false),
                    PeriodDiscountAmount = table.Column<double>(type: "REAL", nullable: false),
                    DailyDiscountAmount = table.Column<double>(type: "REAL", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorConcurrencyDiscounts", x => x.VendorConcurrencyDiscountId);
                });

            migrationBuilder.CreateTable(
                name: "VendorConcurrencyIncomes",
                columns: table => new
                {
                    VendorConcurrencyIncomeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    Income = table.Column<double>(type: "REAL", nullable: false),
                    DiscountAmount = table.Column<double>(type: "REAL", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorConcurrencyIncomes", x => x.VendorConcurrencyIncomeId);
                });

            migrationBuilder.CreateTable(
                name: "VendorMiscExpenses",
                columns: table => new
                {
                    VendorMiscExpenseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorMiscExpenses", x => x.VendorMiscExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "VendorSameServicePaybacks",
                columns: table => new
                {
                    VendorSLAPaybackId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSameServicePaybacks", x => x.VendorSLAPaybackId);
                });

            migrationBuilder.CreateTable(
                name: "VendorSLAPaybacks",
                columns: table => new
                {
                    VendorSLAPaybackId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSLAPaybacks", x => x.VendorSLAPaybackId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourierGuarantees");

            migrationBuilder.DropTable(
                name: "CourierPunishmentDebts");

            migrationBuilder.DropTable(
                name: "CourierScalableBonuss");

            migrationBuilder.DropTable(
                name: "CourierShiftIncomes");

            migrationBuilder.DropTable(
                name: "TripDiscounts");

            migrationBuilder.DropTable(
                name: "TripFinancials");

            migrationBuilder.DropTable(
                name: "VendorClientPaymentPaybacks");

            migrationBuilder.DropTable(
                name: "VendorConcurrencyDiscounts");

            migrationBuilder.DropTable(
                name: "VendorConcurrencyIncomes");

            migrationBuilder.DropTable(
                name: "VendorMiscExpenses");

            migrationBuilder.DropTable(
                name: "VendorSameServicePaybacks");

            migrationBuilder.DropTable(
                name: "VendorSLAPaybacks");
        }
    }
}
