using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class editDist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionDistance");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Distances",
                newName: "Style");

            migrationBuilder.AddColumn<string>(
                name: "Distance",
                table: "Distances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CompetitionDistances",
                columns: table => new
                {
                    CompetitionsId = table.Column<int>(type: "int", nullable: false),
                    DistancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionDistances", x => new { x.CompetitionsId, x.DistancesId });
                    table.ForeignKey(
                        name: "FK_CompetitionDistances_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionDistances_Distances_DistancesId",
                        column: x => x.DistancesId,
                        principalTable: "Distances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "mail", "Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "femail", "Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "mail", "BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "femail", "BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "mail", "BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "femail", "BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "50", "femail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "mail", "Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "femail", "Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "mail", "BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "femail", "BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "mail", "BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "femail", "BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "femail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "mail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "100", "femail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "mail", "Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "femail", "Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "mail", "BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "femail", "BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "mail", "BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "femail", "BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "femail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "mail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "200", "femail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "400", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "400", "femail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "400", "mail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "400", "femail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "800", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "800", "femail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "1500", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "1500", "femail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "4x100", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "4x100", "femail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "4x100", "mail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "4x100", "femail", "IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "4x200", "mail", "FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Distance", "Gender", "Style" },
                values: new object[] { "4x200", "femail", "FR" });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionDistances_DistancesId",
                table: "CompetitionDistances",
                column: "DistancesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionDistances");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Distances");

            migrationBuilder.RenameColumn(
                name: "Style",
                table: "Distances",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "CompetitionDistance",
                columns: table => new
                {
                    CompetitionsId = table.Column<int>(type: "int", nullable: false),
                    DistancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionDistance", x => new { x.CompetitionsId, x.DistancesId });
                    table.ForeignKey(
                        name: "FK_CompetitionDistance_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionDistance_Distances_DistancesId",
                        column: x => x.DistancesId,
                        principalTable: "Distances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "50Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "50BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "50BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "50FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "100Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "100BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "100BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "100FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "100IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "200Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "200BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "200BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "200FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "200IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "400FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "400IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "800FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "1500FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "4x100FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "4x100IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Male", "4x200FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "50Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "50BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "50BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "50FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "100Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "100BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "100BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "100FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "100IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "200Fl" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "200BK" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "200BR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "200FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "200IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "400FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "400IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "800FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "1500FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "4x100FR" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "4x100IM" });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Gender", "Name" },
                values: new object[] { "Female", "4x200FR" });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionDistance_DistancesId",
                table: "CompetitionDistance",
                column: "DistancesId");
        }
    }
}
