using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class fixforpaymentpersonrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_People_PersonID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PersonID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PERSON_ID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Payment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PERSON_ID",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonID",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PersonID",
                table: "Payment",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_People_PersonID",
                table: "Payment",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
