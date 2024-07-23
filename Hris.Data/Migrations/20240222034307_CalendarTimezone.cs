using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class CalendarTimezone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Timezone",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("0b48cf5f-806b-4ad7-ad11-6d2f1dbc2272"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4663), new Guid("a1cdc217-b5ac-42e1-8a47-2691f5eda3f8"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("1ba06aa8-0209-488d-a36e-b129cc58fd21"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4658), new Guid("16879cb8-0263-4149-886e-784812c7833f"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("27d9e91c-1716-4163-adff-7ba9698dce64"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4609), new Guid("b368b336-8c4e-4ae5-9514-515d9cff8141"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("4138e699-741d-4beb-bdb8-bb63af0a6cc6"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4678), new Guid("753a3914-53c6-489b-a3d4-5272fbadb204"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("44702953-ddb6-46ca-8103-f8c80094bc21"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4690), new Guid("a224b08d-3915-47d4-807c-5be135a354dc"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("4ee436d8-02c1-4f03-8f3e-4b8e79d1b6f1"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4670), new Guid("fe7a3ed4-9359-4697-a6b5-7cdeac73a631"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("51d45e22-7073-4fe5-aa5e-5f40985854b2"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4668), new Guid("c718c750-eadd-41ed-8bb2-727d4f9414f7"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("60e0db4b-0bad-4710-875a-b3eca00bbc7d"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4674), new Guid("103cc0e7-2d0a-4240-99ce-2bc2b32fab9b"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("684a58d2-97c6-486e-9bf6-42e95a27115d"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4688), new Guid("16230bcf-5603-4e9b-ba24-2ec75210895b"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("817053cf-7276-487a-b28a-1e234ad4acf2"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4672), new Guid("fbf01f15-9cac-4fc5-83cf-b752dda77140"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("84e02253-1c9f-4108-a077-68d16ab59e66"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4682), new Guid("b6fc04c8-9092-4e81-8e03-36e7e617ce11"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("9b2a6acf-dfda-4b45-ba3e-ab7db9fc11bb"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4692), new Guid("a880c829-352d-4182-9bc9-6b5ef09aaf08"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("a9a0dc31-0f4c-4dc9-b831-0932fa4e6e8e"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4599), new Guid("97189694-bf84-4eea-9b04-b42e571a03fc"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("b3fd0b36-462c-42cd-a287-3f49012ad71b"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4656), new Guid("7c3aff80-7dc5-4a16-982c-b4a1befd2704"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("ccee9034-4939-4bf3-a6f4-5dc093f40eba"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4680), new Guid("9bf37a4f-23cb-44fb-b1bc-23623078489f"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("cfbf3629-eb4b-42fb-be0b-67a40c029f08"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4684), new Guid("fe05585d-8441-40d1-a41e-9a6353360f29"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("d82baf3f-01e1-4d3b-be90-7ae834433970"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4606), new Guid("9e5828e6-127d-464b-af78-3906fa2c6fb8"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("e89174ca-9c65-4823-ba9b-57690e7a9ccb"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4611), new Guid("64634e0d-4434-4d12-b5b5-9fe49b531328"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("fe9aa36f-83bf-4129-803f-d46e86455fdf"), true, new DateTime(2024, 2, 22, 3, 43, 7, 238, DateTimeKind.Utc).AddTicks(4661), new Guid("f4bead79-5d39-4c65-a4ed-1572c80ad435"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0b48cf5f-806b-4ad7-ad11-6d2f1dbc2272"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1ba06aa8-0209-488d-a36e-b129cc58fd21"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("27d9e91c-1716-4163-adff-7ba9698dce64"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4138e699-741d-4beb-bdb8-bb63af0a6cc6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("44702953-ddb6-46ca-8103-f8c80094bc21"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4ee436d8-02c1-4f03-8f3e-4b8e79d1b6f1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("51d45e22-7073-4fe5-aa5e-5f40985854b2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("60e0db4b-0bad-4710-875a-b3eca00bbc7d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("684a58d2-97c6-486e-9bf6-42e95a27115d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("817053cf-7276-487a-b28a-1e234ad4acf2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("84e02253-1c9f-4108-a077-68d16ab59e66"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9b2a6acf-dfda-4b45-ba3e-ab7db9fc11bb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a9a0dc31-0f4c-4dc9-b831-0932fa4e6e8e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b3fd0b36-462c-42cd-a287-3f49012ad71b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ccee9034-4939-4bf3-a6f4-5dc093f40eba"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cfbf3629-eb4b-42fb-be0b-67a40c029f08"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d82baf3f-01e1-4d3b-be90-7ae834433970"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e89174ca-9c65-4823-ba9b-57690e7a9ccb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fe9aa36f-83bf-4129-803f-d46e86455fdf"));

            migrationBuilder.DropColumn(
                name: "Timezone",
                table: "CalendarEvents");

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
    }
}
