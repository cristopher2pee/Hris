using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "ClientReports");

            migrationBuilder.DropTable(
                name: "EmployeeDepartments");

            migrationBuilder.DropTable(
                name: "OtherReports");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("056e9a02-3874-48d6-a9a1-e6c605e7d5f5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0949cc0c-f3d2-461d-bcf1-8ec744655656"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("22a8e7df-1f51-465b-b5e5-cc3731301532"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("23875007-5a3a-4063-8ba0-8de91d225789"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("29502aff-680a-4c9e-bfa1-db4b6ad81608"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("46b5972a-1512-4d9e-8333-766b371b7f6b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4a397377-e534-40b5-8a9e-f7035705d90d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("53a218fb-b4fc-410c-b6ba-c708d216dce1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8224a4c0-7a9d-4955-8a09-18accb91e425"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("84e1b121-ee2d-48a2-aae2-fe21d839286c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("91be8fe9-d9fe-49b4-a5f3-8a932733b2af"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9f2494c5-8b08-4e28-9dee-4b593baaab23"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ab8ac133-f208-410d-8119-03c526649ac6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b748c453-7e16-473b-bcb6-4479919d3d14"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("beecadb1-773c-4a60-bc73-b991d48cde67"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c17fa3b2-1860-4a32-bef4-715ee5b7498d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e511005c-22db-4ee6-9be3-e4e5f01482de"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ef47922d-ae17-4145-aec0-5123bf750ece"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f09b8cae-796d-4bd9-9857-26a8bb49a6a3"));

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("07555a62-8e8c-4162-9d41-8a39b939958a"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2303), new Guid("5d6b4aa0-ef9e-4c3a-b391-d0c13735210b"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("0f371825-0208-4a63-ad01-ff7eaf186024"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2271), new Guid("770f77e2-c574-4d04-a076-391868d727ec"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("170c7f13-087d-4c33-b9aa-9dd20b92352b"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2296), new Guid("4c5bbcc3-af5b-49cb-b0c4-324b6d51d87c"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("23e6842a-26a1-4153-a164-3343b7b58545"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2309), new Guid("d08aead3-373f-4430-be4b-b08fb91002cf"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("2d4ba9ae-1549-40e1-8d48-b3cedfef6cab"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2264), new Guid("292ef55f-5dfc-4c5d-ae70-933c6b337982"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("35e1f9ba-b48d-4e1a-94dc-4bdba4010aaa"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2302), new Guid("74d5164b-0fe7-4a8f-9068-6fa9c3ecbee1"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("381f20bd-c684-4d50-bafd-fab15710c807"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2284), new Guid("0a9f3c2a-9100-4351-a7b7-64570df0bc2d"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("40fdddf9-d43d-42b3-a94f-49c3ca6edcd0"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2308), new Guid("5e52b6ab-e398-40e4-b891-8d856abf3500"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("4f230d6e-1488-49b4-b05e-31bbcc060e18"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2287), new Guid("7b1d5d2f-debd-4948-b97e-90499ddff86c"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("67f5b19d-dfb5-445d-988c-6756fbe31c92"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2286), new Guid("caaea997-85cc-4ec7-b317-4376daf30617"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("9a41eab1-9d5c-4899-b64b-8589056557d2"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2295), new Guid("47d61a9a-d8d4-407c-aad1-793dd35bdc8a"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("a55bbc78-81ca-4ac1-993e-7d8423d2111c"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2293), new Guid("c9748f95-042a-48e5-b239-c7e01b6955fb"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("af8ee477-1b8b-446c-b944-d72dfcf83d90"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2269), new Guid("7d86697c-2207-472f-a8aa-e5fb623279d4"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("c8ac7e78-056e-49ed-b90a-2917c54f9079"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2267), new Guid("88a7efa7-b8bb-4507-a208-12243c4eb1ce"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("cc3cdeb6-afbd-42f2-861f-4ab8dee51a00"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2307), new Guid("5adac70b-0116-48f0-88e2-69ee7612dfa2"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("d3d77e53-d03d-486b-afde-f64bd97a03bc"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2288), new Guid("f8482e66-7c17-48c8-a16b-0052e24811d6"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("da154543-6001-4fd4-b5bb-19bf76e988cd"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2299), new Guid("f88c3722-b779-416f-be43-7aa56c09eb09"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("e239a9e0-aad4-4cbb-9bb2-c86b9df5a646"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2301), new Guid("54c4eaa9-5cb9-4872-be2f-f15039f13cd3"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("e46ca2ef-352b-4257-b53f-018e30e3df07"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2292), new Guid("dd7f9e21-e55d-4558-8a8a-b04a0a6420c6"), "Clock", "Reports", "Reports", "Admin,Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_EmployeeId",
                table: "UserSettings",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_Employees_EmployeeId",
                table: "UserSettings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Employees_EmployeeId",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_EmployeeId",
                table: "UserSettings");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("07555a62-8e8c-4162-9d41-8a39b939958a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0f371825-0208-4a63-ad01-ff7eaf186024"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("170c7f13-087d-4c33-b9aa-9dd20b92352b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("23e6842a-26a1-4153-a164-3343b7b58545"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2d4ba9ae-1549-40e1-8d48-b3cedfef6cab"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("35e1f9ba-b48d-4e1a-94dc-4bdba4010aaa"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("381f20bd-c684-4d50-bafd-fab15710c807"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("40fdddf9-d43d-42b3-a94f-49c3ca6edcd0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4f230d6e-1488-49b4-b05e-31bbcc060e18"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("67f5b19d-dfb5-445d-988c-6756fbe31c92"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9a41eab1-9d5c-4899-b64b-8589056557d2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a55bbc78-81ca-4ac1-993e-7d8423d2111c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("af8ee477-1b8b-446c-b944-d72dfcf83d90"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c8ac7e78-056e-49ed-b90a-2917c54f9079"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cc3cdeb6-afbd-42f2-861f-4ab8dee51a00"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d3d77e53-d03d-486b-afde-f64bd97a03bc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("da154543-6001-4fd4-b5bb-19bf76e988cd"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e239a9e0-aad4-4cbb-9bb2-c86b9df5a646"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e46ca2ef-352b-4257-b53f-018e30e3df07"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientReports",
                columns: table => new
                {
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSeconds = table.Column<int>(type: "int", nullable: false),
                    TrackStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherReports",
                columns: table => new
                {
                    TotalSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("056e9a02-3874-48d6-a9a1-e6c605e7d5f5"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1742), new Guid("5ae3f6b2-c038-4050-8d4f-fb89fa970ce4"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("0949cc0c-f3d2-461d-bcf1-8ec744655656"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1747), new Guid("f374e755-d3a6-480e-b82d-b8a880ac9d93"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("22a8e7df-1f51-465b-b5e5-cc3731301532"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1782), new Guid("05739661-f796-4eda-90e6-a28ba3b131ea"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("23875007-5a3a-4063-8ba0-8de91d225789"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1685), new Guid("98d1f679-0ded-48bf-9ecf-ed946add1556"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("29502aff-680a-4c9e-bfa1-db4b6ad81608"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1799), new Guid("2561311d-f4c0-4961-a187-a602d74202b8"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("46b5972a-1512-4d9e-8333-766b371b7f6b"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1745), new Guid("6de23cc6-be81-4df3-bed2-7feb9949372b"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("4a397377-e534-40b5-8a9e-f7035705d90d"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1771), new Guid("17a537df-255c-4958-b418-b22a389ab1e5"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("53a218fb-b4fc-410c-b6ba-c708d216dce1"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1764), new Guid("f3977aac-2080-4802-964b-479328e1c03f"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("8224a4c0-7a9d-4955-8a09-18accb91e425"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1768), new Guid("594ab777-ac19-4488-ae8c-7ab4d06464e0"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("84e1b121-ee2d-48a2-aae2-fe21d839286c"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1766), new Guid("5a549f7d-26ec-4999-8f77-6adef5dec898"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("91be8fe9-d9fe-49b4-a5f3-8a932733b2af"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1801), new Guid("e10518e8-b4ca-4eec-a190-5699f24ed494"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("9f2494c5-8b08-4e28-9dee-4b593baaab23"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1778), new Guid("daa3c5e2-2de9-4f3c-8716-36dce3798361"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("ab8ac133-f208-410d-8119-03c526649ac6"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1780), new Guid("3db689ce-7a90-4373-9726-9e8e9ba0dc31"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("b748c453-7e16-473b-bcb6-4479919d3d14"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1792), new Guid("b828d24b-ad55-46f6-9ce1-8b4cd93c3dd9"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("beecadb1-773c-4a60-bc73-b991d48cde67"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1775), new Guid("423ed939-27d2-40cf-8b27-2189643d7e8b"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("c17fa3b2-1860-4a32-bef4-715ee5b7498d"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1803), new Guid("19a84dd0-d410-41aa-a588-4f4e61b6975d"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("e511005c-22db-4ee6-9be3-e4e5f01482de"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1790), new Guid("365d7945-e154-4815-8ee3-0774736afdca"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("ef47922d-ae17-4145-aec0-5123bf750ece"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1794), new Guid("7d9382b3-865b-445c-b618-9e75e9ec9ec1"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("f09b8cae-796d-4bd9-9857-26a8bb49a6a3"), true, new DateTime(2024, 1, 8, 5, 32, 23, 245, DateTimeKind.Utc).AddTicks(1788), new Guid("84b299fd-c7b8-4615-bc0f-ec4a4dd80496"), "Admin", "Access", "Access", "Admin,Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EmployeeId",
                table: "Teams",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_DepartmentId",
                table: "EmployeeDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_EmployeeId",
                table: "EmployeeDepartments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Employees_EmployeeId",
                table: "Teams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
