using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_customer_id",
                table: "contacts",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_customers_customer_id",
                table: "contacts",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_customers_customer_id",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_customer_id",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "contacts");
        }
    }
}
