using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrackTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0569e86b-f560-4b0d-9264-a3769be9f99c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("260ccf0e-d610-44e7-8f8f-43f5102bfd44"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2f64a4b9-434e-46ba-bd5d-8913fd3f015e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("375c70a4-46b7-4031-97e4-ae10cde901ed"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("452b662f-86be-4213-beee-24ad4c55727d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4a77931d-74e7-4e11-bb52-6dd0b9406cf6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4d056e88-c806-4e39-8afb-241f820c7769"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("62d9dbfc-266a-4bdb-bd3c-14c01d446bea"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("649b1142-8819-4c9f-85cd-86f4a8165a22"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6de5e005-eaa0-45c0-9a89-a9c9a6daf541"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7bf56993-0030-4774-970d-e75f4cf728d5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7fe293c3-58bf-4385-9f6e-ffe5ba484757"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("86105cdc-be06-4f4c-8c5d-2c588f669cd2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("86881365-b6c5-4697-ab34-3b524647e3e1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("972772ae-3d09-448f-8c48-44aa6e388233"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9c451934-1cb5-4660-8322-0ab27b8ebb2b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9edd9d9b-7eda-4935-a64d-c16bdda6b79a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b99c473a-d1cb-42e0-8cc4-6e908de67198"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bd745330-4eef-4fdd-a3ae-fb2435b34feb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d054855a-7191-40a7-8094-992b815c7a26"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d0ce7cd2-9652-431e-ba60-1b278abac275"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f79de0cb-acf4-438c-9968-271584fbdc8d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f8d76939-34ca-4e82-9283-73e1660a18cc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fc9171d6-affd-4251-bb2e-1f35528fbf42"));

            migrationBuilder.AddColumn<int>(
                name: "Tag",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("08fec076-58bb-4038-bb4e-5760d90be08e"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(758), new Guid("652978d8-e782-4225-b644-8fd41318d903"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("0a871a7f-cd39-40c3-b4f0-78b7dbd8432b"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(794), new Guid("88ecae04-d3a1-462a-9a7d-8c9d2d5425c0"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("1672fb59-4666-4df3-afde-a81abd72753e"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(719), new Guid("de20e8af-7d15-49f3-99f9-4dffc846fc8b"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("1f2693d6-25b1-4519-ba06-30e6d84d2e39"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(799), new Guid("008e2477-65e1-4221-92d1-873a2c237943"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("20f8ff8e-d108-436a-b2ee-0b66eb757536"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(786), new Guid("f331b30c-7c01-437a-b6c5-83d26e0f5a03"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("24bbee6d-ee2b-4edc-9267-177191780665"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(790), new Guid("af2a87cb-a5a3-443f-88fb-e64fe6662241"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("31b8cfd0-14fd-4622-8702-c66b487967c6"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(810), new Guid("d5d6c262-c866-49dd-926c-e8f285f878af"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("39d22ddd-aff0-48e8-bb02-775e81daf640"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(808), new Guid("68f10fe1-2302-4155-93a2-2d4207e9cd4d"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("44cadcda-6210-41c8-a769-62ef288116ad"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(806), new Guid("25e651c8-c03d-44d5-a61e-4df8b4cdf4da"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("537ffb7d-47d0-4754-874f-d41c37919728"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(762), new Guid("51365b2a-6860-4cdf-904e-13caaf7cbbd6"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("5395ecd0-203f-4687-8202-18222daccb60"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(776), new Guid("8672692d-30f5-4c11-9894-2ae3192a6e3b"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("658eee38-2363-4a83-876f-b5951e54acbe"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(772), new Guid("27781010-11ed-4e49-a4b2-7f5f5be45dc9"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("6a046949-0ffb-4069-b974-4e3a63cb46b4"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(774), new Guid("aad7e958-3747-4cbd-96d0-81b4f50bc550"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("6ecd1916-6076-4e62-bac5-40ebdef2a4f2"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(746), new Guid("c2ab696f-1ae4-45fe-b6c4-03d1af8d984f"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("735276db-b763-4593-a71e-5a37d49e2071"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(796), new Guid("12f17791-2ae3-4693-a72f-de0b2a20577d"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("a40adb3f-fd8e-40ba-834f-c64600d32bbe"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(784), new Guid("99415bc4-f088-45ff-a151-80971d196b8a"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("aae4f5e7-8209-452d-a639-f391f7a32aa3"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(801), new Guid("6a317fa5-b1a5-4110-b2ba-2871224d1c45"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("ac178a87-1097-4dee-8c87-ba921be3be2c"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(724), new Guid("769d54a4-8e40-411e-91dd-ec1052cf99cf"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("afb2cd04-2b1a-4f92-8a38-2147eb9904ee"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(752), new Guid("ce37ac6f-06c6-4c6e-9714-407e7a07f8b8"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("b075d46b-4480-4021-94d0-ac9ebcbc98b6"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(779), new Guid("d7a9d206-d8da-4bd7-b637-bf5c97031423"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("c1eec4d3-dc13-4cfc-adaf-b261603893d1"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(760), new Guid("57c9cae6-166b-4968-8258-49202ac28de3"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("c2e1dddd-78d6-44e1-b01b-cfeb7c369908"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(743), new Guid("7938d5c7-0eb6-49e8-9b58-4b1c3254c58b"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("c90c76bd-483e-43ec-8c92-1b63814fb984"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(764), new Guid("ac6e38b6-680d-4964-9ef4-9a42de30d435"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("cd7a2105-b14e-4112-8961-a5b567e43d22"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(788), new Guid("ffbb425b-f39d-4346-89c2-c59f0e8987bd"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("ff6aa1a7-9d1b-4c81-addc-fbed065f130b"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(749), new Guid("9aa11a33-9585-4d3a-bedc-0c84f977d583"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("08fec076-58bb-4038-bb4e-5760d90be08e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a871a7f-cd39-40c3-b4f0-78b7dbd8432b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1672fb59-4666-4df3-afde-a81abd72753e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1f2693d6-25b1-4519-ba06-30e6d84d2e39"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("20f8ff8e-d108-436a-b2ee-0b66eb757536"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("24bbee6d-ee2b-4edc-9267-177191780665"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("31b8cfd0-14fd-4622-8702-c66b487967c6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("39d22ddd-aff0-48e8-bb02-775e81daf640"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("44cadcda-6210-41c8-a769-62ef288116ad"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("537ffb7d-47d0-4754-874f-d41c37919728"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5395ecd0-203f-4687-8202-18222daccb60"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("658eee38-2363-4a83-876f-b5951e54acbe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6a046949-0ffb-4069-b974-4e3a63cb46b4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6ecd1916-6076-4e62-bac5-40ebdef2a4f2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("735276db-b763-4593-a71e-5a37d49e2071"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a40adb3f-fd8e-40ba-834f-c64600d32bbe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aae4f5e7-8209-452d-a639-f391f7a32aa3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ac178a87-1097-4dee-8c87-ba921be3be2c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("afb2cd04-2b1a-4f92-8a38-2147eb9904ee"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b075d46b-4480-4021-94d0-ac9ebcbc98b6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c1eec4d3-dc13-4cfc-adaf-b261603893d1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c2e1dddd-78d6-44e1-b01b-cfeb7c369908"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c90c76bd-483e-43ec-8c92-1b63814fb984"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cd7a2105-b14e-4112-8961-a5b567e43d22"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ff6aa1a7-9d1b-4c81-addc-fbed065f130b"));

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Tracks");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("0569e86b-f560-4b0d-9264-a3769be9f99c"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1786), new Guid("c3ab2856-2bfe-4510-82d9-6925a36be482"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("260ccf0e-d610-44e7-8f8f-43f5102bfd44"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1758), new Guid("fcb43bc1-1ba1-4b63-9a0e-99921b1331e7"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("2f64a4b9-434e-46ba-bd5d-8913fd3f015e"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1788), new Guid("9b51ce3b-da43-46a2-87e4-47d8617356ae"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("375c70a4-46b7-4031-97e4-ae10cde901ed"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1782), new Guid("8b5a9c5b-9bee-4cae-89de-f95e63cddb71"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("452b662f-86be-4213-beee-24ad4c55727d"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1772), new Guid("8d3ceb72-18a9-4537-ab44-e9700eb46cd6"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("4a77931d-74e7-4e11-bb52-6dd0b9406cf6"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1731), new Guid("8ba3b7b2-b2dc-47c8-ba4c-f33f25e01650"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("4d056e88-c806-4e39-8afb-241f820c7769"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1755), new Guid("d4a92a0c-ac37-4fda-af64-545161a7d777"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("62d9dbfc-266a-4bdb-bd3c-14c01d446bea"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1794), new Guid("5a09a2e2-8424-425e-b85e-cb5b0b73fe2b"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("649b1142-8819-4c9f-85cd-86f4a8165a22"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1783), new Guid("ba53f30b-baa8-4878-922a-41fe82604593"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("6de5e005-eaa0-45c0-9a89-a9c9a6daf541"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1767), new Guid("d6ec13a7-f0f2-47e8-99c7-7a1f7ac77158"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("7bf56993-0030-4774-970d-e75f4cf728d5"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1764), new Guid("94f42ac0-6c3b-4d4a-86b6-bee0058cd1df"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("7fe293c3-58bf-4385-9f6e-ffe5ba484757"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1770), new Guid("ee2b8285-f3d7-48a2-9e23-debaf7bd1609"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("86105cdc-be06-4f4c-8c5d-2c588f669cd2"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1723), new Guid("50f5d3e7-13cf-49bd-ba38-7a7fa0411431"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("86881365-b6c5-4697-ab34-3b524647e3e1"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1765), new Guid("4cce698e-21e5-47d4-a41d-0e41192ebeb4"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("972772ae-3d09-448f-8c48-44aa6e388233"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1776), new Guid("d81ba417-86ce-4576-b282-818d8f1b72d5"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("9c451934-1cb5-4660-8322-0ab27b8ebb2b"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1762), new Guid("824ed72e-2659-404f-ac36-051c0a7d6db6"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("9edd9d9b-7eda-4935-a64d-c16bdda6b79a"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1781), new Guid("f27b83ad-5a2c-4980-92b2-2792f2dcdd83"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("b99c473a-d1cb-42e0-8cc4-6e908de67198"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1733), new Guid("98c9f98e-51bd-4221-9beb-2bf4b58bc05d"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("bd745330-4eef-4fdd-a3ae-fb2435b34feb"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1757), new Guid("574cef78-6656-4e49-a37e-1b8fb7f572a5"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("d054855a-7191-40a7-8094-992b815c7a26"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1791), new Guid("fc69d1cb-2571-47c6-beeb-f47b4eac4a57"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("d0ce7cd2-9652-431e-ba60-1b278abac275"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1774), new Guid("44b5550a-d94c-4081-b815-8669ba7bf596"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("f79de0cb-acf4-438c-9968-271584fbdc8d"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1779), new Guid("c088d403-7e1b-411f-888e-4a6c9aef3722"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("f8d76939-34ca-4e82-9283-73e1660a18cc"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1753), new Guid("28149c6d-e13b-4af3-b691-531236292c5b"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("fc9171d6-affd-4251-bb2e-1f35528fbf42"), true, new DateTime(2024, 4, 4, 10, 27, 11, 371, DateTimeKind.Utc).AddTicks(1789), new Guid("2a271c7c-d44d-4876-9817-78817391a881"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" }
                });
        }
    }
}
