using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class category_isactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "Categories");
        }
    }
}
