using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_carts_product_id",
                table: "carts",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_product_id",
                table: "carts",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_product_id",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_product_id",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "carts");
        }
    }
}
