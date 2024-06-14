using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class productcategoryrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "COMPANY_ID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_COMPANY_ID",
                table: "Products",
                column: "COMPANY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_COMPANY_ID",
                table: "Products",
                column: "COMPANY_ID",
                principalTable: "Companies",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_COMPANY_ID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_COMPANY_ID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "COMPANY_ID",
                table: "Products");
        }
    }
}
