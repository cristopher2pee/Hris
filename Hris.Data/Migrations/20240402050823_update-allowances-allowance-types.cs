using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateallowancesallowancetypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Period",
                table: "AllowanceTypes");

            migrationBuilder.DropColumn(
                name: "EffectivityDate",
                table: "AllowanceEntitlements");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("03d64b4a-e146-4cc7-a2dc-dde187cb66a0"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5815), new Guid("a872cc18-ae95-49a8-8424-d4a70284709f"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("0509ce1c-17bf-4002-8859-b1f83af1b8cb"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5857), new Guid("edde9228-7974-4927-bfba-e5db6481941e"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("17e9977e-e87c-4867-95ac-940c04c600ce"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5838), new Guid("900debcc-45ac-4e5c-9228-b715ec5324c0"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("21e4e238-e6d1-4736-be4b-73f25cb8b3a5"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5869), new Guid("fc335374-10ce-4764-881f-e32bcc0de528"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("23eeeabf-89ec-41a4-b2d7-082b29a6b3b5"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5864), new Guid("a3bf1459-25dd-46a8-a40c-589dab6d8218"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("4bb4f96e-5a79-498f-accf-4bb73502f13d"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5810), new Guid("8d5f34b4-c5fc-4acc-b704-a326ef9a9b54"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("500295a4-d83d-4cb1-b72e-cdda800bbf95"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5855), new Guid("408d5a9e-d14a-4fb6-8b05-b7cd02264ffc"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("6d9eb846-21d9-44a7-8ad0-a38696848a0e"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5842), new Guid("4319a5aa-3cdd-4312-b92a-71edb4474490"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("892ba8e2-8bc0-4009-aa1e-a263e71345aa"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5865), new Guid("274c39f1-a739-436f-8f53-a92c79682775"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("ad97f67f-8a14-4b81-bb18-fc49a67d1e7b"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5860), new Guid("e6db4ab1-c6d4-447e-b4f7-0becec846694"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("b335da23-cbbb-415f-beb7-91f56fa5ebb2"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5859), new Guid("7adb05d0-c69e-4413-8818-be0bebd24e62"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("c2a7ca1e-7453-4d1d-9c9a-ebc7f21cde45"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5851), new Guid("415df56b-a3d1-4272-b8b4-328ce00ec442"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("c7a40c61-b5e9-42fb-b0c4-7b0e4542ad79"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5850), new Guid("6339a165-3d7d-4823-8a37-ba179d273e23"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("d285327e-58c8-40b7-9b3d-121f01c448a2"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5863), new Guid("5562f1ab-5964-425a-a7d0-a535b4b83022"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("e1692ebe-0411-4a15-af96-d490f706a1b3"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5867), new Guid("8d3eab2f-af71-4bd1-8873-925690f68432"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("e3d7ebe3-d145-4240-a82b-24d30b129eff"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5834), new Guid("60f6bb41-9828-4ba6-904d-efc724d99de1"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("f2c98cea-3991-40c5-802f-cdf0b5ec4cd9"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5852), new Guid("b786af65-8ffe-49e0-bc53-820195ac2bd6"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("f39dcb68-b327-466e-88b7-eafa1c495f96"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5817), new Guid("69379662-e692-414d-be2f-4dce4c7cc690"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("f67cf6e5-5484-48c0-948d-6f4441fd01ab"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5835), new Guid("50d48dee-0155-45fb-8b53-63772c14f80b"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("fe0578a8-062a-4786-aee8-ebb54d553220"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5836), new Guid("88005cfd-82ac-482d-8acc-d47832a33bd9"), "Clock", "Track", "Track", "User,Admin,Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("03d64b4a-e146-4cc7-a2dc-dde187cb66a0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0509ce1c-17bf-4002-8859-b1f83af1b8cb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("17e9977e-e87c-4867-95ac-940c04c600ce"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("21e4e238-e6d1-4736-be4b-73f25cb8b3a5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("23eeeabf-89ec-41a4-b2d7-082b29a6b3b5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4bb4f96e-5a79-498f-accf-4bb73502f13d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("500295a4-d83d-4cb1-b72e-cdda800bbf95"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6d9eb846-21d9-44a7-8ad0-a38696848a0e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("892ba8e2-8bc0-4009-aa1e-a263e71345aa"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ad97f67f-8a14-4b81-bb18-fc49a67d1e7b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b335da23-cbbb-415f-beb7-91f56fa5ebb2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c2a7ca1e-7453-4d1d-9c9a-ebc7f21cde45"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c7a40c61-b5e9-42fb-b0c4-7b0e4542ad79"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d285327e-58c8-40b7-9b3d-121f01c448a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e1692ebe-0411-4a15-af96-d490f706a1b3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e3d7ebe3-d145-4240-a82b-24d30b129eff"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f2c98cea-3991-40c5-802f-cdf0b5ec4cd9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f39dcb68-b327-466e-88b7-eafa1c495f96"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f67cf6e5-5484-48c0-948d-6f4441fd01ab"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fe0578a8-062a-4786-aee8-ebb54d553220"));

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "AllowanceTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectivityDate",
                table: "AllowanceEntitlements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
