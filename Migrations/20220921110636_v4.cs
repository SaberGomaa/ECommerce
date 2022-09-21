using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_admins_customer_id",
                table: "admins",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_admins_product_id",
                table: "admins",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_admins_customers_customer_id",
                table: "admins",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_admins_products_product_id",
                table: "admins",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_customers_customer_id",
                table: "admins");

            migrationBuilder.DropForeignKey(
                name: "FK_admins_products_product_id",
                table: "admins");

            migrationBuilder.DropIndex(
                name: "IX_admins_customer_id",
                table: "admins");

            migrationBuilder.DropIndex(
                name: "IX_admins_product_id",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "admins");
        }
    }
}
