using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class fixdbpayment1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Payment_PAYMENT_ID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PAYMENT_ID",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_INVOICE_ID",
                table: "Payment",
                column: "INVOICE_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Invoices_INVOICE_ID",
                table: "Payment",
                column: "INVOICE_ID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Invoices_INVOICE_ID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_INVOICE_ID",
                table: "Payment");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PAYMENT_ID",
                table: "Invoices",
                column: "PAYMENT_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Payment_PAYMENT_ID",
                table: "Invoices",
                column: "PAYMENT_ID",
                principalTable: "Payment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
