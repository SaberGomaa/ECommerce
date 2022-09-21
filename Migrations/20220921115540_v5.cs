using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "carts");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "carts");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
