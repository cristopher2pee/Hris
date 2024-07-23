using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablepayrollruntimesheetsralatedtoovertime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTOonDSH",
                table: "PayrollRunTimeSheets",
                newName: "OTOnRH");

            migrationBuilder.RenameColumn(
                name: "OTOnSHOnRH",
                table: "PayrollRunTimeSheets",
                newName: "OTOnDSH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTOnRH",
                table: "PayrollRunTimeSheets",
                newName: "OTOonDSH");

            migrationBuilder.RenameColumn(
                name: "OTOnDSH",
                table: "PayrollRunTimeSheets",
                newName: "OTOnSHOnRH");
        }
    }
}
