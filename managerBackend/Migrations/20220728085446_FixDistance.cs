using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class FixDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Distances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 6,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 7,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 8,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 9,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 10,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 11,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 12,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 13,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 14,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 15,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 16,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 17,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 18,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 19,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 20,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 21,
                column: "Gender",
                value: "Male");

            migrationBuilder.InsertData(
                table: "Distances",
                columns: new[] { "Id", "Gender", "Name" },
                values: new object[,]
                {
                    { 22, "Female", "50Fl" },
                    { 23, "Female", "50BK" },
                    { 24, "Female", "50BR" },
                    { 25, "Female", "50FR" },
                    { 26, "Female", "100Fl" },
                    { 27, "Female", "100BK" },
                    { 28, "Female", "100BR" },
                    { 29, "Female", "100FR" },
                    { 30, "Female", "100IM" },
                    { 31, "Female", "200Fl" },
                    { 32, "Female", "200BK" },
                    { 33, "Female", "200BR" },
                    { 34, "Female", "200FR" },
                    { 35, "Female", "200IM" },
                    { 36, "Female", "400FR" },
                    { 37, "Female", "400IM" },
                    { 38, "Female", "800FR" },
                    { 39, "Female", "1500FR" },
                    { 40, "Female", "4x100FR" },
                    { 41, "Female", "4x100IM" },
                    { 42, "Female", "4x200FR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Distances");
        }
    }
}
