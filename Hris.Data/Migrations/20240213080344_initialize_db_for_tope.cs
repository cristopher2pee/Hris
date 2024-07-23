using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialize_db_for_tope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("01312663-e1bc-4971-9ec4-5dbc8ddd6d25"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3284), new Guid("09c8920d-6f9a-487d-afd6-ea5966f7ab47"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("045ed5a8-bbae-48c7-8dcd-afe7070745e1"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3315), new Guid("a8eeda97-8857-49bd-a96e-5a394acb5b41"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("07708bb6-8b39-471a-bbc4-82c55ba5b7ca"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3272), new Guid("af9a3ece-cf5f-476f-b4e5-0458414200cb"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("0e9826ef-1804-44cf-bdf2-dfb21d6bec92"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3276), new Guid("ee8e3a9b-5078-4def-b6c8-c202fecaf444"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("1bf0ec3b-4ddc-4d40-bb78-a8d20a2713a0"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3473), new Guid("889c7e75-3314-46ca-b0a6-f508ceaa2c48"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("1ca57029-846a-4581-bb21-c02aa933b7b4"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3469), new Guid("69c663e3-c507-45b7-800f-415a7a4dd442"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("445c8e43-8d9e-462f-a23e-382bc7d9c806"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3466), new Guid("05fdf39d-1cc6-47d3-9386-6950ba65f6da"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("4ae9ec03-76c4-48c6-ba5b-ff41c1e75a57"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3464), new Guid("45890d9a-70e4-4058-8293-ba02faad57a3"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("66c4dc28-d83f-4239-ae51-134daeba133e"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3304), new Guid("3d13ca16-1096-4202-8b5c-3a68b262aaa3"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("79275701-2c85-4851-93cb-343089c6f48b"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3287), new Guid("fe6285a4-c5f3-4ab2-abd7-73c05f94bdea"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("7b281a0f-56fb-4570-a906-7eea4c25570d"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3281), new Guid("f0f14682-2940-49fd-a167-9d755a2044f7"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("98c29f52-6cae-4d3b-aead-12b3c22509d8"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3252), new Guid("dbf94034-7592-4b71-923b-cff7a31959e6"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("9c84972b-b4a2-49b4-b1ab-77393931e308"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3308), new Guid("db64c9e1-289a-426b-bf2b-1425e626a5b1"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("dc19fcec-6b6a-490a-a361-4f138e26ee0f"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3310), new Guid("1134bac3-ae75-4dd2-a593-05dcd22024df"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("e6fe94c2-8069-4434-98cb-e9802621d2a2"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3235), new Guid("690639c8-c17e-416e-8c20-7c2fd30e8aca"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("ea5b4e1e-3aa6-4b72-afdb-59f8d115cf86"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3274), new Guid("8df9f1ef-bd39-4127-8e1b-3760bb3ea355"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("f71e9b26-2d7a-45da-98c3-7580a83962b6"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3320), new Guid("23cf88e9-b3ae-470a-a76e-3eb7e65af887"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("fd25611f-517a-4811-910b-d2c9f5b293a6"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3313), new Guid("8719b594-6561-417a-b165-d3d86643f0bc"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("feb82be6-ff07-4496-a689-a174e728631f"), true, new DateTime(2024, 2, 13, 8, 3, 44, 489, DateTimeKind.Utc).AddTicks(3270), new Guid("514d29ab-9446-4f55-9af7-c2548a47bc16"), "Employees", "Position", "Position", "Admin,Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("01312663-e1bc-4971-9ec4-5dbc8ddd6d25"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("045ed5a8-bbae-48c7-8dcd-afe7070745e1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("07708bb6-8b39-471a-bbc4-82c55ba5b7ca"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0e9826ef-1804-44cf-bdf2-dfb21d6bec92"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1bf0ec3b-4ddc-4d40-bb78-a8d20a2713a0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1ca57029-846a-4581-bb21-c02aa933b7b4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("445c8e43-8d9e-462f-a23e-382bc7d9c806"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4ae9ec03-76c4-48c6-ba5b-ff41c1e75a57"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("66c4dc28-d83f-4239-ae51-134daeba133e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("79275701-2c85-4851-93cb-343089c6f48b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7b281a0f-56fb-4570-a906-7eea4c25570d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("98c29f52-6cae-4d3b-aead-12b3c22509d8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9c84972b-b4a2-49b4-b1ab-77393931e308"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("dc19fcec-6b6a-490a-a361-4f138e26ee0f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e6fe94c2-8069-4434-98cb-e9802621d2a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ea5b4e1e-3aa6-4b72-afdb-59f8d115cf86"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f71e9b26-2d7a-45da-98c3-7580a83962b6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fd25611f-517a-4811-910b-d2c9f5b293a6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("feb82be6-ff07-4496-a689-a174e728631f"));

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
    }
}
