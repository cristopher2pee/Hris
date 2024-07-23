using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablepayrollrun_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2bd3fa2c-e873-4e32-84c7-52be597fc288"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2e28a87e-71ef-4ace-ae4b-ebd8f63b6664"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("30437eaa-c243-4d05-b61a-8ccd10deee11"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("40b2218c-9428-435e-a75d-1833317f174d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4b17413f-14b4-4981-b8d1-a4849e3467fe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5e7627f1-8878-4ca4-9f6e-408b3ad449f2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("62b10204-7ae7-4d82-89b9-55b8aa5f73dd"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6316ff7b-bbc3-48df-a3bb-6611f0d818c0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("676a136d-ca5b-4076-b31c-48baadd28565"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6e13bf79-a60a-4508-8ad3-d13bcba3bf2b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7fc5353a-879c-4d71-9180-368930726139"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8c1a0377-e722-4089-9caa-2e2455f78aa2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8ef1a801-0240-4677-a3f1-15c8e2e11a2c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9073ae4a-60c0-4d49-8456-eab41b511faf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("915fcf11-a053-40fc-89a8-fce10e8be94a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9588cc7a-3b51-4f7a-aceb-b5ac74bd4ddc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("99a790f0-354e-4a00-a446-8bcda970eb72"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a22557d9-6b96-4d65-af5d-a1aff6307a43"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ac9c8000-181d-4d24-b249-5293633cd421"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b0dab0e9-ec2f-4789-beef-164dc373a074"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d8153e2f-fba8-4ab1-9b8c-ea1f8cb1fe9e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("df3898ab-0e0e-4f56-89b9-22e07f62c7db"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e0a3050c-4580-4fc5-a310-bfb448e1abe0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e922d2ac-9568-4718-800e-52b34772dcfc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f749e7cc-7691-4c6d-b872-47aa2c6acfc4"));

            migrationBuilder.CreateTable(
                name: "PayrollRun",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PayrollCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollRunStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollRun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollRun_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollRun_PayrollConfig_PayrollConfigId",
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
                    { new Guid("0553e6a4-0100-4489-9036-34f65ee4dbc7"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2439), new Guid("efd74d64-2a1b-4443-b3c5-c257003fadad"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("0c0c77bd-05d6-4fa1-9e63-98dc8b6b12af"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2400), new Guid("5dcf1820-c7df-4c79-bd09-e8b2a920d51c"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("2aec22e3-d44a-4ff9-aa07-e19dae32a6e8"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2449), new Guid("c63f2a68-a890-43e4-a532-445f9d8a5cad"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("32acbba0-5dc2-47e3-a046-7693c30de6ff"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2420), new Guid("35301b43-ccd0-4134-aa25-90eb7e96942b"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("48c3e1a4-7f2c-4774-9e8d-ef606f006124"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2399), new Guid("0cc93776-7c44-4051-bad8-e4550c0fd20f"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("4a100471-ffb8-4111-8ee4-e8a31153638f"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2411), new Guid("4a278905-850c-4070-a4ab-45f91db2824b"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("5270c996-1845-4a23-87fb-9cbfee7fd615"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2446), new Guid("dc57a7b3-f13b-4fe3-acb6-2e2196435b9f"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("5ebc203e-9282-4f78-b387-012eb846c4f7"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2434), new Guid("cc35d235-a21f-485c-a221-f4f9eaeac02f"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("610c7ea9-284e-4ec7-bff5-71a6832325c9"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2424), new Guid("44a4ab4e-2e39-42ca-9891-dec28843939e"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("6441ca57-3591-458c-9b85-a5f0f1ca47b3"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2430), new Guid("735dc17c-3f30-4c09-9c4e-ccbb0aacfaf4"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("676449e7-e71a-4ef6-8e65-492f5a6204ab"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2416), new Guid("d1189b46-8818-4494-ba0c-e000fa308dea"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("6aec0539-e8e7-4a5c-96b4-c9b920433866"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2436), new Guid("aa1871da-f7c7-4c79-8424-5b813c12310a"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("83b0dd79-7915-4c96-ab19-16d0a4f44c0b"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2422), new Guid("3b5ed56f-4c61-4e47-942c-3213beca1067"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("a1a75929-4eb0-4e64-b228-65249d78b25e"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2445), new Guid("004e2b51-7304-432a-a997-21961185426b"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("b92d07a4-1ea8-4b37-84f4-7ae15a4b4165"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2414), new Guid("35886837-afa5-4d50-99a8-e9dd11f22980"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("c8ab4a86-75d1-4ec0-a881-0486f8f40dee"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2391), new Guid("69a4caf9-110d-47d4-a7ff-8dcb5c1e820c"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("c92492ee-d469-495e-8b4b-f0771fa94cac"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2412), new Guid("c7b16b0e-a615-4fd1-932f-c969740a7dfd"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("caebc1fe-2f4b-409c-8615-4a29f3b674e2"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2448), new Guid("3b5b3438-90fb-4f1c-a57a-b2c9da99e5ea"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("dc39e6e8-01e6-4e4f-8b06-31eeb9fcf7e4"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2441), new Guid("c9ab7064-ed79-4858-9440-58fcd3fbc850"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("df3c81d7-ae46-4606-ade5-5b7e662c3d2e"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2429), new Guid("bb5984bf-ef87-457d-abf0-3907f35bea44"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("ec848cdb-97d3-4f6f-8c1c-2dd655ca1a0c"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2432), new Guid("4c113565-7017-4908-ac60-88fe694009f6"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("f2965579-887d-414e-96e5-bc94dba6f729"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2440), new Guid("f003cb03-947c-4bab-ab08-141c42e01937"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("f7e9a0da-70eb-4bac-9d60-927f717b577e"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2425), new Guid("90ac47c5-2b7c-4a8e-8ee1-887c43ae6499"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("fc3e2a68-3d0a-460f-bd26-1d8b0717b57c"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2397), new Guid("f32eba7f-4f3a-4e30-9523-e12be6a99112"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("fe7aad40-06e7-406d-ad40-995ee8628528"), true, new DateTime(2024, 4, 22, 5, 36, 49, 23, DateTimeKind.Utc).AddTicks(2452), new Guid("1565f9b2-d421-4ee0-bc0a-7c941653801f"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollRun_ApprovedById",
                table: "PayrollRun",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollRun_PayrollConfigId",
                table: "PayrollRun",
                column: "PayrollConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollRun");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0553e6a4-0100-4489-9036-34f65ee4dbc7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0c0c77bd-05d6-4fa1-9e63-98dc8b6b12af"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2aec22e3-d44a-4ff9-aa07-e19dae32a6e8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("32acbba0-5dc2-47e3-a046-7693c30de6ff"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("48c3e1a4-7f2c-4774-9e8d-ef606f006124"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4a100471-ffb8-4111-8ee4-e8a31153638f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5270c996-1845-4a23-87fb-9cbfee7fd615"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5ebc203e-9282-4f78-b387-012eb846c4f7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("610c7ea9-284e-4ec7-bff5-71a6832325c9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6441ca57-3591-458c-9b85-a5f0f1ca47b3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("676449e7-e71a-4ef6-8e65-492f5a6204ab"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6aec0539-e8e7-4a5c-96b4-c9b920433866"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("83b0dd79-7915-4c96-ab19-16d0a4f44c0b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a1a75929-4eb0-4e64-b228-65249d78b25e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b92d07a4-1ea8-4b37-84f4-7ae15a4b4165"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c8ab4a86-75d1-4ec0-a881-0486f8f40dee"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c92492ee-d469-495e-8b4b-f0771fa94cac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("caebc1fe-2f4b-409c-8615-4a29f3b674e2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("dc39e6e8-01e6-4e4f-8b06-31eeb9fcf7e4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("df3c81d7-ae46-4606-ade5-5b7e662c3d2e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ec848cdb-97d3-4f6f-8c1c-2dd655ca1a0c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f2965579-887d-414e-96e5-bc94dba6f729"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f7e9a0da-70eb-4bac-9d60-927f717b577e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fc3e2a68-3d0a-460f-bd26-1d8b0717b57c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fe7aad40-06e7-406d-ad40-995ee8628528"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("2bd3fa2c-e873-4e32-84c7-52be597fc288"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3248), new Guid("12ae7ca2-d883-4f5d-9a45-740f82ab3693"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("2e28a87e-71ef-4ace-ae4b-ebd8f63b6664"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3225), new Guid("e320f1c7-b739-4f8d-be10-af320939ea35"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("30437eaa-c243-4d05-b61a-8ccd10deee11"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3215), new Guid("5819f24c-bb8a-4fca-ac24-19649cde7ed3"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("40b2218c-9428-435e-a75d-1833317f174d"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3239), new Guid("09e863a6-2d9b-4b43-bcfe-7a4de7b9b539"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("4b17413f-14b4-4981-b8d1-a4849e3467fe"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3192), new Guid("8cb6f136-3f7e-4df3-adab-d3b796edef6a"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("5e7627f1-8878-4ca4-9f6e-408b3ad449f2"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3220), new Guid("6e22133b-3d7c-44d6-acfb-7a92bbaf7938"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("62b10204-7ae7-4d82-89b9-55b8aa5f73dd"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3222), new Guid("007a5649-0f28-4dc4-9439-29ec6b6aefbc"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("6316ff7b-bbc3-48df-a3bb-6611f0d818c0"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3217), new Guid("e779f09a-2eb2-412e-98e5-652733382f58"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("676a136d-ca5b-4076-b31c-48baadd28565"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3213), new Guid("efe0e2d9-0b9b-483a-9619-c8bd8acd47b8"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("6e13bf79-a60a-4508-8ad3-d13bcba3bf2b"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3233), new Guid("e3bbf11e-7e92-45a9-b288-db315e1a09cb"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("7fc5353a-879c-4d71-9180-368930726139"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3237), new Guid("e201e833-f201-4dde-9f1a-86c950cd6ca0"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("8c1a0377-e722-4089-9caa-2e2455f78aa2"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3245), new Guid("578a41d1-126f-4a27-af21-5bcdd9bd94f5"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("8ef1a801-0240-4677-a3f1-15c8e2e11a2c"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3254), new Guid("47e8b4ac-771b-4ea4-9f6f-a673ddb15a69"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("9073ae4a-60c0-4d49-8456-eab41b511faf"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3240), new Guid("26d25669-5596-4f66-a007-43f6e49af037"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("915fcf11-a053-40fc-89a8-fce10e8be94a"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3234), new Guid("81e988eb-8e4d-40d0-89b9-54b31013883f"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("9588cc7a-3b51-4f7a-aceb-b5ac74bd4ddc"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3242), new Guid("df5b2206-5ccd-49a5-ad36-620bc178f7ab"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("99a790f0-354e-4a00-a446-8bcda970eb72"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3211), new Guid("d2881ae1-003b-4e06-afab-7e3ecf1c9031"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("a22557d9-6b96-4d65-af5d-a1aff6307a43"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3231), new Guid("df8e376c-043d-44ab-98e2-1a5f27935327"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("ac9c8000-181d-4d24-b249-5293633cd421"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3253), new Guid("d8e1523e-b106-4090-85a3-8819fdea1b7c"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("b0dab0e9-ec2f-4789-beef-164dc373a074"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3185), new Guid("b7fc9b5d-82be-4436-a2e6-51612c07b393"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("d8153e2f-fba8-4ab1-9b8c-ea1f8cb1fe9e"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3247), new Guid("bf658a81-41d9-497a-a7da-da930f071e2b"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("df3898ab-0e0e-4f56-89b9-22e07f62c7db"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3223), new Guid("1a2b2ebf-2b84-48bf-9a22-d6be1dc4ad39"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("e0a3050c-4580-4fc5-a310-bfb448e1abe0"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3228), new Guid("00c89abb-1cb6-4adb-ac7f-9e156dc1139b"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("e922d2ac-9568-4718-800e-52b34772dcfc"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3194), new Guid("4d7a9385-9c22-451b-8add-bfa10b433872"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("f749e7cc-7691-4c6d-b872-47aa2c6acfc4"), true, new DateTime(2024, 4, 22, 5, 33, 49, 609, DateTimeKind.Utc).AddTicks(3249), new Guid("20bd1f21-520b-4d06-a71e-e91c61dc49a8"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" }
                });
        }
    }
}
