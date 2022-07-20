using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class EditCompetitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competition_Users_UserId",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionDistance_Competition_CompetitionsId",
                table: "CompetitionDistance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competition",
                table: "Competition");

            migrationBuilder.RenameTable(
                name: "Competition",
                newName: "Competitions");

            migrationBuilder.RenameIndex(
                name: "IX_Competition_UserId",
                table: "Competitions",
                newName: "IX_Competitions_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BidDate",
                table: "Competitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Contribution",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentComands",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentMembers",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Individual",
                table: "Competitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvitOnly",
                table: "Competitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxComandMembers",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxComands",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxMembers",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PoolLanes",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionDistance_Competitions_CompetitionsId",
                table: "CompetitionDistance",
                column: "CompetitionsId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Users_UserId",
                table: "Competitions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionDistance_Competitions_CompetitionsId",
                table: "CompetitionDistance");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Users_UserId",
                table: "Competitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "BidDate",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Contribution",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CurrentComands",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CurrentMembers",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Individual",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "InvitOnly",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "MaxComandMembers",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "MaxComands",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "MaxMembers",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "PoolLanes",
                table: "Competitions");

            migrationBuilder.RenameTable(
                name: "Competitions",
                newName: "Competition");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_UserId",
                table: "Competition",
                newName: "IX_Competition_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competition",
                table: "Competition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_Users_UserId",
                table: "Competition",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionDistance_Competition_CompetitionsId",
                table: "CompetitionDistance",
                column: "CompetitionsId",
                principalTable: "Competition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
