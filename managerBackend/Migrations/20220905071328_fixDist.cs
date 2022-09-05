using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class fixDist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 1,
                column: "Style",
                value: "FL");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 2,
                column: "Style",
                value: "FL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 1,
                column: "Style",
                value: "Fl");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 2,
                column: "Style",
                value: "Fl");
        }
    }
}
