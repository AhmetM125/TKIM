using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class paymentstable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Payment_BASKET_ID",
                table: "PaymentItems");

            migrationBuilder.RenameColumn(
                name: "BASKET_ID",
                table: "PaymentItems",
                newName: "PAYMENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentItems_BASKET_ID",
                table: "PaymentItems",
                newName: "IX_PaymentItems_PAYMENT_ID");

            migrationBuilder.AddColumn<Guid>(
                name: "COMPANY_ID",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CUSTOMER_ID",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "INVOICE_ID",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PAYMENT_DATE",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PAYMENT_ID",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_COMPANY_ID",
                table: "Payment",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CUSTOMER_ID",
                table: "Payment",
                column: "CUSTOMER_ID");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Companies_COMPANY_ID",
                table: "Payment",
                column: "COMPANY_ID",
                principalTable: "Companies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Customers_CUSTOMER_ID",
                table: "Payment",
                column: "CUSTOMER_ID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Payment_PAYMENT_ID",
                table: "PaymentItems",
                column: "PAYMENT_ID",
                principalTable: "Payment",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Payment_PAYMENT_ID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_COMPANY_ID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customers_CUSTOMER_ID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Payment_PAYMENT_ID",
                table: "PaymentItems");

            migrationBuilder.DropIndex(
                name: "IX_Payment_COMPANY_ID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CUSTOMER_ID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PAYMENT_ID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "COMPANY_ID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CUSTOMER_ID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "INVOICE_ID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PAYMENT_DATE",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PAYMENT_ID",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "PAYMENT_ID",
                table: "PaymentItems",
                newName: "BASKET_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentItems_PAYMENT_ID",
                table: "PaymentItems",
                newName: "IX_PaymentItems_BASKET_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Payment_BASKET_ID",
                table: "PaymentItems",
                column: "BASKET_ID",
                principalTable: "Payment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
