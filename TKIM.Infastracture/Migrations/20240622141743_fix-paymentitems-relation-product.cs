using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class fixpaymentitemsrelationproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Products_ProductID",
                table: "PaymentItems");

            migrationBuilder.DropIndex(
                name: "IX_PaymentItems_ProductID",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "PaymentItems");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentItems_PRODUCT_ID",
                table: "PaymentItems",
                column: "PRODUCT_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Products_PRODUCT_ID",
                table: "PaymentItems",
                column: "PRODUCT_ID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Products_PRODUCT_ID",
                table: "PaymentItems");

            migrationBuilder.DropIndex(
                name: "IX_PaymentItems_PRODUCT_ID",
                table: "PaymentItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "PaymentItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentItems_ProductID",
                table: "PaymentItems",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Products_ProductID",
                table: "PaymentItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
