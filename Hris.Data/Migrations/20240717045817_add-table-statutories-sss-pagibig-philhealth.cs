using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablestatutoriesssspagibigphilhealth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HDMFTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangeTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HDMFEE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HDMFER = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HDMFEEMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HDMFERMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDMFTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHICTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangeTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EEShare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ERShare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHICTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SSSTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangeTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ER = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSSTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HDMFTable");

            migrationBuilder.DropTable(
                name: "PHICTable");

            migrationBuilder.DropTable(
                name: "SSSTable");
        }
    }
}
