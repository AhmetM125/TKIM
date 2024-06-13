using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKIM.Infastracture.Migrations
{
    /// <inheritdoc />
    public partial class updatecompanyemailatr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "Companies");
        }
    }
}
