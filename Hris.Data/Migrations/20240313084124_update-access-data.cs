using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateaccessdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("04a2694d-7fb2-43b4-9069-d2945ed1904a"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2743), new Guid("adb679a8-6153-49cd-ad5f-3ebc9953c1d5"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("070f44d3-cf4b-4c9e-8462-e21352d7e134"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2766), new Guid("cdabcb9c-fd9e-45d6-9a1b-9d852a1c924b"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("339040e0-c23b-41ab-b6bd-4f40195877cc"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2771), new Guid("b54fd52c-9324-429b-b569-ad285ed0cd2a"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("33db656c-7fe3-4e91-a87b-1402fe4b1f24"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2777), new Guid("acbd7b05-2afb-467b-8754-2cf7375f2458"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("3eef7659-1c32-4da2-9dcf-7b3af660b068"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2745), new Guid("dfadf4a5-f2d9-4c67-be95-3c3fd8629722"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("65d66fd2-ab07-436d-84dc-1278db128fac"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2763), new Guid("eeb91540-dc1a-425c-b462-a738a98e5a9f"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("68bfab90-65e5-4d54-ada8-4ccec6a741c6"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2747), new Guid("fe7262d8-b256-4cfb-9f99-56ac992bca7f"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("6a794116-2585-48cb-a941-9213f26355ee"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2724), new Guid("7fdc193f-3f04-4c35-a88f-06536da3cdd0"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("8370e476-a5da-4aa6-8324-c2fe4ba729e7"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2759), new Guid("7c96f7ec-1771-453d-b3eb-91cabf2ff407"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("83c13d3d-2a71-49ff-a7f8-5fcf0d254275"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2778), new Guid("5593c081-adbd-4501-ae16-3c52d65511dd"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Hr,Lead" },
                    { new Guid("8fe7c77c-976a-47cb-97c8-ab61c7d0029b"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2765), new Guid("cdd4fd24-8334-4883-9f42-44bc74b97619"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("93d64ac6-e35a-4996-a4e7-81496796f01f"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2762), new Guid("ddae17dd-41ca-42a0-bdb2-793b4597cf6e"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("c422851e-d517-4faa-ba29-e95ef543969e"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2772), new Guid("f650b93c-2a6c-4293-81f5-4403c2065877"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("d1ae761a-286c-496f-a338-0c91551006d4"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2774), new Guid("36738703-2642-47bb-ada7-600c882e1484"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("da555c6b-996f-4236-9cac-9aca21768812"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2757), new Guid("1d3f030c-2034-40aa-894f-6079cc106ca6"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("de5fdc3e-bd64-441b-a235-0c9c1346f53a"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2754), new Guid("ebb3b461-55b2-4eee-a794-df7e35952b6a"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("f03b24ad-8c65-44c5-9a89-e265bc0da512"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2755), new Guid("d692ca67-71e0-40b3-8bef-fa479e9e6db6"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("f1ca36fd-3f5b-4713-85fe-49e8a12163bb"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2750), new Guid("87ff30e5-0297-4ac7-b3b9-0f2ea5c12efb"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("f2959af7-fa8a-4513-a480-562b264dd8e1"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2729), new Guid("ecd4bd7d-40de-4d99-be81-c6a5c0bb4dba"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("f848d014-aaf3-40a1-b084-cd3708f17527"), true, new DateTime(2024, 3, 13, 8, 41, 24, 214, DateTimeKind.Utc).AddTicks(2770), new Guid("99a433b7-a36e-448f-a48a-a4aa03ba3382"), "Admin", "Permission", "Permission", "Admin,Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("04a2694d-7fb2-43b4-9069-d2945ed1904a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("070f44d3-cf4b-4c9e-8462-e21352d7e134"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("339040e0-c23b-41ab-b6bd-4f40195877cc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("33db656c-7fe3-4e91-a87b-1402fe4b1f24"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3eef7659-1c32-4da2-9dcf-7b3af660b068"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("65d66fd2-ab07-436d-84dc-1278db128fac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("68bfab90-65e5-4d54-ada8-4ccec6a741c6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6a794116-2585-48cb-a941-9213f26355ee"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8370e476-a5da-4aa6-8324-c2fe4ba729e7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("83c13d3d-2a71-49ff-a7f8-5fcf0d254275"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8fe7c77c-976a-47cb-97c8-ab61c7d0029b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("93d64ac6-e35a-4996-a4e7-81496796f01f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c422851e-d517-4faa-ba29-e95ef543969e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d1ae761a-286c-496f-a338-0c91551006d4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("da555c6b-996f-4236-9cac-9aca21768812"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("de5fdc3e-bd64-441b-a235-0c9c1346f53a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f03b24ad-8c65-44c5-9a89-e265bc0da512"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f1ca36fd-3f5b-4713-85fe-49e8a12163bb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f2959af7-fa8a-4513-a480-562b264dd8e1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f848d014-aaf3-40a1-b084-cd3708f17527"));

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
    }
}
