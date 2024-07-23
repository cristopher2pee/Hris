using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablepayrollrunaddapproveddate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "PayrollRun",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "PayrollRun");
        }
    }
}
