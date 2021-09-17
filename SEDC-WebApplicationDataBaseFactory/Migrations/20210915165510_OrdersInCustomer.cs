using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC_WebApplicationDataBaseFactory.Migrations
{
    public partial class OrdersInCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_PicturePath",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer_PicturePath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
