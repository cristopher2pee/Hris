using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumntableallowancetypes_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsTaxale",
                table: "AllowanceTypes",
                newName: "IsTaxable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsTaxable",
                table: "AllowanceTypes",
                newName: "IsTaxale");
        }
    }
}
