using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC_WebApplicationDataBaseFactory.Migrations
{
    public partial class RoleCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");
        }
    }
}
