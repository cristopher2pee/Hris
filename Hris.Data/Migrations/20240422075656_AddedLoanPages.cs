using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLoanPages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("01fee400-f45b-4cda-ac65-a1235560f9fb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("09845c05-603f-4772-beea-f26ce01fa6cf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a1e0f35-77f3-4171-b663-fd89e5a782a7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0f70fc78-70c0-4c19-9601-2151e9cc5d08"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1d80c167-39d1-4895-8cb1-eb902bce3af8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("26109092-c849-4053-8705-19ee5bf2502a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2bfca789-5c82-4f83-997c-5bb62c5cf24e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("387d7a20-638e-438e-be9f-c94d10f2a911"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3ef2f8fc-6213-4467-ae65-33d8d10fb23a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4db0c1a4-ea6e-4dcb-a9e1-7ed82453b613"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("77fccf7a-07e0-4caa-9f16-c054bf347dbd"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8110cd1a-986b-4398-ac44-49788cd6033c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8e15be20-db4d-4116-a97e-42b7ffa2796e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8ea360ce-9ecd-4af5-91a4-1def1cf8105c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aa9d96be-3793-4cc2-8c83-63557d3a1fad"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bc14d014-17b8-47fd-a898-af5dde116c0f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c4813b9f-d036-462d-9e9f-8bc76835e7f9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c9b73298-60fd-4375-b50d-fc474d97dc92"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cb66be63-77e5-4cbd-9d70-af571d5b9717"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d3a0d318-1ea7-49c4-abb6-b0bee083153e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d772ae27-31fe-4912-9301-2ed5868ef479"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d90f6572-720c-48c3-8a20-79aeb559c88d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e12d6c3f-9a0a-43b2-8b77-4e59f0888251"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e2a6fa50-fbae-4d5a-a4a8-064ce5425b08"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f04c4bc0-9d27-4573-b41d-c2038702da68"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("0a4d6891-2c9f-4aa7-9ffc-bffca6be06ed"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9751), new Guid("a0304fbb-bb8a-4cf2-bbec-393c2846ab62"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("157e6253-188c-4442-8416-32b2238f3522"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9740), new Guid("8b1823a3-6183-41dc-8b4b-4bee520ccffe"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("16946521-1d20-4656-ab5f-9f0242d28b74"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9765), new Guid("2f55b05b-ff92-46ca-9392-7ce9cb564aa7"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("2e4618f1-51cd-42de-9b86-24c1ded089c0"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9757), new Guid("7482caf6-e6d9-49ae-8aca-f04da84dc3d5"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("3d356580-9587-40b7-9096-6948eba9d548"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9759), new Guid("3b034a68-73b3-4a93-800d-a62a73131fb6"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("484848d9-af0a-4dad-a2f5-30339fe2d8e7"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9743), new Guid("1dc5d6da-34bf-406f-be90-4e33542a2b9a"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("50eed148-d08b-43e3-8fbf-14c6f9c1c6b9"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9767), new Guid("4f3c3762-c7bd-4a93-a96f-da2818b0972f"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("532c4e35-3b4c-4d6b-9754-6fa98e9b6790"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9755), new Guid("04773082-1186-435a-92ff-980b8779d3bf"), "Payroll", "Employee Loans", "Employee-Loans", "Admin,Hr" },
                    { new Guid("5b57aaac-065c-46a7-a59e-badb17ad4749"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9760), new Guid("8065f776-d1a2-4d55-920c-335cd5eafac8"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("61ab324f-b5e7-48ba-b6f2-a4e1b7d414ec"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9738), new Guid("53af9242-47fa-4b5c-95d3-90bdc4df1f5b"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("62afb273-708a-46a0-a182-6ce8eb2e8583"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9762), new Guid("36ba46be-153c-4af9-a727-8a1b6dd7a986"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("62c5b248-5768-4ea8-8cd6-3f0e2195b616"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9741), new Guid("0915a07f-79a3-4a1a-851c-ed67cd39adcd"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("72015ce2-8ae8-4291-8b70-d13d7f435047"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9731), new Guid("36dcf2c1-9755-450d-9543-7a1f32438c6b"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("7c961e13-4c6d-4572-84e9-a1de92a61c4c"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9729), new Guid("5d33baaf-372d-42e3-8653-43bd0c8cbd1f"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("8b9a4732-1b2b-48ce-8c6d-0c641ebc72a4"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9761), new Guid("9764e83b-ccf1-4d7f-b466-edf29f2438da"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("8c5485c0-cacd-46ba-b353-f7f6fca7adfe"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9750), new Guid("7597aa6c-c0d8-4b00-9015-470ca11e092f"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("9efdc5bf-29d3-483f-9796-f2bf569a58a7"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9737), new Guid("41a1105c-12b6-4f78-bfe5-a3f4921e2edf"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("a12e29b8-63e0-4d7d-a4b6-50ae26882ace"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9726), new Guid("dbd5173c-ac4e-4e00-89bc-c49ef3e0c848"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("a2335c7a-e1ab-4c1c-a7af-6181ea19c0c0"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9734), new Guid("f0318d25-bd27-4d5e-ab9e-5b9aa5bf97ac"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("b016de6d-31a7-40b2-9370-6819147500f3"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9766), new Guid("569b40a4-edc8-43a9-911e-19bd1039897d"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("bbc0fc22-1fba-45e6-a77d-8d330ea3a251"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9756), new Guid("4e09cf6c-fe39-48c6-a346-fed1bacdb618"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("dbc53ff3-c695-4b96-aff1-c5d72d49ce57"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9730), new Guid("751140b0-c8bd-4ca2-8a60-7ef8a81e369d"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("e4e17bc0-7b98-441a-9235-6bc9bf31ea86"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9736), new Guid("bda8cebc-2589-4424-8da8-ed2d7ecd583c"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("f4443bf2-a570-4434-b108-2e730cd32bd9"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9742), new Guid("b3d8a7db-aa7c-4598-af6c-5a6e447e8363"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("fafcd88e-ea44-4d3d-ae9a-869ed747c52d"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9747), new Guid("443e48b2-91c5-4518-b299-c358a25f029c"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("fcdb723c-d3da-4873-bd69-a07d63d6a1cf"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9754), new Guid("fd77822e-fd93-4dd6-9306-9eb3924735ec"), "Payroll", "Loan Types", "Loan-Types", "Admin" },
                    { new Guid("fdac5eda-a6aa-4e3e-9fc2-0867c11a2e7f"), true, new DateTime(2024, 4, 22, 7, 56, 56, 219, DateTimeKind.Utc).AddTicks(9746), new Guid("0e0ab682-a011-4e61-a723-f79f9408d458"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a4d6891-2c9f-4aa7-9ffc-bffca6be06ed"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("157e6253-188c-4442-8416-32b2238f3522"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("16946521-1d20-4656-ab5f-9f0242d28b74"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2e4618f1-51cd-42de-9b86-24c1ded089c0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3d356580-9587-40b7-9096-6948eba9d548"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("484848d9-af0a-4dad-a2f5-30339fe2d8e7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("50eed148-d08b-43e3-8fbf-14c6f9c1c6b9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("532c4e35-3b4c-4d6b-9754-6fa98e9b6790"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5b57aaac-065c-46a7-a59e-badb17ad4749"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("61ab324f-b5e7-48ba-b6f2-a4e1b7d414ec"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("62afb273-708a-46a0-a182-6ce8eb2e8583"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("62c5b248-5768-4ea8-8cd6-3f0e2195b616"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("72015ce2-8ae8-4291-8b70-d13d7f435047"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7c961e13-4c6d-4572-84e9-a1de92a61c4c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8b9a4732-1b2b-48ce-8c6d-0c641ebc72a4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8c5485c0-cacd-46ba-b353-f7f6fca7adfe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9efdc5bf-29d3-483f-9796-f2bf569a58a7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a12e29b8-63e0-4d7d-a4b6-50ae26882ace"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a2335c7a-e1ab-4c1c-a7af-6181ea19c0c0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b016de6d-31a7-40b2-9370-6819147500f3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bbc0fc22-1fba-45e6-a77d-8d330ea3a251"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("dbc53ff3-c695-4b96-aff1-c5d72d49ce57"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e4e17bc0-7b98-441a-9235-6bc9bf31ea86"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f4443bf2-a570-4434-b108-2e730cd32bd9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fafcd88e-ea44-4d3d-ae9a-869ed747c52d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fcdb723c-d3da-4873-bd69-a07d63d6a1cf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fdac5eda-a6aa-4e3e-9fc2-0867c11a2e7f"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("01fee400-f45b-4cda-ac65-a1235560f9fb"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8672), new Guid("5786ee00-debd-401b-a1a0-7e5f93972fbb"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("09845c05-603f-4772-beea-f26ce01fa6cf"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8711), new Guid("c4677a73-dc48-455d-b3dc-076a273f363d"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("0a1e0f35-77f3-4171-b663-fd89e5a782a7"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8696), new Guid("3102cd65-6f68-40bc-9899-9427538abf9e"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("0f70fc78-70c0-4c19-9601-2151e9cc5d08"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8693), new Guid("0b9b91f8-e6ca-4ce4-9ffe-62aaf1e11d55"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("1d80c167-39d1-4895-8cb1-eb902bce3af8"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8687), new Guid("57d412d9-83f5-42f4-9870-702de857a299"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("26109092-c849-4053-8705-19ee5bf2502a"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8692), new Guid("7af325f3-ec58-4f5d-9581-e520f5ed61a8"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("2bfca789-5c82-4f83-997c-5bb62c5cf24e"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8679), new Guid("c685c429-3976-4c09-b4a9-d42343d69596"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("387d7a20-638e-438e-be9f-c94d10f2a911"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8703), new Guid("38b8ba44-2235-4d03-aa7b-0e3e84761c92"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("3ef2f8fc-6213-4467-ae65-33d8d10fb23a"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8670), new Guid("44c71dc6-dfad-4c5c-8548-032044a15083"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("4db0c1a4-ea6e-4dcb-a9e1-7ed82453b613"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8694), new Guid("e3fe9c05-d1b5-42a7-8be1-6a5cb333c234"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("77fccf7a-07e0-4caa-9f16-c054bf347dbd"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8677), new Guid("b745b6dc-eb7e-437f-a181-da6f3fb480cd"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("8110cd1a-986b-4398-ac44-49788cd6033c"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8705), new Guid("b181022d-5c18-48b8-84e3-cf6192d1f44f"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("8e15be20-db4d-4116-a97e-42b7ffa2796e"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8676), new Guid("146b2a54-8df4-4d08-9f29-1dcf020c697b"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("8ea360ce-9ecd-4af5-91a4-1def1cf8105c"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8706), new Guid("a4a8e57d-e610-465d-a9cc-4521dfcb396b"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("aa9d96be-3793-4cc2-8c83-63557d3a1fad"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8713), new Guid("fa080d2c-bd79-4e96-bad9-1cc40600c52f"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("bc14d014-17b8-47fd-a898-af5dde116c0f"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8643), new Guid("94860370-73e1-4711-b8ae-c799a4f3a926"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("c4813b9f-d036-462d-9e9f-8bc76835e7f9"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8689), new Guid("13eee6ee-094e-48a1-abdc-f8fbd627549a"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("c9b73298-60fd-4375-b50d-fc474d97dc92"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8659), new Guid("ed6bb387-39d9-4e83-b44f-800de397283f"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("cb66be63-77e5-4cbd-9d70-af571d5b9717"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8709), new Guid("693bc293-d90c-410f-8690-96758b37e7af"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("d3a0d318-1ea7-49c4-abb6-b0bee083153e"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8684), new Guid("1e12805f-be14-4648-b645-fbf3a1a6a734"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("d772ae27-31fe-4912-9301-2ed5868ef479"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8647), new Guid("582f813a-3efe-4ce7-8e82-949ad83f573a"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("d90f6572-720c-48c3-8a20-79aeb559c88d"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8683), new Guid("a32a2ffa-ced0-4c30-9943-af950794facb"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("e12d6c3f-9a0a-43b2-8b77-4e59f0888251"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8700), new Guid("c242228f-bac8-48dd-98fe-081a0dbf648b"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("e2a6fa50-fbae-4d5a-a4a8-064ce5425b08"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8680), new Guid("784a44b6-7f61-4243-9184-bcc4a75e4a87"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("f04c4bc0-9d27-4573-b41d-c2038702da68"), true, new DateTime(2024, 4, 18, 4, 14, 30, 444, DateTimeKind.Utc).AddTicks(8668), new Guid("8462d9f7-1062-4f1e-a72f-c1fbd5a2ea16"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" }
                });
        }
    }
}
