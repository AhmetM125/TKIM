using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class company_inuse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "Companies");
        }
    }
}
