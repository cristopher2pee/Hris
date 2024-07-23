using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class removetableemployeestatutories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeStatutories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeStatutories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HDMFEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HDMFER = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PHICEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PHICER = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SSSEC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SSSEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SSSER = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatutories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeStatutories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeStatutories_TaxTable_TaxTableId",
                        column: x => x.TaxTableId,
                        principalTable: "TaxTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStatutories_EmployeeId",
                table: "EmployeeStatutories",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStatutories_TaxTableId",
                table: "EmployeeStatutories",
                column: "TaxTableId");
        }
    }
}
