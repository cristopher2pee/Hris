using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumntableallowancetypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTaxale",
                table: "AllowanceTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Limit",
                table: "AllowanceTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTaxale",
                table: "AllowanceTypes");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "AllowanceTypes");
        }
    }
}
