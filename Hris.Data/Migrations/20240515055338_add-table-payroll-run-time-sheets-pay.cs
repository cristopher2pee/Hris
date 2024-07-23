using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablepayrollruntimesheetspay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayrollRunTimeSheetsPay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollRunId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RDOnSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RDOnDSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RDOnRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RDOnDRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ODOnNSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnRD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnRDOnSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnRDOnDSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnRDOnRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnDRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDOnRDOnDRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ODOnOT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnRD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnRDOnSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnRDOnDSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnSHOnRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnRDOnRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnDRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnRDOnDRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ODOnOTOnNSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnRD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnRDOnSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnRDOnDSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnRDOnRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnDRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnRDOnDRH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoPayLeave = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Late = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSDonDSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOonDSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OTOnNSDOnDSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollRunTimeSheetsPay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollRunTimeSheetsPay_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollRunTimeSheetsPay_PayrollRun_PayrollRunId",
                        column: x => x.PayrollRunId,
                        principalTable: "PayrollRun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollRunTimeSheetsPay_EmployeeId",
                table: "PayrollRunTimeSheetsPay",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollRunTimeSheetsPay_PayrollRunId",
                table: "PayrollRunTimeSheetsPay",
                column: "PayrollRunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollRunTimeSheetsPay");
        }
    }
}
