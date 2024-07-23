using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablepayrollruntimesheetspayralatedtoovertime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTOonDSH",
                table: "PayrollRunTimeSheetsPay",
                newName: "OTOnRH");

            migrationBuilder.RenameColumn(
                name: "OTOnSHOnRH",
                table: "PayrollRunTimeSheetsPay",
                newName: "OTOnDSH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTOnRH",
                table: "PayrollRunTimeSheetsPay",
                newName: "OTOonDSH");

            migrationBuilder.RenameColumn(
                name: "OTOnDSH",
                table: "PayrollRunTimeSheetsPay",
                newName: "OTOnSHOnRH");
        }
    }
}
