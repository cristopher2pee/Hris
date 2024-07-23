using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablepayrollconfigandconfigdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "PayrollConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<int>(type: "int", nullable: false),
                    FromDay = table.Column<int>(type: "int", nullable: false),
                    ToDay = table.Column<int>(type: "int", nullable: false),
                    PayOutDay = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollConfigDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollConfigDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollConfigDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollConfigDetails_PayrollConfig_PayrollConfigId",
                        column: x => x.PayrollConfigId,
                        principalTable: "PayrollConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("028f5ac6-1dea-409f-a2d7-0b2f82b32975"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3739), new Guid("d7d73b06-de12-4098-bcf0-6add134e3e09"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("0a3b289d-dc29-49a7-97f0-fa8e0d1c860d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3760), new Guid("2bf19ba0-2d9c-49ef-a0f5-1ab6f60a6b91"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("0faf914e-2e64-4c0f-b048-0b863111a65c"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3737), new Guid("5770ea8d-b24b-4f48-bfc2-99012083d287"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("16d7a854-7ac6-4b60-bf93-4700ec1a4d3d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3755), new Guid("8ea670e0-4fd3-4d61-a87a-d9f078ec6f49"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("23b3725b-8cd5-4ef9-aa1f-a2c3bec1ef5c"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3763), new Guid("a8f2d59f-40f9-48f8-85e2-7d83141e6166"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("26d6c661-0956-410a-9609-aea6eef0fde4"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3750), new Guid("83ccccce-5bb8-4fab-83bf-d3106bb1b35d"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("396816a4-40f0-49d0-bf71-a59d69c31087"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3747), new Guid("bac20b3f-7922-4cdd-b938-b1ee646fffa2"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("3c861374-e1bb-4abf-aad1-42092e51b35d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3767), new Guid("5a7692df-2654-4581-be9e-a225b2ab052d"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("4528d699-eebc-41b5-bc33-f0a74f8d36b5"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3733), new Guid("1fe8d201-f8cd-43d9-a057-57c0bff7d247"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("467b2d96-77c2-423e-b934-69e3ef43d533"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3745), new Guid("001b2639-e97a-4f4b-98d3-ba54d1188666"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("48742a75-b0ed-4e61-8b52-e607a46fe29b"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3773), new Guid("0df57083-4a83-4886-84e3-f4db21cd3980"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("58414145-14d4-4f85-84b2-b290b93eaad5"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3752), new Guid("dbd49501-a465-4bdf-906c-0b958f540caa"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("6c5898a3-f7d4-46ca-b0b1-bfeb0290bda5"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3754), new Guid("148177f6-38ec-4691-ae86-009b14e8cc38"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("6f38c8f2-2ef1-4c93-ae03-71645cd5ba2d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3667), new Guid("192e5e36-f43e-4c19-a3f6-392a980c6295"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("71446120-3d4b-4a1d-b8a7-c2ec7b469a0e"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3744), new Guid("feb4e0a8-1943-45d4-8428-59e371ee8e43"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("781e6b12-993f-4f79-9a26-0fde36e88ad1"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3775), new Guid("db8e6fb0-e6fb-4afb-8ceb-391410ef3079"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("80b981b1-1e80-4c69-b3d7-d4cad5d7a002"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3770), new Guid("66a3c6b6-5dc8-4b24-9589-fd5ad741c495"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("85adafb6-5d09-4b4a-90a4-a61257522443"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3672), new Guid("b9758710-fd4d-4c34-b986-2ec1faa1729a"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("8bb8a91f-4a47-427a-bc28-3f7e802aa8a2"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3768), new Guid("b7e5ff48-00e7-452e-81bf-aec8512687f2"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("98984bbc-865b-4584-8003-af21254c3c9c"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3761), new Guid("7ae9324b-eb27-467e-9b3a-638605f9ab21"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("bd0c89de-338d-4c59-a56f-bbf81daabe52"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3776), new Guid("f663c79e-a1f7-4c4d-9565-7c740e093526"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("daf85a9a-f7b3-4577-b279-876e82b20eb8"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3742), new Guid("c1de185c-acf8-4e63-a222-c8737fdea530"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("f4163527-bd77-4fbf-a563-bc11bfea62b6"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3735), new Guid("d3877e3f-4e03-48c5-9410-52ebb81a935e"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("f70a250b-1eba-4170-822b-8ae1f6da878e"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3758), new Guid("58fce9ea-c85f-47ec-95d4-3db6e18063d3"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("f7b2106d-c7a8-4922-966f-99d573640ded"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3766), new Guid("715040a5-3d38-468b-987b-31f32f5a198b"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollConfigDetails_EmployeeId",
                table: "PayrollConfigDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollConfigDetails_PayrollConfigId",
                table: "PayrollConfigDetails",
                column: "PayrollConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollConfigDetails");

            migrationBuilder.DropTable(
                name: "PayrollConfig");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("028f5ac6-1dea-409f-a2d7-0b2f82b32975"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a3b289d-dc29-49a7-97f0-fa8e0d1c860d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0faf914e-2e64-4c0f-b048-0b863111a65c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("16d7a854-7ac6-4b60-bf93-4700ec1a4d3d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("23b3725b-8cd5-4ef9-aa1f-a2c3bec1ef5c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("26d6c661-0956-410a-9609-aea6eef0fde4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("396816a4-40f0-49d0-bf71-a59d69c31087"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3c861374-e1bb-4abf-aad1-42092e51b35d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4528d699-eebc-41b5-bc33-f0a74f8d36b5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("467b2d96-77c2-423e-b934-69e3ef43d533"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("48742a75-b0ed-4e61-8b52-e607a46fe29b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("58414145-14d4-4f85-84b2-b290b93eaad5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6c5898a3-f7d4-46ca-b0b1-bfeb0290bda5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6f38c8f2-2ef1-4c93-ae03-71645cd5ba2d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("71446120-3d4b-4a1d-b8a7-c2ec7b469a0e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("781e6b12-993f-4f79-9a26-0fde36e88ad1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("80b981b1-1e80-4c69-b3d7-d4cad5d7a002"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("85adafb6-5d09-4b4a-90a4-a61257522443"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8bb8a91f-4a47-427a-bc28-3f7e802aa8a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("98984bbc-865b-4584-8003-af21254c3c9c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bd0c89de-338d-4c59-a56f-bbf81daabe52"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("daf85a9a-f7b3-4577-b279-876e82b20eb8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f4163527-bd77-4fbf-a563-bc11bfea62b6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f70a250b-1eba-4170-822b-8ae1f6da878e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f7b2106d-c7a8-4922-966f-99d573640ded"));

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
        }
    }
}
