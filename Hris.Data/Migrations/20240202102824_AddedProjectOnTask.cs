using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectOnTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("07799b5c-ecb1-4c40-a0b8-aaa1e34fb927"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1d148b29-4860-4220-b72b-9dc397884f45"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1fb1e4b7-3ef3-47b1-9d0c-da2eab92ff37"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("24aae7cb-2ca9-4085-988a-35fd3a42cb26"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("30fdf0a2-1f29-47b2-8942-e45ddfede71d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("43d11733-6105-444a-b73b-eb8c26fe93b7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5a21a181-970a-4601-9573-ac185fc0f0b3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("775b6c0b-fd0f-4546-aae7-3b85706a67a0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7ab9c591-f6a0-43fe-a97b-9d737e942297"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("81f65bf9-807c-4ab6-92d9-82dfe2bf8abe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8c9711ea-197c-4164-9c5b-1b9442bf0017"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a4d00c9c-9470-404d-9a0a-c61d36a5be7d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a516ac36-2b90-47f1-8098-b98490d1ab03"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a6d9d0c3-4d40-48cc-97cb-6d0f696a15bb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ae489890-400f-4c78-b1b8-5a3f545e790f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aed8281c-cc7d-4095-8a3a-fe0f033f4b17"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d98a38b0-ccac-4709-afc6-819652fb7fb1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("dd97c2a1-edd0-47e3-936a-4e675ea7d72a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e4e003a5-8f97-4d77-b943-dfdc7b286edc"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("128698bd-ec29-45f1-bd26-0579edaccae9"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4620), new Guid("d65f644f-98ae-43bb-b63c-ef81e9aea6ab"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("4922fed4-8a6a-4e31-91eb-1f63a1c82fe6"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4586), new Guid("415cb7fa-69f8-424f-995c-e6510e03ba9a"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("50e4c198-8023-4318-abcf-daf240b124d7"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4612), new Guid("d1c272b4-1816-473e-ad76-83be34a10018"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("52d3cfdc-402f-47f5-9881-4aacb8959c59"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4614), new Guid("59f9020e-bda5-45ae-9743-ae117aca3168"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("5b306faa-12fc-4c60-b693-ad57e680d899"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4605), new Guid("bad2c472-de69-4e45-b78b-15da0ce5331c"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("5c70ff22-463f-4e72-8003-079fa554cc2b"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4622), new Guid("aa5e47c8-f064-4c07-8917-f5b4e694d578"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("7aa0668d-a46f-4fda-81a0-52251356495e"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4663), new Guid("a2fa50bf-89fd-4560-9ed0-f3d4539d94e7"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("7d0f37ce-ce70-45c3-b236-8aecfa4c8b15"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4617), new Guid("3d3aa1f5-6000-4db0-8aed-c506798479e1"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("7e36cb43-89a5-4823-8bc7-a249e5e76664"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4579), new Guid("22155c33-a8dc-4525-85d9-d69217348a11"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("82f62200-0148-448d-9a37-0f66c16d81c9"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4624), new Guid("1e48c9d8-5477-4e44-a3f9-9477d2878032"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("8c0b081a-3785-404a-b76a-7d74ad742c3e"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4660), new Guid("9252a72c-fcf8-4d9a-ba9c-0e5bdea18059"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("9d86dc3e-01ea-40b7-8395-915f5d96de5c"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4606), new Guid("b4b16e5f-e021-436c-9f35-4b2d6c106a12"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("a33fe96d-a670-4e2c-96a2-84c228b0a527"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4627), new Guid("01882185-ff53-4aa8-889a-5969a1d08386"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("a6a75693-5560-4320-9ed3-4b689c73752a"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4609), new Guid("c8bc1520-d8ef-4734-a1d2-308b50a35bf8"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("b45696a8-8cad-4777-9bd8-05a3e2fe5bba"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4662), new Guid("afabea6d-2e0a-4423-ab02-f9dc066088b3"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("d5107a2c-41ae-400d-a58f-2257b7eea53e"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4621), new Guid("b64b337c-e480-45e6-aa01-c269b5567834"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("e1978e20-17b4-41cb-9bf4-6bde9a5f7e74"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4583), new Guid("7b259cfa-4b2f-40e8-b062-c1e6501fae69"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("eaa71c8f-1343-47d2-aa46-9ee9843b1e50"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4603), new Guid("db1a2d1d-b6e3-4666-b9c5-a3fc2c23c1d7"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("fc9609a8-b80b-48df-a9f6-3b134eda5f55"), true, new DateTime(2024, 2, 2, 10, 28, 24, 410, DateTimeKind.Utc).AddTicks(4615), new Guid("24130188-6796-495a-bd1a-2f64ada082b7"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("128698bd-ec29-45f1-bd26-0579edaccae9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4922fed4-8a6a-4e31-91eb-1f63a1c82fe6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("50e4c198-8023-4318-abcf-daf240b124d7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("52d3cfdc-402f-47f5-9881-4aacb8959c59"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5b306faa-12fc-4c60-b693-ad57e680d899"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5c70ff22-463f-4e72-8003-079fa554cc2b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7aa0668d-a46f-4fda-81a0-52251356495e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7d0f37ce-ce70-45c3-b236-8aecfa4c8b15"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7e36cb43-89a5-4823-8bc7-a249e5e76664"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("82f62200-0148-448d-9a37-0f66c16d81c9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8c0b081a-3785-404a-b76a-7d74ad742c3e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9d86dc3e-01ea-40b7-8395-915f5d96de5c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a33fe96d-a670-4e2c-96a2-84c228b0a527"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a6a75693-5560-4320-9ed3-4b689c73752a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b45696a8-8cad-4777-9bd8-05a3e2fe5bba"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d5107a2c-41ae-400d-a58f-2257b7eea53e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e1978e20-17b4-41cb-9bf4-6bde9a5f7e74"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("eaa71c8f-1343-47d2-aa46-9ee9843b1e50"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fc9609a8-b80b-48df-a9f6-3b134eda5f55"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("07799b5c-ecb1-4c40-a0b8-aaa1e34fb927"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(467), new Guid("e1c52a95-9da6-4054-9973-0de91d66561c"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("1d148b29-4860-4220-b72b-9dc397884f45"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(472), new Guid("2bfdd321-baaa-4e65-8a80-2d3d81be06d4"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("1fb1e4b7-3ef3-47b1-9d0c-da2eab92ff37"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(462), new Guid("de60055c-bd92-4bf5-9036-9588d3dbafdc"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("24aae7cb-2ca9-4085-988a-35fd3a42cb26"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(481), new Guid("2589d5e6-abf6-4059-93c3-0bb0ac830a96"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("30fdf0a2-1f29-47b2-8942-e45ddfede71d"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(474), new Guid("496ebca1-0635-49c4-9614-4e7f4f196faa"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("43d11733-6105-444a-b73b-eb8c26fe93b7"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(446), new Guid("a1f95eca-10b3-4385-ae25-c20c95e04c24"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("5a21a181-970a-4601-9573-ac185fc0f0b3"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(458), new Guid("2d101448-05f9-4f31-afd7-7069f50f0a04"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("775b6c0b-fd0f-4546-aae7-3b85706a67a0"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(466), new Guid("22338b92-698e-49e5-9754-3dd39a05672b"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("7ab9c591-f6a0-43fe-a97b-9d737e942297"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(480), new Guid("47016b68-b24a-4323-ace5-71e9067ec3a1"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("81f65bf9-807c-4ab6-92d9-82dfe2bf8abe"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(438), new Guid("6e2c6583-b258-4b5a-bc44-519dc8dd4020"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("8c9711ea-197c-4164-9c5b-1b9442bf0017"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(459), new Guid("07e16921-2ffd-4634-9cc6-f6860dbb617f"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("a4d00c9c-9470-404d-9a0a-c61d36a5be7d"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(478), new Guid("1dce7f17-2a2f-4532-a18b-03957d5d052f"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("a516ac36-2b90-47f1-8098-b98490d1ab03"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(479), new Guid("63351055-93c2-4b66-b4ba-b56f31c0ae25"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("a6d9d0c3-4d40-48cc-97cb-6d0f696a15bb"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(469), new Guid("f323f29d-1aec-49e4-a745-0474e7772db4"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("ae489890-400f-4c78-b1b8-5a3f545e790f"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(465), new Guid("55edf4dd-1eb3-4fe1-9840-158e3a95a205"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("aed8281c-cc7d-4095-8a3a-fe0f033f4b17"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(483), new Guid("27c79d7f-c746-48df-a104-bd5816fd8e89"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("d98a38b0-ccac-4709-afc6-819652fb7fb1"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(473), new Guid("e74d9b69-ff83-4d42-bf05-ff864b4c54a6"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("dd97c2a1-edd0-47e3-936a-4e675ea7d72a"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(461), new Guid("dd48b7ba-1703-4abe-91be-f240e7dc7907"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("e4e003a5-8f97-4d77-b943-dfdc7b286edc"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(475), new Guid("4323c70c-a2fa-497e-8e0d-81878e4d985a"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" }
                });
        }
    }
}
