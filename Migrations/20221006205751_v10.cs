using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_price",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "product_Quantity",
                table: "orders",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "orders",
                newName: "product_Quantity");

            migrationBuilder.AddColumn<double>(
                name: "product_price",
                table: "orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
