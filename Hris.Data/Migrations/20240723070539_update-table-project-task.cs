using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetableprojecttask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Tasks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsCustom",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsCustom",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Tasks");
        }
    }
}
