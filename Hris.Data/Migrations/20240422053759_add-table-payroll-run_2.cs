using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablepayrollrun_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PayrollRun",
                newName: "Notes");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("0a37c57c-831c-47dd-96f8-c5e3426ec4c0"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3954), new Guid("65c05551-952e-48b4-9b4e-7d8880395d3a"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("229ff299-7bff-4cc4-bac2-f6f492d9d58f"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4009), new Guid("987b1370-f024-40ae-ba0d-5476803e3700"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("25d6cb4f-f320-4864-9a96-d3d6b8594732"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3986), new Guid("02dedbe6-92b5-45c8-aa6e-229bf33fc685"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("25e362fb-8986-4e6d-909a-bc689bac8424"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3991), new Guid("343d4289-1d18-437a-81fc-338b2ec1a428"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("3490e0d4-33ad-4861-a625-3331c120034a"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3974), new Guid("513e584d-b791-48c1-b9f0-eca003232cc6"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("38344369-ea79-4a3a-8079-4f21ae060bac"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4003), new Guid("6783aef8-b7ed-4967-bcfd-d81dc3e1b275"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("3b9df0bb-d82a-44f4-995b-10a0ffd6e736"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3988), new Guid("e181fa08-db34-4687-a821-5387b7612870"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("4751a7c1-5904-4989-b78d-976b6514cd2b"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3992), new Guid("5bacdbe0-af3e-4aa4-9753-7abe90d32d01"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("481f2e90-cde3-4a65-9826-1ed0b417d812"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3962), new Guid("c0c8f033-cc29-42fa-9987-369bb0fc7c92"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("49a09fa9-e034-42b9-bd7a-674d732fc881"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4010), new Guid("679369e0-b99d-4f75-b695-470acf75224e"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("539c70bd-fe2c-4e16-84d3-d59090afc49e"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3993), new Guid("cc62535c-12e8-442a-b565-c1fa53bcb37d"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("57ecc863-55dc-40dd-a417-1677c08d5fc8"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3978), new Guid("ca8c5c34-f8f9-4b68-9b53-f4fde1258fa4"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("61475654-a5bb-462f-ac7f-1519f14c7305"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4016), new Guid("ecd6be8c-d0c5-4c04-ad29-83b8fef8b1ce"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("6a9afda7-157b-44ab-b19b-beeaaee4562e"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4020), new Guid("7ed8b605-d1e7-49f3-bfdd-d95a42593aff"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("6b7a3dac-371e-4ccc-81f5-74f40138cc9a"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4006), new Guid("2ecf7a13-8cfc-4aa8-91c1-b949d8404c18"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("6fe0c99a-762b-4dd6-92f9-9ee64eab70e8"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3983), new Guid("96ecc91e-d27a-4a3c-95c9-48ea3fe44659"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("92d21fad-996a-4a39-91e0-b57e12673498"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4021), new Guid("8c854f9e-b389-4f08-96c6-731edbef3da8"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("a93d9493-94c5-4c19-9852-3ab61b8b1029"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3976), new Guid("e28c6c30-8a1c-4c0a-841f-58a55f51423b"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("b2098bb0-f53d-4ab0-8243-932b2e37d70b"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4013), new Guid("0e4518f3-2114-44aa-8f6a-831ff0f573d5"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("b5015a66-37c9-45a0-95ad-16f27485367c"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4007), new Guid("2cabc581-069e-49d1-bcf9-8a2065553a12"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("c96a493c-416a-4c12-bebd-5441453a785e"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4017), new Guid("ee322f0c-502f-4b3c-9813-beabb0487cb1"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("cc3e17d2-3ffa-455c-87ce-8cadd90f3ab4"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3960), new Guid("c1f2128c-3a97-45be-af17-9f87b27ce7e5"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("de20ec2a-7f5d-4d3b-a9b6-ea58586c0994"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3985), new Guid("431dfcca-dd05-40b9-ace7-0b43c1de1f6d"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("f9ef1c16-cd8f-476f-9b8a-48aa3c8d98bb"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(4015), new Guid("a6e042a7-5090-4a2d-875e-19b0076cb2b4"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("fac13600-2147-49a7-b111-fa57d95a125b"), true, new DateTime(2024, 4, 22, 5, 37, 59, 265, DateTimeKind.Utc).AddTicks(3980), new Guid("cfde5c05-8efb-4384-81e8-60ffe365fd10"), "Clock", "Clients", "Clients", "Admin,Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a37c57c-831c-47dd-96f8-c5e3426ec4c0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("229ff299-7bff-4cc4-bac2-f6f492d9d58f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("25d6cb4f-f320-4864-9a96-d3d6b8594732"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("25e362fb-8986-4e6d-909a-bc689bac8424"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3490e0d4-33ad-4861-a625-3331c120034a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("38344369-ea79-4a3a-8079-4f21ae060bac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3b9df0bb-d82a-44f4-995b-10a0ffd6e736"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4751a7c1-5904-4989-b78d-976b6514cd2b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("481f2e90-cde3-4a65-9826-1ed0b417d812"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("49a09fa9-e034-42b9-bd7a-674d732fc881"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("539c70bd-fe2c-4e16-84d3-d59090afc49e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("57ecc863-55dc-40dd-a417-1677c08d5fc8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("61475654-a5bb-462f-ac7f-1519f14c7305"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6a9afda7-157b-44ab-b19b-beeaaee4562e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6b7a3dac-371e-4ccc-81f5-74f40138cc9a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6fe0c99a-762b-4dd6-92f9-9ee64eab70e8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("92d21fad-996a-4a39-91e0-b57e12673498"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a93d9493-94c5-4c19-9852-3ab61b8b1029"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b2098bb0-f53d-4ab0-8243-932b2e37d70b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b5015a66-37c9-45a0-95ad-16f27485367c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c96a493c-416a-4c12-bebd-5441453a785e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cc3e17d2-3ffa-455c-87ce-8cadd90f3ab4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("de20ec2a-7f5d-4d3b-a9b6-ea58586c0994"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f9ef1c16-cd8f-476f-9b8a-48aa3c8d98bb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fac13600-2147-49a7-b111-fa57d95a125b"));

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "PayrollRun",
                newName: "Status");

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
        }
    }
}
