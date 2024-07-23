using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtableloantypeandemployeeloan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("066425dd-f06c-4037-83a9-dae7c9d8bfd2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0b6b9819-7695-4d9e-82db-3196f9189b20"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0e35376f-6597-4f00-b4cd-bb7602dd1fa8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0eb09eaf-6834-4f39-8b59-2916231714ab"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("175bfb82-5da5-4674-b910-7b8a7e578d23"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("26c5b510-8c97-4c93-8b54-5adeea491c64"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2e0a8c5b-a29d-4e44-8705-89f6b9428c64"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2f2e47b9-62d8-4241-afca-56bd1d59c011"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4678e1a1-06fe-45c9-8e99-c5486c3fc917"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4e5c3493-f705-4e0a-a832-0cad591bcfe4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("69b93c8f-2e75-4e23-919c-bad0b3f97699"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("69bc684e-7519-4a39-88ea-39e988e54b66"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7896ca87-1f88-45d5-9dbc-85f57e784e23"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("96938c1a-be4f-44cf-a23f-58d6c578f5e3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("96c6a0c1-304e-4733-a4fc-d9a431f3bfa5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("985c41e4-8674-47d0-874f-f03b248aaa05"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a0773279-09a6-442a-b35a-f8349f811ae0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a70f42bb-14d5-495e-81df-e426a6073c23"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("addb26ca-c553-4670-a8c4-233663eef9c5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ade5c215-69ba-4ad2-a7b4-d216b61b2e51"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b7c28212-1bad-4ed0-ad9f-34d0df913869"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b7f132d0-be41-41d8-b697-902d80416269"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c7261c3f-7837-4ed2-a0b0-55349e8c7129"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c89f8a4b-76ad-473b-9a98-7512e7dd4508"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f6009e63-b1c0-4493-9dbc-313f33df7998"));

            migrationBuilder.CreateTable(
                name: "LoanTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLoans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amortization = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLoans_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLoans_LoanTypes_LoanTypesId",
                        column: x => x.LoanTypesId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("19a4893d-d7e6-4135-ba59-00744790cb5a"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4333), new Guid("a734ffa7-9723-42fa-abf4-22316010ab8a"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("20e40585-2376-4336-9d93-773906c587d3"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4340), new Guid("73c4fdbe-7d18-46ef-b340-1089831e46c4"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("2c9a9e09-8b79-454c-969e-f00521a562c3"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4348), new Guid("643143d7-6a5f-4544-be16-b7c64b63440c"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("30718e0a-7e92-41bc-a7f4-17a347822dea"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4354), new Guid("99f61cb7-0b0a-4ca9-9346-294a790d5b59"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("344bd938-4248-4fa5-9775-08c2b2042d1f"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4308), new Guid("044de1f0-56ab-4c0b-b8d5-b245e47338fe"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("3678435d-1506-41d6-8842-c19382961313"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4323), new Guid("87a97ae7-c6cf-4dde-a57b-c9013897d8b9"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("39caa9ae-2efb-4a1d-884b-8369760363ae"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4359), new Guid("bf91fe60-af53-4937-b2ae-cf063acece2f"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("452becc0-b317-408e-8f74-7543a0345e37"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4325), new Guid("7096d240-dcd3-4bc8-b8fe-f939e3090d80"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("494accbd-6135-4958-8bbb-2532e920392c"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4307), new Guid("2137de70-7068-4cfd-859f-9eb032f2ce57"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("4ed3a145-28a4-44cc-94f2-2887c0a00f1d"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4300), new Guid("1ff13234-8b30-40c8-bd29-b4b2b1704a82"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("5c7451e0-0056-4d74-be22-9fb022c35520"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4347), new Guid("823cbd42-7fc4-466c-acd1-7081e8f9cdc8"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("6566823b-f6f7-4140-9177-774aee542996"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4331), new Guid("7b3d6ee0-e71e-47a8-9dcb-cede0bd217ca"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("65dd4c8b-5934-4b92-b927-e162e8b20c56"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4338), new Guid("9c46f36c-1c41-4b41-805e-e0f6ba33cc95"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("6ff7df1b-930c-40ce-8bfb-4c980f15c350"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4324), new Guid("32712940-c24c-488d-ad59-ab2ed50fa777"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("761aac20-ccf4-4ddc-a3c7-b62e9b2d1255"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4334), new Guid("886f9b7c-5621-4af4-a2eb-151cb13d7a60"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("7ba81fad-952f-44e3-b67a-8cfcd5758fef"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4351), new Guid("330bf545-3bd8-44af-97da-7d57b20bc99a"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("7d23cdee-57e6-4b94-8519-617a4bc25cb2"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4330), new Guid("08067c1d-466c-4942-aeaf-64080af1bfb8"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("93ee9c91-6741-4bff-8779-f95d9d0a5e58"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4337), new Guid("2c6aa014-5ba4-473d-ac9c-9681b3f2357d"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("9582a228-8c8f-4814-a0f0-f831af4aab8a"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4356), new Guid("bb7fe451-02fb-4fc9-965c-6ab1405c1d07"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("a818b9a9-7434-41af-a549-7abc9ec6fc69"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4327), new Guid("b0735339-869a-4e02-bb06-09b9c3af7885"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("aaed3522-f2d9-48f9-99dc-cbfe9f679f02"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4355), new Guid("47e2d9bb-ed43-4b43-a351-7c276b028c8d"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("aaf7cfc0-7a27-4a80-b621-c529d3a04975"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4345), new Guid("009f4796-ddea-419c-84d5-2b5a22141b29"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("bfca7f1c-12d0-4cd6-b9b5-1d7ea1370ae7"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4341), new Guid("99a08085-5cea-4168-85ad-7c907e0c75c5"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("d9907014-8c38-4ffb-8be9-1cf472ae6184"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4344), new Guid("943f395f-6794-465e-a656-cbbbea31f9f9"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("ee08d2e9-e8e1-4c4d-8aaa-f0c151d3fc4a"), true, new DateTime(2024, 4, 16, 10, 6, 40, 775, DateTimeKind.Utc).AddTicks(4310), new Guid("d2871d40-4c62-4ef2-9de8-58bcb9f6a648"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLoans_EmployeeId",
                table: "EmployeeLoans",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLoans_LoanTypesId",
                table: "EmployeeLoans",
                column: "LoanTypesId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLoans");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "LoanTypes");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("19a4893d-d7e6-4135-ba59-00744790cb5a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("20e40585-2376-4336-9d93-773906c587d3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2c9a9e09-8b79-454c-969e-f00521a562c3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("30718e0a-7e92-41bc-a7f4-17a347822dea"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("344bd938-4248-4fa5-9775-08c2b2042d1f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3678435d-1506-41d6-8842-c19382961313"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("39caa9ae-2efb-4a1d-884b-8369760363ae"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("452becc0-b317-408e-8f74-7543a0345e37"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("494accbd-6135-4958-8bbb-2532e920392c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4ed3a145-28a4-44cc-94f2-2887c0a00f1d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5c7451e0-0056-4d74-be22-9fb022c35520"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6566823b-f6f7-4140-9177-774aee542996"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("65dd4c8b-5934-4b92-b927-e162e8b20c56"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6ff7df1b-930c-40ce-8bfb-4c980f15c350"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("761aac20-ccf4-4ddc-a3c7-b62e9b2d1255"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7ba81fad-952f-44e3-b67a-8cfcd5758fef"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7d23cdee-57e6-4b94-8519-617a4bc25cb2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("93ee9c91-6741-4bff-8779-f95d9d0a5e58"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9582a228-8c8f-4814-a0f0-f831af4aab8a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a818b9a9-7434-41af-a549-7abc9ec6fc69"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aaed3522-f2d9-48f9-99dc-cbfe9f679f02"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aaf7cfc0-7a27-4a80-b621-c529d3a04975"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bfca7f1c-12d0-4cd6-b9b5-1d7ea1370ae7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d9907014-8c38-4ffb-8be9-1cf472ae6184"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ee08d2e9-e8e1-4c4d-8aaa-f0c151d3fc4a"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("066425dd-f06c-4037-83a9-dae7c9d8bfd2"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9678), new Guid("3fa5d3a6-f111-4b7e-a95d-ca849411e955"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("0b6b9819-7695-4d9e-82db-3196f9189b20"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9645), new Guid("fcb0154f-e31c-4850-bdb0-109d47a9df82"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("0e35376f-6597-4f00-b4cd-bb7602dd1fa8"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9643), new Guid("ad8ac4f5-7519-4dca-9b22-dfd13c013cf9"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("0eb09eaf-6834-4f39-8b59-2916231714ab"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9621), new Guid("c90a843e-92de-46e6-a9fa-df8cffc14b86"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("175bfb82-5da5-4674-b910-7b8a7e578d23"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9639), new Guid("cb35f73b-81e5-4b7c-b89c-152f4dcb17a2"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("26c5b510-8c97-4c93-8b54-5adeea491c64"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9661), new Guid("2be9c019-8942-4e1a-a4e2-8da8536b0b82"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("2e0a8c5b-a29d-4e44-8705-89f6b9428c64"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9654), new Guid("18a9ae26-f40d-426a-9a59-97b28adb1eab"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("2f2e47b9-62d8-4241-afca-56bd1d59c011"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9632), new Guid("39934978-7737-46f2-8953-c5fd7c878663"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("4678e1a1-06fe-45c9-8e99-c5486c3fc917"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9676), new Guid("1dc438fb-2bd8-415a-80d1-4130b85291c4"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("4e5c3493-f705-4e0a-a832-0cad591bcfe4"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9641), new Guid("c5b51c39-41b1-4f8c-93b4-c9f37d672002"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("69b93c8f-2e75-4e23-919c-bad0b3f97699"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9663), new Guid("8be6ccf2-362f-4424-a597-60b0a8406045"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("69bc684e-7519-4a39-88ea-39e988e54b66"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9674), new Guid("3e751213-029f-47bd-85e0-35e000bd6028"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("7896ca87-1f88-45d5-9dbc-85f57e784e23"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9652), new Guid("186db636-8db1-42fc-a65e-6306ea15ffc5"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("96938c1a-be4f-44cf-a23f-58d6c578f5e3"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9628), new Guid("08edca5e-0bf2-46d9-bdac-886229e4399b"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("96c6a0c1-304e-4733-a4fc-d9a431f3bfa5"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9598), new Guid("a1025cb9-e475-4dc2-a614-da779eb77e6b"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("985c41e4-8674-47d0-874f-f03b248aaa05"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9666), new Guid("20a54429-e5cc-4c9f-bdf8-f2f842d202ed"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("a0773279-09a6-442a-b35a-f8349f811ae0"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9623), new Guid("82e7db71-94f7-44a5-93a9-9f0061f60017"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("a70f42bb-14d5-495e-81df-e426a6073c23"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9634), new Guid("78cfd22a-8e48-435e-ad9f-e9b78b9b5efc"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("addb26ca-c553-4670-a8c4-233663eef9c5"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9616), new Guid("cba3456f-c37d-4d57-a603-98732d3ef67d"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("ade5c215-69ba-4ad2-a7b4-d216b61b2e51"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9619), new Guid("a022031a-0083-4a9c-91bc-a3d25138ab66"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("b7c28212-1bad-4ed0-ad9f-34d0df913869"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9672), new Guid("8d100e49-dba7-4dd5-816c-8a4b6a8f36cb"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("b7f132d0-be41-41d8-b697-902d80416269"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9668), new Guid("4373bcd2-fdc4-470f-a358-b3cfa42f632f"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("c7261c3f-7837-4ed2-a0b0-55349e8c7129"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9630), new Guid("e54e1086-86d7-40e7-9448-417bcc2d363d"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("c89f8a4b-76ad-473b-9a98-7512e7dd4508"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9656), new Guid("7571610d-7ac9-41b3-918d-f4c13d6285df"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("f6009e63-b1c0-4493-9dbc-313f33df7998"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9650), new Guid("033a43f7-895a-46e8-b598-cc113ce073a3"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" }
                });
        }
    }
}
