using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class yearGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionDistances");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "Distances",
                newName: "Distances");

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

            migrationBuilder.CreateTable(
                name: "yearGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    Infinity = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yearGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_yearGroups_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionDistance_DistancesId",
                table: "CompetitionDistance",
                column: "DistancesId");

            migrationBuilder.CreateIndex(
                name: "IX_yearGroups_CompetitionId",
                table: "yearGroups",
                column: "CompetitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionDistance");

            migrationBuilder.DropTable(
                name: "yearGroups");

            migrationBuilder.RenameColumn(
                name: "Distances",
                table: "Distances",
                newName: "Distance");

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

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionDistances_DistancesId",
                table: "CompetitionDistances",
                column: "DistancesId");
        }
    }
}
