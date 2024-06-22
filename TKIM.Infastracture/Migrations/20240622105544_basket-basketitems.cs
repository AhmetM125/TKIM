using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class basketbasketitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "SECURITY_ID",
                table: "People",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Basket",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropColumn(
                name: "SECURITY_ID",
                table: "People");

            migrationBuilder.CreateTable(
                name: "InvoiceProduct",
                columns: table => new
                {
                    InvoicesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProduct", x => new { x.InvoicesID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_Invoices_InvoicesID",
                        column: x => x.InvoicesID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProduct_ProductsID",
                table: "InvoiceProduct",
                column: "ProductsID");
        }
    }
}
