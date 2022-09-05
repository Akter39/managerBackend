using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class distFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Distances",
                table: "Distances",
                newName: "Dist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dist",
                table: "Distances",
                newName: "Distances");
        }
    }
}
