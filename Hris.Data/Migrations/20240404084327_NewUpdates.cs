using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("027860c2-edcb-4e4b-952b-37ccac68e9c1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1e7fa783-155b-4962-bd60-d09e8ef46abd"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("24c1667e-d8ab-4c21-8539-99d6290d4c0d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("425d45b4-53a9-43da-b807-3754ba684933"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("45bc0de3-6c19-4f82-88f6-d01cdd397f44"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("46b86e9c-5e53-4c36-adf3-0c49990b0157"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4d2cb972-1dd5-495c-b7e4-325c4a729cd7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6ee89124-cf60-45fd-82e0-34911015b49f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("74a2e7ae-3494-4678-9a62-617198dadf15"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7b8d24d7-3205-49ba-9d72-e56b2cbc6db6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("88211b11-59d0-4ecd-9034-66c66514efa3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8d0e3d08-c00a-4e93-b97c-2cfa88e2b53e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8f01c799-96ef-4f92-9cce-5c464cfb84b2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("941e0eed-e459-4a6c-9cfc-13d6f248f7fb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a87012e3-471f-4bc7-ad51-0169622820db"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aad02ea1-d0b5-4397-988d-66f5c32177ac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c45e3edd-08d4-40e0-bff3-5d57b16c5138"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e09700a5-062e-4c8d-adc7-c2a83c00a1e1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f115f5bc-8bfe-4855-a3e9-48ec5f9e833f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("feea863b-b9c0-4309-ac82-2a8b419c0e48"));

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "EmployeeStatutories");

            migrationBuilder.AlterColumn<decimal>(
                name: "SSSER",
                table: "EmployeeStatutories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SSSEE",
                table: "EmployeeStatutories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SSSEC",
                table: "EmployeeStatutories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PHICER",
                table: "EmployeeStatutories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PHICEE",
                table: "EmployeeStatutories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "HDMFER",
                table: "EmployeeStatutories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "HDMFEE",
                table: "EmployeeStatutories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxTableId",
                table: "EmployeeStatutories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShiftSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeIn = table.Column<int>(type: "int", nullable: false),
                    TimeOut = table.Column<int>(type: "int", nullable: false),
                    BreakTime = table.Column<int>(type: "int", nullable: false),
                    RestDays = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangeTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("03054d48-3a11-4854-942f-576eeb8cbf79"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5367), new Guid("b05ae7b3-a226-46a5-977a-8b5ade6f6fa3"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("0c70df34-7580-4b20-8cc6-9212164e42f2"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5364), new Guid("7a92fa3d-e529-4f6a-b7ca-91326daa8a32"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("10f83735-b379-4112-bd0d-6774a58f8b43"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5342), new Guid("dd6294b8-64b9-4f6a-b904-a4bb3b255bc6"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("11f7da03-cb7e-4877-acce-94ff1eb76813"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5362), new Guid("6e72ad72-9aec-47fa-8382-f3f08eb40d9f"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("19e6bcb3-0b88-4993-ac96-7b92b6c3268d"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5350), new Guid("22319b2f-e99a-4c30-a805-639b0b8bdddf"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("20eff6d9-5c8d-46f0-a5fa-0e145a9ebad9"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5351), new Guid("d8dd9834-588b-41d3-a263-8ba2eaf81ce2"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("2d705371-cb35-42c0-9dbc-c409078f3418"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5358), new Guid("86cab6fa-25f6-4dcf-b627-7c272ce1c014"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("31d8f427-64a0-49ef-82c5-0b49f805a42a"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5356), new Guid("2add908c-9597-423b-a22c-43e2c7e83b61"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("45f08d90-f099-440b-8a6e-d569d26da1ac"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5365), new Guid("6350b4b0-ef92-493b-ade8-d806dd11882a"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("55073a09-42c1-4b8c-9263-fe359a79c6a2"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5330), new Guid("ea6dae29-87bc-44fe-9ce0-1bf19cbd8fe9"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("5b49a5f7-2eab-46c4-89c7-c0e7d3375a04"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5344), new Guid("d31a3c95-6b92-4c65-aeb4-b12650e1a124"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("870c9b6f-206f-429b-9ba6-b250de07b0eb"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5316), new Guid("ba45a5c8-1ba5-4c7c-b8bd-004adb264186"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("99dc6029-685c-4f3b-8799-20ca496d5800"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5347), new Guid("29e9fb31-bbb2-4ba4-834e-414888c926a5"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("9a326a4d-e72c-4a39-a0e8-ffd858757613"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5339), new Guid("f38a567b-2979-48f3-8091-b03c64c139bf"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("abf233e1-75cc-4414-8eb7-95eaea9c311e"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5317), new Guid("e5a52a93-2459-418f-ba0a-7c9f5ba2faa7"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("b407da2a-9248-4e27-95a7-696f984fcc3a"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5348), new Guid("c9297416-ecfc-40fa-a832-1b66e1367acf"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("ba7f319a-9844-4cbb-9011-ca72910b2ad0"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5355), new Guid("1abe06e5-1a45-4b5f-b16b-26345efde1c9"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("c38d741e-2f55-49d2-8094-99cabc8ebc3a"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5314), new Guid("a0a3017c-afbb-47c8-b118-cbf0c38f8767"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("c5e27785-dd09-420c-8012-b9a5f669f777"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5334), new Guid("19ff400d-aa16-4eaa-8a60-c3f4fe88901b"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("cc92f152-2cb7-448d-9fe1-125004698818"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5335), new Guid("c63c7ed0-137f-4f4f-abbd-7348843b35ec"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("e01b7ff2-5077-4a08-b327-339f35130343"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5310), new Guid("42795727-1e4d-4c18-915b-4b4168a46170"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("eafacb1a-f3e1-4b85-bc48-1152842169fe"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5332), new Guid("0a9addeb-d4f5-404d-9685-5d4f21cdb612"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("f0f434a4-496f-422e-a9be-c907cc0982e9"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5341), new Guid("40e3446a-976d-46d9-9fb0-e32e0e9c07f3"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("fe3f1ce4-64e2-4f55-88f5-b34c5d3089a5"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5359), new Guid("147168fa-b948-4e6f-83cb-c7c7baba40c8"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStatutories_TaxTableId",
                table: "EmployeeStatutories",
                column: "TaxTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeStatutories_TaxTable_TaxTableId",
                table: "EmployeeStatutories",
                column: "TaxTableId",
                principalTable: "TaxTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeStatutories_TaxTable_TaxTableId",
                table: "EmployeeStatutories");

            migrationBuilder.DropTable(
                name: "ShiftSchedules");

            migrationBuilder.DropTable(
                name: "TaxTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeStatutories_TaxTableId",
                table: "EmployeeStatutories");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("03054d48-3a11-4854-942f-576eeb8cbf79"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0c70df34-7580-4b20-8cc6-9212164e42f2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("10f83735-b379-4112-bd0d-6774a58f8b43"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("11f7da03-cb7e-4877-acce-94ff1eb76813"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("19e6bcb3-0b88-4993-ac96-7b92b6c3268d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("20eff6d9-5c8d-46f0-a5fa-0e145a9ebad9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2d705371-cb35-42c0-9dbc-c409078f3418"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("31d8f427-64a0-49ef-82c5-0b49f805a42a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("45f08d90-f099-440b-8a6e-d569d26da1ac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("55073a09-42c1-4b8c-9263-fe359a79c6a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5b49a5f7-2eab-46c4-89c7-c0e7d3375a04"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("870c9b6f-206f-429b-9ba6-b250de07b0eb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("99dc6029-685c-4f3b-8799-20ca496d5800"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9a326a4d-e72c-4a39-a0e8-ffd858757613"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("abf233e1-75cc-4414-8eb7-95eaea9c311e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b407da2a-9248-4e27-95a7-696f984fcc3a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ba7f319a-9844-4cbb-9011-ca72910b2ad0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c38d741e-2f55-49d2-8094-99cabc8ebc3a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c5e27785-dd09-420c-8012-b9a5f669f777"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cc92f152-2cb7-448d-9fe1-125004698818"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e01b7ff2-5077-4a08-b327-339f35130343"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("eafacb1a-f3e1-4b85-bc48-1152842169fe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f0f434a4-496f-422e-a9be-c907cc0982e9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fe3f1ce4-64e2-4f55-88f5-b34c5d3089a5"));

            migrationBuilder.DropColumn(
                name: "TaxTableId",
                table: "EmployeeStatutories");

            migrationBuilder.AlterColumn<string>(
                name: "SSSER",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "SSSEE",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "SSSEC",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PHICER",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PHICEE",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "HDMFER",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "HDMFEE",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "EmployeeStatutories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("027860c2-edcb-4e4b-952b-37ccac68e9c1"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9430), new Guid("c6983697-f146-432c-9296-838779bd13a5"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("1e7fa783-155b-4962-bd60-d09e8ef46abd"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9440), new Guid("7edab38f-bd62-44c7-92dd-5e111acb0a68"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("24c1667e-d8ab-4c21-8539-99d6290d4c0d"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9417), new Guid("ec24438f-1bd4-48bb-b4e5-2a6b7c703311"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("425d45b4-53a9-43da-b807-3754ba684933"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9437), new Guid("69fb48c5-29c5-4a6b-9121-c0ef8a9a91ca"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("45bc0de3-6c19-4f82-88f6-d01cdd397f44"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9414), new Guid("2eaf8f9a-feb6-4a73-9160-01c6afdf28d5"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("46b86e9c-5e53-4c36-adf3-0c49990b0157"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9425), new Guid("bc90bfec-753f-4b1c-83ca-fc85109b6eb2"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("4d2cb972-1dd5-495c-b7e4-325c4a729cd7"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9420), new Guid("03544d5c-33da-414f-a103-790c08b9acbb"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("6ee89124-cf60-45fd-82e0-34911015b49f"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9407), new Guid("427d7507-59c3-4185-8e0a-2987b35c9cfd"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("74a2e7ae-3494-4678-9a62-617198dadf15"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9391), new Guid("74c48cc1-5d12-44f4-808f-08f4a16d26c1"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("7b8d24d7-3205-49ba-9d72-e56b2cbc6db6"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9422), new Guid("2b256d8c-2c35-4373-888a-d0ac329c7acc"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("88211b11-59d0-4ecd-9034-66c66514efa3"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9419), new Guid("06caa817-34af-4695-910f-b8515f8e45a9"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("8d0e3d08-c00a-4e93-b97c-2cfa88e2b53e"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9433), new Guid("1594ac09-97a0-4753-9797-20544397d531"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("8f01c799-96ef-4f92-9cce-5c464cfb84b2"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9436), new Guid("b2c4b433-178f-48a3-bb88-2b7f6ed5d53a"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("941e0eed-e459-4a6c-9cfc-13d6f248f7fb"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9434), new Guid("bd984f0f-3743-4b45-b26f-8e56a6b90814"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("a87012e3-471f-4bc7-ad51-0169622820db"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9428), new Guid("95a133d0-f263-4fe0-af12-ebf2a9e932ec"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("aad02ea1-d0b5-4397-988d-66f5c32177ac"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9385), new Guid("b8f2932c-aa2a-4c64-bcf5-004a5e08d106"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("c45e3edd-08d4-40e0-bff3-5d57b16c5138"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9393), new Guid("9d2b649a-ff05-4d1c-9741-2fc7e418eb5d"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("e09700a5-062e-4c8d-adc7-c2a83c00a1e1"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9409), new Guid("e6c2f8d9-f050-4e20-8354-3dd0040856c4"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("f115f5bc-8bfe-4855-a3e9-48ec5f9e833f"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9412), new Guid("050204b7-e3d2-4d5d-b72e-da96d0d2ee80"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("feea863b-b9c0-4309-ac82-2a8b419c0e48"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9427), new Guid("9be2e615-0bbb-42e5-b9f1-1358353c2eda"), "Admin", "Access", "Access", "Admin,Manager" }
                });
        }
    }
}
