using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class newQueries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripCourierSalarys",
                columns: table => new
                {
                    TripCourierSalaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    FinalSalary = table.Column<double>(type: "REAL", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripCourierSalarys", x => x.TripCourierSalaryId);
                });

            migrationBuilder.CreateTable(
                name: "TripCourseCounts",
                columns: table => new
                {
                    TripCourseCountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    CourseCount = table.Column<int>(type: "INTEGER", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripCourseCounts", x => x.TripCourseCountId);
                });

            migrationBuilder.CreateTable(
                name: "TripVendorFinalPrices",
                columns: table => new
                {
                    TripVendorFinalPriceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    FinalPrice = table.Column<double>(type: "REAL", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripVendorFinalPrices", x => x.TripVendorFinalPriceId);
                });

            migrationBuilder.CreateTable(
                name: "TripVendorHarshs",
                columns: table => new
                {
                    TripVendorHarshId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<string>(type: "TEXT", nullable: false),
                    TripClientHarshAmount = table.Column<double>(type: "REAL", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripVendorHarshs", x => x.TripVendorHarshId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripCourierSalarys");

            migrationBuilder.DropTable(
                name: "TripCourseCounts");

            migrationBuilder.DropTable(
                name: "TripVendorFinalPrices");

            migrationBuilder.DropTable(
                name: "TripVendorHarshs");
        }
    }
}
