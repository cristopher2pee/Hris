using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablepayrollruntimesheetsaddtwocolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is13MonthInclude",
                table: "PayrollRunTimeSheets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLeaveInclude",
                table: "PayrollRunTimeSheets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is13MonthInclude",
                table: "PayrollRunTimeSheets");

            migrationBuilder.DropColumn(
                name: "IsLeaveInclude",
                table: "PayrollRunTimeSheets");
        }
    }
}
