using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class miggpurchaserecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRecords_Products_ProductID",
                table: "PurchaseRecords");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRecords_ProductID",
                table: "PurchaseRecords");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "PurchaseRecords");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRecords_PRODUCT_ID",
                table: "PurchaseRecords",
                column: "PRODUCT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRecords_Products_PRODUCT_ID",
                table: "PurchaseRecords",
                column: "PRODUCT_ID",
                principalTable: "Products",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRecords_Products_PRODUCT_ID",
                table: "PurchaseRecords");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRecords_PRODUCT_ID",
                table: "PurchaseRecords");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "PurchaseRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRecords_ProductID",
                table: "PurchaseRecords",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRecords_Products_ProductID",
                table: "PurchaseRecords",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
