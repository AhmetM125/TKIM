using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class updatenameofbaskettopayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PERSON_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TOTAL_TAX = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TOTAL_DISCOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TOTAL_PAYMENT = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    InsertUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRODUCT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTITY_IN_CART = table.Column<int>(type: "int", nullable: false),
                    QUANTITY_AFTER = table.Column<int>(type: "int", nullable: false),
                    QUANTITY_CURRENT = table.Column<int>(type: "int", nullable: false),
                    CURRENT_PURCHASE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURRENT_SALE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURRENT_PROFIT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURRENT_TAX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BASKET_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentItems_Payment_BASKET_ID",
                        column: x => x.BASKET_ID,
                        principalTable: "Payment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PersonID",
                table: "Payment",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentItems_BASKET_ID",
                table: "PaymentItems",
                column: "BASKET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentItems_ProductID",
                table: "PaymentItems",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentItems");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PERSON_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TOTAL_DISCOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TOTAL_PAYMENT = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TOTAL_TAX = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Basket_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BASKET_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CURRENT_PROFIT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURRENT_PURCHASE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURRENT_SALE_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CURRENT_TAX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PRODUCT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTITY_AFTER = table.Column<int>(type: "int", nullable: false),
                    QUANTITY_CURRENT = table.Column<int>(type: "int", nullable: false),
                    QUANTITY_IN_CART = table.Column<int>(type: "int", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BasketItems_Basket_BASKET_ID",
                        column: x => x.BASKET_ID,
                        principalTable: "Basket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_PersonID",
                table: "Basket",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BASKET_ID",
                table: "BasketItems",
                column: "BASKET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductID",
                table: "BasketItems",
                column: "ProductID");
        }
    }
}
