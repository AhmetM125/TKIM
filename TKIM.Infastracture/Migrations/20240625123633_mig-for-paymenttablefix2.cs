using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class migforpaymenttablefix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_INVOICE_ID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_INVOICE_ID",
                table: "Payments");

            migrationBuilder.AlterColumn<Guid>(
                name: "INVOICE_ID",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PAYMENT_ID",
                table: "Invoices",
                column: "PAYMENT_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Payments_PAYMENT_ID",
                table: "Invoices",
                column: "PAYMENT_ID",
                principalTable: "Payments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Payments_PAYMENT_ID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PAYMENT_ID",
                table: "Invoices");

            migrationBuilder.AlterColumn<Guid>(
                name: "INVOICE_ID",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_INVOICE_ID",
                table: "Payments",
                column: "INVOICE_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_INVOICE_ID",
                table: "Payments",
                column: "INVOICE_ID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
