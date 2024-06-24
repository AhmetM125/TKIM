using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class salepaymentrecordsboth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Companies_COMPANY_ID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customers_CUSTOMER_ID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Invoices_INVOICE_ID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Payment_PAYMENT_ID",
                table: "PaymentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Products_PRODUCT_ID",
                table: "PaymentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CURRENT_PROFIT",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "CURRENT_PURCHASE_PRICE",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "CURRENT_SALE_PRICE",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "CURRENT_TAX",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "QUANTITY_AFTER",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "QUANTITY_CURRENT",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "QUANTITY_IN_CART",
                table: "PaymentItems");

            migrationBuilder.DropColumn(
                name: "TOTAL_PRICE",
                table: "PaymentItems");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameColumn(
                name: "PRODUCT_ID",
                table: "PaymentItems",
                newName: "SALE_RECORD_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentItems_PRODUCT_ID",
                table: "PaymentItems",
                newName: "IX_PaymentItems_SALE_RECORD_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_INVOICE_ID",
                table: "Payments",
                newName: "IX_Payments_INVOICE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_CUSTOMER_ID",
                table: "Payments",
                newName: "IX_Payments_CUSTOMER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_COMPANY_ID",
                table: "Payments",
                newName: "IX_Payments_COMPANY_ID");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "PaymentItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PurchaseRecords",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRODUCT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTITY_CURRENT = table.Column<short>(type: "smallint", nullable: false),
                    QUANTITY_AFTER = table.Column<short>(type: "smallint", nullable: false),
                    QUANTITY_PURCHASED = table.Column<short>(type: "smallint", nullable: false),
                    PURCHASE_PRICE_BEFORE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PURCHASE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PURCHASE_PRICE_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TAX_BEFORE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TAX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TAX_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PROFIT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PROFIT_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SALE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SALE_PRICE_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseRecords_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });
            migrationBuilder.CreateTable(
                name: "SaleRecords",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRODUCT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTITY_CURRENT = table.Column<short>(type: "smallint", nullable: false),
                    QUANTITY_AFTER = table.Column<short>(type: "smallint", nullable: false),
                    QUANTITY_SOLD = table.Column<short>(type: "smallint", nullable: false),
                    PURCHASE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SALE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SALE_PRICE_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PROFIT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PROFIT_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TAX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TAX_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_EDITED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaleRecords_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentItems_ProductID",
                table: "PaymentItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRecords_ProductID",
                table: "PurchaseRecords",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleRecords_ProductID",
                table: "SaleRecords",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Payments_PAYMENT_ID",
                table: "PaymentItems",
                column: "PAYMENT_ID",
                principalTable: "Payments",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Products_ProductID",
                table: "PaymentItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_SaleRecords_SALE_RECORD_ID",
                table: "PaymentItems",
                column: "SALE_RECORD_ID",
                principalTable: "SaleRecords",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Companies_COMPANY_ID",
                table: "Payments",
                column: "COMPANY_ID",
                principalTable: "Companies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CUSTOMER_ID",
                table: "Payments",
                column: "CUSTOMER_ID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_INVOICE_ID",
                table: "Payments",
                column: "INVOICE_ID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Payments_PAYMENT_ID",
                table: "PaymentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_Products_ProductID",
                table: "PaymentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentItems_SaleRecords_SALE_RECORD_ID",
                table: "PaymentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Companies_COMPANY_ID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CUSTOMER_ID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_INVOICE_ID",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "PurchaseRecords");

            migrationBuilder.DropTable(
                name: "SaleRecords");

            migrationBuilder.DropIndex(
                name: "IX_PaymentItems_ProductID",
                table: "PaymentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "PaymentItems");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameColumn(
                name: "SALE_RECORD_ID",
                table: "PaymentItems",
                newName: "PRODUCT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentItems_SALE_RECORD_ID",
                table: "PaymentItems",
                newName: "IX_PaymentItems_PRODUCT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_INVOICE_ID",
                table: "Payment",
                newName: "IX_Payment_INVOICE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CUSTOMER_ID",
                table: "Payment",
                newName: "IX_Payment_CUSTOMER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_COMPANY_ID",
                table: "Payment",
                newName: "IX_Payment_COMPANY_ID");

            migrationBuilder.AddColumn<decimal>(
                name: "CURRENT_PROFIT",
                table: "PaymentItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CURRENT_PURCHASE_PRICE",
                table: "PaymentItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CURRENT_SALE_PRICE",
                table: "PaymentItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CURRENT_TAX",
                table: "PaymentItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QUANTITY_AFTER",
                table: "PaymentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QUANTITY_CURRENT",
                table: "PaymentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QUANTITY_IN_CART",
                table: "PaymentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TOTAL_PRICE",
                table: "PaymentItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "ID");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Invoices_INVOICE_ID",
                table: "Payment",
                column: "INVOICE_ID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Payment_PAYMENT_ID",
                table: "PaymentItems",
                column: "PAYMENT_ID",
                principalTable: "Payment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentItems_Products_PRODUCT_ID",
                table: "PaymentItems",
                column: "PRODUCT_ID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
