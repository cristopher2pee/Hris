using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablepayrollrun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("01fee400-f45b-4cda-ac65-a1235560f9fb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("09845c05-603f-4772-beea-f26ce01fa6cf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a1e0f35-77f3-4171-b663-fd89e5a782a7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0f70fc78-70c0-4c19-9601-2151e9cc5d08"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1d80c167-39d1-4895-8cb1-eb902bce3af8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("26109092-c849-4053-8705-19ee5bf2502a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2bfca789-5c82-4f83-997c-5bb62c5cf24e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("387d7a20-638e-438e-be9f-c94d10f2a911"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3ef2f8fc-6213-4467-ae65-33d8d10fb23a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4db0c1a4-ea6e-4dcb-a9e1-7ed82453b613"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("77fccf7a-07e0-4caa-9f16-c054bf347dbd"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8110cd1a-986b-4398-ac44-49788cd6033c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8e15be20-db4d-4116-a97e-42b7ffa2796e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8ea360ce-9ecd-4af5-91a4-1def1cf8105c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aa9d96be-3793-4cc2-8c83-63557d3a1fad"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bc14d014-17b8-47fd-a898-af5dde116c0f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c4813b9f-d036-462d-9e9f-8bc76835e7f9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c9b73298-60fd-4375-b50d-fc474d97dc92"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cb66be63-77e5-4cbd-9d70-af571d5b9717"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d3a0d318-1ea7-49c4-abb6-b0bee083153e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d772ae27-31fe-4912-9301-2ed5868ef479"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d90f6572-720c-48c3-8a20-79aeb559c88d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e12d6c3f-9a0a-43b2-8b77-4e59f0888251"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e2a6fa50-fbae-4d5a-a4a8-064ce5425b08"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f04c4bc0-9d27-4573-b41d-c2038702da68"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("01fee400-f45b-4cda-ac65-a1235560f9fb"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8672), new Guid("5786ee00-debd-401b-a1a0-7e5f93972fbb"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("09845c05-603f-4772-beea-f26ce01fa6cf"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8711), new Guid("c4677a73-dc48-455d-b3dc-076a273f363d"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("0a1e0f35-77f3-4171-b663-fd89e5a782a7"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8696), new Guid("3102cd65-6f68-40bc-9899-9427538abf9e"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("0f70fc78-70c0-4c19-9601-2151e9cc5d08"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8693), new Guid("0b9b91f8-e6ca-4ce4-9ffe-62aaf1e11d55"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("1d80c167-39d1-4895-8cb1-eb902bce3af8"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8687), new Guid("57d412d9-83f5-42f4-9870-702de857a299"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("26109092-c849-4053-8705-19ee5bf2502a"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8692), new Guid("7af325f3-ec58-4f5d-9581-e520f5ed61a8"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("2bfca789-5c82-4f83-997c-5bb62c5cf24e"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8679), new Guid("c685c429-3976-4c09-b4a9-d42343d69596"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("387d7a20-638e-438e-be9f-c94d10f2a911"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8703), new Guid("38b8ba44-2235-4d03-aa7b-0e3e84761c92"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("3ef2f8fc-6213-4467-ae65-33d8d10fb23a"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8670), new Guid("44c71dc6-dfad-4c5c-8548-032044a15083"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("4db0c1a4-ea6e-4dcb-a9e1-7ed82453b613"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8694), new Guid("e3fe9c05-d1b5-42a7-8be1-6a5cb333c234"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("77fccf7a-07e0-4caa-9f16-c054bf347dbd"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8677), new Guid("b745b6dc-eb7e-437f-a181-da6f3fb480cd"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("8110cd1a-986b-4398-ac44-49788cd6033c"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8705), new Guid("b181022d-5c18-48b8-84e3-cf6192d1f44f"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("8e15be20-db4d-4116-a97e-42b7ffa2796e"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8676), new Guid("146b2a54-8df4-4d08-9f29-1dcf020c697b"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("8ea360ce-9ecd-4af5-91a4-1def1cf8105c"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8706), new Guid("a4a8e57d-e610-465d-a9cc-4521dfcb396b"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("aa9d96be-3793-4cc2-8c83-63557d3a1fad"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8713), new Guid("fa080d2c-bd79-4e96-bad9-1cc40600c52f"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("bc14d014-17b8-47fd-a898-af5dde116c0f"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8643), new Guid("94860370-73e1-4711-b8ae-c799a4f3a926"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("c4813b9f-d036-462d-9e9f-8bc76835e7f9"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8689), new Guid("13eee6ee-094e-48a1-abdc-f8fbd627549a"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("c9b73298-60fd-4375-b50d-fc474d97dc92"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8659), new Guid("ed6bb387-39d9-4e83-b44f-800de397283f"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("cb66be63-77e5-4cbd-9d70-af571d5b9717"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8709), new Guid("693bc293-d90c-410f-8690-96758b37e7af"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("d3a0d318-1ea7-49c4-abb6-b0bee083153e"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8684), new Guid("1e12805f-be14-4648-b645-fbf3a1a6a734"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("d772ae27-31fe-4912-9301-2ed5868ef479"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8647), new Guid("582f813a-3efe-4ce7-8e82-949ad83f573a"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("d90f6572-720c-48c3-8a20-79aeb559c88d"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8683), new Guid("a32a2ffa-ced0-4c30-9943-af950794facb"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("e12d6c3f-9a0a-43b2-8b77-4e59f0888251"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8700), new Guid("c242228f-bac8-48dd-98fe-081a0dbf648b"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("e2a6fa50-fbae-4d5a-a4a8-064ce5425b08"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8680), new Guid("784a44b6-7f61-4243-9184-bcc4a75e4a87"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("f04c4bc0-9d27-4573-b41d-c2038702da68"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8668), new Guid("8462d9f7-1062-4f1e-a72f-c1fbd5a2ea16"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" }
                });
        }
    }
}
