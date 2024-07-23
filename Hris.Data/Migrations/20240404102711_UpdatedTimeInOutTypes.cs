using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTimeInOutTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<long>(
                name: "TimeOut",
                table: "ShiftSchedules",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "TimeIn",
                table: "ShiftSchedules",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TimeOut",
                table: "ShiftSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "TimeIn",
                table: "ShiftSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
        }
    }
}
