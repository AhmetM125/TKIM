using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class migupdatesalerecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleRecords_Products_ProductID",
                table: "SaleRecords");

            migrationBuilder.DropIndex(
                name: "IX_SaleRecords_ProductID",
                table: "SaleRecords");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "SaleRecords");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRecords_PRODUCT_ID",
                table: "SaleRecords",
                column: "PRODUCT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleRecords_Products_PRODUCT_ID",
                table: "SaleRecords",
                column: "PRODUCT_ID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleRecords_Products_PRODUCT_ID",
                table: "SaleRecords");

            migrationBuilder.DropIndex(
                name: "IX_SaleRecords_PRODUCT_ID",
                table: "SaleRecords");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "SaleRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SaleRecords_ProductID",
                table: "SaleRecords",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleRecords_Products_ProductID",
                table: "SaleRecords",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
