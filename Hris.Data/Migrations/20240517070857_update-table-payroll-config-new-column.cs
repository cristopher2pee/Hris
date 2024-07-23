using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablepayrollconfignewcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeaveConversionId",
                table: "PayrollConfig",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxTypePeriod",
                table: "PayrollConfig",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ThirteenMonthId",
                table: "PayrollConfig",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollConfig_LeaveConversionId",
                table: "PayrollConfig",
                column: "LeaveConversionId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollConfig_ThirteenMonthId",
                table: "PayrollConfig",
                column: "ThirteenMonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollConfig_AllowanceTypes_LeaveConversionId",
                table: "PayrollConfig",
                column: "LeaveConversionId",
                principalTable: "AllowanceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollConfig_AllowanceTypes_ThirteenMonthId",
                table: "PayrollConfig",
                column: "ThirteenMonthId",
                principalTable: "AllowanceTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollConfig_AllowanceTypes_LeaveConversionId",
                table: "PayrollConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollConfig_AllowanceTypes_ThirteenMonthId",
                table: "PayrollConfig");

            migrationBuilder.DropIndex(
                name: "IX_PayrollConfig_LeaveConversionId",
                table: "PayrollConfig");

            migrationBuilder.DropIndex(
                name: "IX_PayrollConfig_ThirteenMonthId",
                table: "PayrollConfig");

            migrationBuilder.DropColumn(
                name: "LeaveConversionId",
                table: "PayrollConfig");

            migrationBuilder.DropColumn(
                name: "TaxTypePeriod",
                table: "PayrollConfig");

            migrationBuilder.DropColumn(
                name: "ThirteenMonthId",
                table: "PayrollConfig");
        }
    }
}
