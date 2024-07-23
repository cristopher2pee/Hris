using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablefieldsonpayrolltimesheets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NSDonDSH",
                table: "PayrollRunTimeSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OTOnNSDOnDSH",
                table: "PayrollRunTimeSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OTOonDSH",
                table: "PayrollRunTimeSheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NSDonDSH",
                table: "PayrollRunTimeSheets");

            migrationBuilder.DropColumn(
                name: "OTOnNSDOnDSH",
                table: "PayrollRunTimeSheets");

            migrationBuilder.DropColumn(
                name: "OTOonDSH",
                table: "PayrollRunTimeSheets");
        }
    }
}
