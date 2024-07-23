using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdates1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("03054d48-3a11-4854-942f-576eeb8cbf79"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0c70df34-7580-4b20-8cc6-9212164e42f2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("10f83735-b379-4112-bd0d-6774a58f8b43"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("11f7da03-cb7e-4877-acce-94ff1eb76813"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("19e6bcb3-0b88-4993-ac96-7b92b6c3268d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("20eff6d9-5c8d-46f0-a5fa-0e145a9ebad9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2d705371-cb35-42c0-9dbc-c409078f3418"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("31d8f427-64a0-49ef-82c5-0b49f805a42a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("45f08d90-f099-440b-8a6e-d569d26da1ac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("55073a09-42c1-4b8c-9263-fe359a79c6a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5b49a5f7-2eab-46c4-89c7-c0e7d3375a04"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("870c9b6f-206f-429b-9ba6-b250de07b0eb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("99dc6029-685c-4f3b-8799-20ca496d5800"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9a326a4d-e72c-4a39-a0e8-ffd858757613"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("abf233e1-75cc-4414-8eb7-95eaea9c311e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b407da2a-9248-4e27-95a7-696f984fcc3a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ba7f319a-9844-4cbb-9011-ca72910b2ad0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c38d741e-2f55-49d2-8094-99cabc8ebc3a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c5e27785-dd09-420c-8012-b9a5f669f777"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cc92f152-2cb7-448d-9fe1-125004698818"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e01b7ff2-5077-4a08-b327-339f35130343"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("eafacb1a-f3e1-4b85-bc48-1152842169fe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f0f434a4-496f-422e-a9be-c907cc0982e9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fe3f1ce4-64e2-4f55-88f5-b34c5d3089a5"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShiftScheduleId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("0051be27-5db9-47ea-9b9f-a076ee42b866"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1963), new Guid("fbc58929-6ece-4bcc-a70d-d7299044884f"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("10e0c164-a0c7-4da0-a346-5bef937f04d7"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1952), new Guid("1af3ce4d-2c05-48d0-80b5-104a910f32af"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("29f4c9e0-40e3-4334-bfa0-2867c4422cf1"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1931), new Guid("34b04726-8359-4993-9f88-ea378ccb5861"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("3c4f5ee3-7188-4a53-86cb-8cfafbc91e94"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1940), new Guid("b88e44db-4de2-497d-8efc-bc59b008f9c8"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("3cf8d2d3-22e3-498e-8433-d855f5fc25db"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1936), new Guid("88aa0afb-f435-4de5-a3e3-97e264e8aebe"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("49059b7f-3b86-46a7-8960-ce85502ebac3"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1961), new Guid("700adb38-615d-4197-8db5-62cfa9ab3aca"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("5aee2c28-f8cb-426a-ad64-64a725aae1e9"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1937), new Guid("4acf2bff-1b3c-40d2-b26c-f97026dd3271"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("6c6ac937-8309-4969-b387-723164224ead"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1942), new Guid("8a84f590-edf7-4f03-8bb1-492925a0e20f"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("71df2169-98df-45da-bc52-72c4e9c8483c"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1927), new Guid("f3c6ac96-89ba-4e42-867a-7ce67a61ae1e"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("7b6cc196-c9cc-4e7e-9785-9f0ee26439b5"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1955), new Guid("763e3d03-066e-4356-85b7-d3ceb8c65290"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("8c8a0a5c-b1a1-49e4-a2a1-8f65fc26b46d"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1953), new Guid("edc4608e-d1f6-4bc5-90bf-7bf4714de42c"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("93aa7473-9be8-4607-a4d0-20f68076468a"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1944), new Guid("cceade0f-bb8b-4187-a577-a79dcbc9ad5b"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("a325296b-b031-4e88-a564-4b884cd6f662"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1962), new Guid("af6c8c21-63ba-45e4-9282-0e9d7595c62a"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("a3f2ba50-eabe-4294-bfad-00f843674537"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1957), new Guid("f5753d36-4d9c-48cf-b766-d98964096ad9"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("a50d74c9-9edb-475f-9e09-e5991548ca82"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1951), new Guid("f5f6514d-523f-41aa-9bf6-6ce2e6da3842"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("a5bb0284-f001-4481-a4f7-4fbc5c705409"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1948), new Guid("86866258-3b06-4daf-964c-e3c881cd7ab5"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("a7fa101a-f055-4d89-b3bf-08d4a820a514"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1964), new Guid("ea68b625-f42c-463b-adbf-c3df33a7f0cd"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("ac027744-ea99-4308-98bc-531268b9444a"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1929), new Guid("7585ce3e-3b04-4a68-9a9a-0baf0a4fdfe2"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("b0dd245b-6bca-48c1-a793-eee5756b10c0"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1924), new Guid("0ba21e08-dbb2-477f-9848-28a567c4991d"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("c3a9b346-e1e8-477e-85bc-747fe6676a8f"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1959), new Guid("1de025aa-7940-4be4-a658-512e65c22f4e"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("c8eb3be6-b5e2-4c56-b2ee-29914d273545"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1934), new Guid("179b3b5d-73e1-4504-985f-ee61e874c05d"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("ccbd3759-f2dc-4f76-92c4-c0fcd92ce9a6"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1945), new Guid("7b9aa8ca-0234-4c5c-a025-563a369e3996"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("cff79037-4cd7-42be-957b-d54af56080e8"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1946), new Guid("94626cad-003b-4fee-98d7-6ec3a8b10d32"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("d522e4ca-203b-4e45-ba40-18e0c9dc0d91"), true, new DateTime(2024, 4, 4, 8, 46, 29, 991, DateTimeKind.Utc).AddTicks(1958), new Guid("4eec2ba1-2e9d-4db3-9419-923268441eb5"), "Admin", "Permission", "Permission", "Admin,Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftScheduleId",
                table: "Employees",
                column: "ShiftScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ShiftSchedules_ShiftScheduleId",
                table: "Employees",
                column: "ShiftScheduleId",
                principalTable: "ShiftSchedules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ShiftSchedules_ShiftScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ShiftScheduleId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0051be27-5db9-47ea-9b9f-a076ee42b866"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("10e0c164-a0c7-4da0-a346-5bef937f04d7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("29f4c9e0-40e3-4334-bfa0-2867c4422cf1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3c4f5ee3-7188-4a53-86cb-8cfafbc91e94"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3cf8d2d3-22e3-498e-8433-d855f5fc25db"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("49059b7f-3b86-46a7-8960-ce85502ebac3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5aee2c28-f8cb-426a-ad64-64a725aae1e9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6c6ac937-8309-4969-b387-723164224ead"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("71df2169-98df-45da-bc52-72c4e9c8483c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7b6cc196-c9cc-4e7e-9785-9f0ee26439b5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8c8a0a5c-b1a1-49e4-a2a1-8f65fc26b46d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("93aa7473-9be8-4607-a4d0-20f68076468a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a325296b-b031-4e88-a564-4b884cd6f662"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a3f2ba50-eabe-4294-bfad-00f843674537"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a50d74c9-9edb-475f-9e09-e5991548ca82"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a5bb0284-f001-4481-a4f7-4fbc5c705409"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a7fa101a-f055-4d89-b3bf-08d4a820a514"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ac027744-ea99-4308-98bc-531268b9444a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b0dd245b-6bca-48c1-a793-eee5756b10c0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c3a9b346-e1e8-477e-85bc-747fe6676a8f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c8eb3be6-b5e2-4c56-b2ee-29914d273545"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ccbd3759-f2dc-4f76-92c4-c0fcd92ce9a6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cff79037-4cd7-42be-957b-d54af56080e8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d522e4ca-203b-4e45-ba40-18e0c9dc0d91"));

            migrationBuilder.DropColumn(
                name: "ShiftScheduleId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("03054d48-3a11-4854-942f-576eeb8cbf79"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5367), new Guid("b05ae7b3-a226-46a5-977a-8b5ade6f6fa3"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("0c70df34-7580-4b20-8cc6-9212164e42f2"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5364), new Guid("7a92fa3d-e529-4f6a-b7ca-91326daa8a32"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("10f83735-b379-4112-bd0d-6774a58f8b43"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5342), new Guid("dd6294b8-64b9-4f6a-b904-a4bb3b255bc6"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("11f7da03-cb7e-4877-acce-94ff1eb76813"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5362), new Guid("6e72ad72-9aec-47fa-8382-f3f08eb40d9f"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("19e6bcb3-0b88-4993-ac96-7b92b6c3268d"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5350), new Guid("22319b2f-e99a-4c30-a805-639b0b8bdddf"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("20eff6d9-5c8d-46f0-a5fa-0e145a9ebad9"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5351), new Guid("d8dd9834-588b-41d3-a263-8ba2eaf81ce2"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("2d705371-cb35-42c0-9dbc-c409078f3418"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5358), new Guid("86cab6fa-25f6-4dcf-b627-7c272ce1c014"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("31d8f427-64a0-49ef-82c5-0b49f805a42a"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5356), new Guid("2add908c-9597-423b-a22c-43e2c7e83b61"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("45f08d90-f099-440b-8a6e-d569d26da1ac"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5365), new Guid("6350b4b0-ef92-493b-ade8-d806dd11882a"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("55073a09-42c1-4b8c-9263-fe359a79c6a2"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5330), new Guid("ea6dae29-87bc-44fe-9ce0-1bf19cbd8fe9"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("5b49a5f7-2eab-46c4-89c7-c0e7d3375a04"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5344), new Guid("d31a3c95-6b92-4c65-aeb4-b12650e1a124"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("870c9b6f-206f-429b-9ba6-b250de07b0eb"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5316), new Guid("ba45a5c8-1ba5-4c7c-b8bd-004adb264186"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("99dc6029-685c-4f3b-8799-20ca496d5800"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5347), new Guid("29e9fb31-bbb2-4ba4-834e-414888c926a5"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("9a326a4d-e72c-4a39-a0e8-ffd858757613"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5339), new Guid("f38a567b-2979-48f3-8091-b03c64c139bf"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("abf233e1-75cc-4414-8eb7-95eaea9c311e"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5317), new Guid("e5a52a93-2459-418f-ba0a-7c9f5ba2faa7"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("b407da2a-9248-4e27-95a7-696f984fcc3a"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5348), new Guid("c9297416-ecfc-40fa-a832-1b66e1367acf"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("ba7f319a-9844-4cbb-9011-ca72910b2ad0"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5355), new Guid("1abe06e5-1a45-4b5f-b16b-26345efde1c9"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("c38d741e-2f55-49d2-8094-99cabc8ebc3a"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5314), new Guid("a0a3017c-afbb-47c8-b118-cbf0c38f8767"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("c5e27785-dd09-420c-8012-b9a5f669f777"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5334), new Guid("19ff400d-aa16-4eaa-8a60-c3f4fe88901b"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("cc92f152-2cb7-448d-9fe1-125004698818"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5335), new Guid("c63c7ed0-137f-4f4f-abbd-7348843b35ec"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("e01b7ff2-5077-4a08-b327-339f35130343"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5310), new Guid("42795727-1e4d-4c18-915b-4b4168a46170"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("eafacb1a-f3e1-4b85-bc48-1152842169fe"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5332), new Guid("0a9addeb-d4f5-404d-9685-5d4f21cdb612"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("f0f434a4-496f-422e-a9be-c907cc0982e9"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5341), new Guid("40e3446a-976d-46d9-9fb0-e32e0e9c07f3"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("fe3f1ce4-64e2-4f55-88f5-b34c5d3089a5"), true, new DateTime(2024, 4, 4, 8, 43, 27, 591, DateTimeKind.Utc).AddTicks(5359), new Guid("147168fa-b948-4e6f-83cb-c7c7baba40c8"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" }
                });
        }
    }
}
