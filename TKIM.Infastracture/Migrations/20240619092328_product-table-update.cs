using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class producttableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PRICE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TAX",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KDV",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PROFIT",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PURCHASE_PRICE",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SALE_PRICE",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KDV",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PROFIT",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PURCHASE_PRICE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SALE_PRICE",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "STOCK",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PRICE",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TAX",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
