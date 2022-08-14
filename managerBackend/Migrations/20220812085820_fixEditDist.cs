using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class fixEditDist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 37,
                column: "Style",
                value: "RLFR");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 38,
                column: "Style",
                value: "RLFR");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 39,
                column: "Style",
                value: "RLIM");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 40,
                column: "Style",
                value: "RLIM");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 41,
                column: "Style",
                value: "RLFR");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 42,
                column: "Style",
                value: "RLFR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 37,
                column: "Style",
                value: "FR");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 38,
                column: "Style",
                value: "FR");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 39,
                column: "Style",
                value: "IM");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 40,
                column: "Style",
                value: "IM");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 41,
                column: "Style",
                value: "FR");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 42,
                column: "Style",
                value: "FR");
        }
    }
}
