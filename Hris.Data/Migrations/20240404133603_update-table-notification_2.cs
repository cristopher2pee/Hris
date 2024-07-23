using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablenotification_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1bf416d9-e40b-4d4a-b097-f09117949b6a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("241b1038-3123-42cc-aaf9-50a59f4f34c1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("28c0f9c5-b4ba-4b71-b7f1-e76344365c41"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2f46821a-78e3-45ec-ba46-ec1106f1d232"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("34ebc955-9bea-4eb0-b904-3ff9f3a88d2e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4fe0ecbc-0b67-41b1-876e-00123f843cd1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("55b5e741-5168-44b3-9520-ff165584e99e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("61069dd9-f460-43d6-b9e3-3b71aacd5edc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("64b7c041-fdb0-48bc-bc0e-7be26bd0d3f1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8b57e242-55c2-4355-8daa-dcfd6bf533f9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9719f43b-f83c-4ce3-93af-5181500288bb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a7a396c4-ef27-47c9-a9ff-7b56855df481"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a8030b50-0039-45a3-905d-0b0efd82836d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a8463611-ea1f-4eb9-ac8b-5a19c8c8c771"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b295c39f-cd4e-40a8-baf1-95f9e5f1eed0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b3e79630-6364-4f60-94e9-c57688a0e8c7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c488be4e-105d-42a0-8b3d-44e4ee2581b9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ccefbf45-e67a-4f03-9371-80f81c9721ac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d051d04b-74c0-4318-9f50-46f1e0c647ea"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e72b2818-83d2-4cc9-9ca8-302f052e4efb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ec462923-2366-45ba-8bc2-c0739ae4452d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ed5fc04c-e768-4b06-ae4f-376e731ecca1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f67bc5fb-5229-4f79-8496-a875c72498ad"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f6f0fc5b-ad46-4317-b428-009a21355d2d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("02b32613-7012-4bee-8020-58d4e01104d7"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9268), new Guid("7974a752-0637-4a17-b321-491a80384d57"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("18184b5e-997c-42de-8970-e7ec7efcc14c"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9256), new Guid("68955bc5-f275-4048-8fba-a0e6047b4ed1"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("1ca424ff-195b-4a64-ba5e-5bcc119a3bde"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9220), new Guid("e5d4ff2c-4660-4372-825a-c273db285c14"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("2d507a40-4d60-44d3-9df4-1e452b639c66"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9241), new Guid("a06c2bcf-0404-4e24-a321-fd1427ce989c"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("2fa5c425-94fb-4e57-9cf2-6804f24fc813"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9244), new Guid("601ff470-b107-4b33-ac6b-457b1f3eb990"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("37710c14-e547-4a6d-b1cb-222735cadaad"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9242), new Guid("0bc43251-5d6d-4bc5-a4c4-a2b04186c6d0"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("3dcba80b-462b-40bb-9419-89693dcf4351"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9248), new Guid("bd719e16-b9e2-4163-bccf-0c9d848bb478"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("465cd6cd-e24c-4511-a5e8-50562445fd96"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9252), new Guid("9ddacf12-9f19-4ed2-b003-48a5cef7f410"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("46ed4c9a-38ed-42fb-a399-c684e1cecca2"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9245), new Guid("d4e5812d-0444-4bef-ab54-6340b8128248"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("4a6caed1-4bb4-405d-9484-72c6ff979b52"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9215), new Guid("6378b433-5cd3-4dd7-8c54-236320c1bc19"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("4e942bc8-5762-4867-8177-ef47ad5e6753"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9265), new Guid("4f373a38-34e8-423d-b4cd-f6082c6b335f"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("5763d365-446e-40e6-a880-7b1c9357fd76"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9262), new Guid("5b0615f5-4877-428b-8de7-3f6c9a859cf7"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("69546cef-c08a-4af0-a68c-3b0bcc4fa9cc"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9271), new Guid("3ce8669d-58f6-4da7-81ef-affc2e238da9"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("6df9b320-7652-4ddc-a28b-91325b74cdc5"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9250), new Guid("3167eef1-cc05-4ccb-ad62-6df2d1e6a6eb"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("6f2f8ef2-1000-423f-b073-ff4396ee57a5"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9258), new Guid("371d98ce-9c16-4e8f-b08f-eae6c607fb3b"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("862e553a-8003-4d7a-a85f-7cf207008326"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9266), new Guid("a06f3599-84b9-409d-932d-47fae9100b20"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("87a6efa2-e8b1-446e-81a0-bf9582b454b4"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9222), new Guid("cb34fa30-2c8d-472e-a5f9-1627be34ba60"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("a4b8a121-1390-4172-92e1-85251679aba0"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9251), new Guid("c0581820-ec74-463e-89bd-535929e341c1"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("a6f724b3-1082-48ce-8cd8-2ef84a2ef471"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9257), new Guid("66756dfd-e94d-4b1b-b4a6-0da65f7ee977"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("ad0ed264-9fb0-4fce-9eef-86047b6173bf"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9219), new Guid("c45db291-a7be-485f-b043-82e013612fc1"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("c0da9145-c97c-4018-8406-ce1693730a38"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9274), new Guid("c9852247-9524-4954-8ae8-aa32d71a65eb"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("c5710e69-8c8e-4ac3-b633-f59a7da3f4ee"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9272), new Guid("a7ecb2a1-e730-4915-aab2-822d65d8de16"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("d25e8f9b-9e99-4c7a-a42a-66fe44289322"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9260), new Guid("de94e030-b177-471a-9cba-ad326afcc540"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("db396cd5-5e74-4f6a-a4a0-b6f1843a22c4"), true, new DateTime(2024, 4, 4, 13, 36, 2, 819, DateTimeKind.Utc).AddTicks(9276), new Guid("63112c0d-7c05-4c7d-b131-83ed292fd7ba"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EmployeeId",
                table: "Notifications",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Employees_EmployeeId",
                table: "Notifications",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Employees_EmployeeId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_EmployeeId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("02b32613-7012-4bee-8020-58d4e01104d7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("18184b5e-997c-42de-8970-e7ec7efcc14c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1ca424ff-195b-4a64-ba5e-5bcc119a3bde"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2d507a40-4d60-44d3-9df4-1e452b639c66"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2fa5c425-94fb-4e57-9cf2-6804f24fc813"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("37710c14-e547-4a6d-b1cb-222735cadaad"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3dcba80b-462b-40bb-9419-89693dcf4351"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("465cd6cd-e24c-4511-a5e8-50562445fd96"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("46ed4c9a-38ed-42fb-a399-c684e1cecca2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4a6caed1-4bb4-405d-9484-72c6ff979b52"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4e942bc8-5762-4867-8177-ef47ad5e6753"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5763d365-446e-40e6-a880-7b1c9357fd76"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("69546cef-c08a-4af0-a68c-3b0bcc4fa9cc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6df9b320-7652-4ddc-a28b-91325b74cdc5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6f2f8ef2-1000-423f-b073-ff4396ee57a5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("862e553a-8003-4d7a-a85f-7cf207008326"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("87a6efa2-e8b1-446e-81a0-bf9582b454b4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a4b8a121-1390-4172-92e1-85251679aba0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a6f724b3-1082-48ce-8cd8-2ef84a2ef471"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ad0ed264-9fb0-4fce-9eef-86047b6173bf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c0da9145-c97c-4018-8406-ce1693730a38"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c5710e69-8c8e-4ac3-b633-f59a7da3f4ee"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d25e8f9b-9e99-4c7a-a42a-66fe44289322"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("db396cd5-5e74-4f6a-a4a0-b6f1843a22c4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("1bf416d9-e40b-4d4a-b097-f09117949b6a"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8070), new Guid("ce2483e8-4884-4b98-ba63-1f8d044d1cdd"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("241b1038-3123-42cc-aaf9-50a59f4f34c1"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8047), new Guid("dd3aafd6-b55b-429c-ba35-c646954fa3d9"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("28c0f9c5-b4ba-4b71-b7f1-e76344365c41"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8046), new Guid("761e2c76-40c8-481c-bf96-1708ddf93ccf"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("2f46821a-78e3-45ec-ba46-ec1106f1d232"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8030), new Guid("14afcb7b-d097-4421-8c7a-558015df90b8"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("34ebc955-9bea-4eb0-b904-3ff9f3a88d2e"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8057), new Guid("1fb38da2-59eb-4b04-bb8e-37d76b6b75ec"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("4fe0ecbc-0b67-41b1-876e-00123f843cd1"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8049), new Guid("b64352d8-156d-4ba6-ae1f-49dce35bba22"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("55b5e741-5168-44b3-9520-ff165584e99e"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8083), new Guid("b4ec5d11-b53d-4d72-a953-771078ad8fae"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("61069dd9-f460-43d6-b9e3-3b71aacd5edc"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8067), new Guid("12b04083-cf49-455d-94c5-ea431d9a49c2"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("64b7c041-fdb0-48bc-bc0e-7be26bd0d3f1"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8062), new Guid("404d75f0-8e37-41ff-8b49-2bd99ed06b25"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("8b57e242-55c2-4355-8daa-dcfd6bf533f9"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8079), new Guid("67a672a2-7615-469c-b807-249e7fbca2cc"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("9719f43b-f83c-4ce3-93af-5181500288bb"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8060), new Guid("a72049ae-6c1a-4419-abed-00ac07c98310"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("a7a396c4-ef27-47c9-a9ff-7b56855df481"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8081), new Guid("244ceea4-ca5b-4644-97e7-babe7ecb67cf"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("a8030b50-0039-45a3-905d-0b0efd82836d"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8054), new Guid("bba9db5c-241d-47b5-8b6a-6ad51a8ae0bc"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("a8463611-ea1f-4eb9-ac8b-5a19c8c8c771"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8032), new Guid("dd23a8df-55a1-4ad7-8cd8-22bc6430d148"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("b295c39f-cd4e-40a8-baf1-95f9e5f1eed0"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8074), new Guid("0540d4a7-f655-4631-94c8-bbb72d30e86b"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("b3e79630-6364-4f60-94e9-c57688a0e8c7"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8055), new Guid("d4b483a3-5bbd-4bea-b776-68eac5d8504b"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("c488be4e-105d-42a0-8b3d-44e4ee2581b9"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8077), new Guid("6d31da22-a2ae-4ba9-a3b1-2a1a57fa745c"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("ccefbf45-e67a-4f03-9371-80f81c9721ac"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8068), new Guid("187b16c7-4bad-42e6-ac0e-1aaf40900a90"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("d051d04b-74c0-4318-9f50-46f1e0c647ea"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8078), new Guid("79b4208b-3eef-4d67-aca6-0900791908a6"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("e72b2818-83d2-4cc9-9ca8-302f052e4efb"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8052), new Guid("d086feed-4608-49a9-8579-598e85917dd4"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("ec462923-2366-45ba-8bc2-c0739ae4452d"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8044), new Guid("2c351c67-8977-4c65-9fda-93283bee069f"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("ed5fc04c-e768-4b06-ae4f-376e731ecca1"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8064), new Guid("27dc9a77-6a47-4f9e-aebf-2d8f70b57e8a"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("f67bc5fb-5229-4f79-8496-a875c72498ad"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8025), new Guid("7818829b-b71f-427e-bd2c-cf62a12d92c0"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("f6f0fc5b-ad46-4317-b428-009a21355d2d"), true, new DateTime(2024, 4, 4, 13, 16, 4, 971, DateTimeKind.Utc).AddTicks(8061), new Guid("4af94831-a261-469c-9632-e1036995205f"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" }
                });
        }
    }
}
