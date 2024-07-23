using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablepayrollrunpaysummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayrollRunPaySummary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollRunId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeSheetsPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeSheetDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allowances = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Loan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThirteenMonthPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaveConversion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SSSER = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SSSEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SSSEC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PHICER = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PHICEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HDMFER = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HDMFEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxWitheld = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollRunPaySummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollRunPaySummary_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollRunPaySummary_PayrollRun_PayrollRunId",
                        column: x => x.PayrollRunId,
                        principalTable: "PayrollRun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollRunPaySummary_EmployeeId",
                table: "PayrollRunPaySummary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollRunPaySummary_PayrollRunId",
                table: "PayrollRunPaySummary",
                column: "PayrollRunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollRunPaySummary");
        }
    }
}
