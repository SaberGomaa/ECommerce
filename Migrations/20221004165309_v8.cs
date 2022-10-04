using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_Details_orderTables_order_id",
                table: "order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_order_Details_products_product_id",
                table: "order_Details");

            migrationBuilder.DropIndex(
                name: "IX_order_Details_order_id",
                table: "order_Details");

            migrationBuilder.DropIndex(
                name: "IX_order_Details_product_id",
                table: "order_Details");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    subTotal = table.Column<double>(type: "float", nullable: false),
                    product_Quantity = table.Column<int>(type: "int", nullable: false),
                    product_price = table.Column<double>(type: "float", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_total = table.Column<double>(type: "float", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_customer_id",
                table: "Order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_product_id",
                table: "Order",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_order_Details_order_id",
                table: "order_Details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_Details_product_id",
                table: "order_Details",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_Details_orderTables_order_id",
                table: "order_Details",
                column: "order_id",
                principalTable: "orderTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_Details_products_product_id",
                table: "order_Details",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
