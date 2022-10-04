using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_customers_customer_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_products_product_id",
                table: "Order");

            migrationBuilder.DropTable(
                name: "order_Details");

            migrationBuilder.DropTable(
                name: "orderTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_product_id",
                table: "orders",
                newName: "IX_orders_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_customer_id",
                table: "orders",
                newName: "IX_orders_customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_customer_id",
                table: "orders",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_customer_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_product_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_orders_product_id",
                table: "Order",
                newName: "IX_Order_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_customer_id",
                table: "Order",
                newName: "IX_Order_customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "order_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_Quantity = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_price = table.Column<double>(type: "float", nullable: false),
                    subTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orderTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderTables_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderTables_customer_id",
                table: "orderTables",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_customers_customer_id",
                table: "Order",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_products_product_id",
                table: "Order",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
