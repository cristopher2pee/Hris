using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialize_db_for_tope_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("1a2a8ac5-2a5d-468f-8d74-0a81cb5bdf3f"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2109), new Guid("b46ec851-4e97-4678-8c28-2457447cfdc7"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("1a9cdb0c-3415-4e28-8a20-75f9e7b6d516"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2084), new Guid("d207eb0e-3447-4a82-853f-8e0cd67f9f9c"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("1fa29b7c-efd8-44b8-9092-d1313168d9b4"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2061), new Guid("caa02756-9e13-470f-8b5b-cc142b8a60f8"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("25d8ab99-1229-41e1-9c88-453c5c29c6c0"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2099), new Guid("7cf6c8f5-a8e4-4ff7-a9f8-f0b017572882"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("2f95bc4e-384c-426e-8ca9-abdbdbfa9490"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2095), new Guid("d7d27190-d9a6-4784-9717-cdd93f0f39ab"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("4d68607e-f542-4cb3-aca5-1d6f29bb4149"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2081), new Guid("f2268bfc-ad65-4d23-9296-0341e17e57fc"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("63faf399-678c-4567-8264-2c6854042f97"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2100), new Guid("d408f768-9e16-4aae-965c-93a403743898"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("690a265a-4b3b-45d0-a350-ebb5e0165ad2"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2094), new Guid("b9cb5d64-8038-46ce-9283-1242f3aefecd"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("7d9b21ad-fce3-45e8-b6a2-dbfc385e62f8"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2114), new Guid("86727177-97e0-419e-b2ce-4c85555140e8"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("82f03fc6-9965-46de-8268-c3bf4b1cfe57"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2102), new Guid("19851b50-69ae-4a81-b203-a6bccfadb31c"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("aa3adf91-b516-4bce-8856-648ad7a220b7"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2111), new Guid("6b6e429e-b067-4fb8-81cb-97d08b022cfb"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("b698e90f-8081-4c5c-bc7c-f1c05e70d921"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2108), new Guid("ae715bb9-2fc3-4365-8be7-7e68dbc6d375"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("c2c10db0-c944-49ff-b41d-63d7ddbe2432"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2067), new Guid("f037f26b-67d8-4553-8a81-b01f1f7657f6"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("d115e796-5ce2-41ee-a635-f65d5fa92e4b"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2092), new Guid("acd13d64-d88b-42d6-b888-07111c605d9f"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("e56ef6a9-3616-4570-ac5f-0ed36b68ccc0"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2086), new Guid("b262aaa4-5186-428a-a97e-d5b20ee48006"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("e7a77a3f-9eb3-4cda-b959-041f08c6d88f"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2106), new Guid("55db05d1-eee8-461c-a8b1-632794c35da5"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("f33fc888-693f-4b06-a207-c5be29030495"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2090), new Guid("00a44b37-7870-4685-a291-a78eef5a0744"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("f8b0963c-2a62-476d-af44-8a568be5272c"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2083), new Guid("24622ce1-0002-473b-9cb6-e1988e597fbc"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("fb27045a-0c7a-417f-8480-ec8ff8868054"), true, new DateTime(2024, 2, 13, 8, 5, 57, 281, DateTimeKind.Utc).AddTicks(2103), new Guid("2efa4992-c040-47c2-9ab5-7b2982899d61"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1a2a8ac5-2a5d-468f-8d74-0a81cb5bdf3f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1a9cdb0c-3415-4e28-8a20-75f9e7b6d516"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1fa29b7c-efd8-44b8-9092-d1313168d9b4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("25d8ab99-1229-41e1-9c88-453c5c29c6c0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2f95bc4e-384c-426e-8ca9-abdbdbfa9490"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4d68607e-f542-4cb3-aca5-1d6f29bb4149"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("63faf399-678c-4567-8264-2c6854042f97"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("690a265a-4b3b-45d0-a350-ebb5e0165ad2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7d9b21ad-fce3-45e8-b6a2-dbfc385e62f8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("82f03fc6-9965-46de-8268-c3bf4b1cfe57"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aa3adf91-b516-4bce-8856-648ad7a220b7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b698e90f-8081-4c5c-bc7c-f1c05e70d921"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c2c10db0-c944-49ff-b41d-63d7ddbe2432"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d115e796-5ce2-41ee-a635-f65d5fa92e4b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e56ef6a9-3616-4570-ac5f-0ed36b68ccc0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e7a77a3f-9eb3-4cda-b959-041f08c6d88f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f33fc888-693f-4b06-a207-c5be29030495"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f8b0963c-2a62-476d-af44-8a568be5272c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fb27045a-0c7a-417f-8480-ec8ff8868054"));

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
    }
}
