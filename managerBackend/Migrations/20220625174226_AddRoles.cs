using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace managerBackend.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userPhone",
                table: "Users",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "userPassword",
                table: "Users",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "userOrganization",
                table: "Users",
                newName: "UserOrganization");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "userCity",
                table: "Users",
                newName: "UserCity");

            migrationBuilder.AddColumn<string>(
                name: "UserDisplayName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "MainAdmin" },
                    { 2, "Admin" },
                    { 3, "User" },
                    { 4, "VipUser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserCity", "UserDisplayName", "UserEmail", "UserName", "UserOrganization", "UserPassword", "UserPhone" },
                values: new object[] { 1, "Moscow", "MainAdmin", "akt@mm.com", "mainadmin", "Administrations", "mainadmin", "89111111111" });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserDisplayName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "Users",
                newName: "userPhone");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Users",
                newName: "userPassword");

            migrationBuilder.RenameColumn(
                name: "UserOrganization",
                table: "Users",
                newName: "userOrganization");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "userEmail");

            migrationBuilder.RenameColumn(
                name: "UserCity",
                table: "Users",
                newName: "userCity");
        }
    }
}
