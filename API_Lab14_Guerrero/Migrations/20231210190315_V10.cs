using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Lab14_Guerrero.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Customers_CustomerId",
                table: "Details");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Details",
                newName: "InvoiceID");

            migrationBuilder.RenameIndex(
                name: "IX_Details_CustomerId",
                table: "Details",
                newName: "IX_Details_InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Invoices_InvoiceID",
                table: "Details",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Invoices_InvoiceID",
                table: "Details");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "Details",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Details_InvoiceID",
                table: "Details",
                newName: "IX_Details_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Customers_CustomerId",
                table: "Details",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
