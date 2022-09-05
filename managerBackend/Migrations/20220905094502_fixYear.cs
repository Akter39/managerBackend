using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class fixYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_yearGroups_Competitions_CompetitionId",
                table: "yearGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_yearGroups",
                table: "yearGroups");

            migrationBuilder.DropIndex(
                name: "IX_yearGroups_CompetitionId",
                table: "yearGroups");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "yearGroups");

            migrationBuilder.RenameTable(
                name: "yearGroups",
                newName: "YearGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearGroups",
                table: "YearGroups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompetitionYearGroup",
                columns: table => new
                {
                    CompetitionsId = table.Column<int>(type: "int", nullable: false),
                    YearGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionYearGroup", x => new { x.CompetitionsId, x.YearGroupsId });
                    table.ForeignKey(
                        name: "FK_CompetitionYearGroup_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionYearGroup_YearGroups_YearGroupsId",
                        column: x => x.YearGroupsId,
                        principalTable: "YearGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 9,
                column: "Style",
                value: "FL");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 10,
                column: "Style",
                value: "FL");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 19,
                column: "Style",
                value: "FL");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 20,
                column: "Style",
                value: "FL");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionYearGroup_YearGroupsId",
                table: "CompetitionYearGroup",
                column: "YearGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionYearGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearGroups",
                table: "YearGroups");

            migrationBuilder.RenameTable(
                name: "YearGroups",
                newName: "yearGroups");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "yearGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_yearGroups",
                table: "yearGroups",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 9,
                column: "Style",
                value: "Fl");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 10,
                column: "Style",
                value: "Fl");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 19,
                column: "Style",
                value: "Fl");

            migrationBuilder.UpdateData(
                table: "Distances",
                keyColumn: "Id",
                keyValue: 20,
                column: "Style",
                value: "Fl");

            migrationBuilder.CreateIndex(
                name: "IX_yearGroups_CompetitionId",
                table: "yearGroups",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_yearGroups_Competitions_CompetitionId",
                table: "yearGroups",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id");
        }
    }
}
