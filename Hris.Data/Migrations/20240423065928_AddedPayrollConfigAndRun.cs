using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPayrollConfigAndRun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0aaa97af-b1b1-454e-9d20-b699e69d4d39"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3480), new Guid("2310d17b-bc98-41d8-b106-141065234988"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("16a0864c-8710-4e4a-86df-0c1a71a3bcec"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3498), new Guid("c867ca30-e900-4daa-a4d5-fa608e0c108d"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("18ef96a4-ac71-4bb9-91e3-7dcfad8b2a36"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3522), new Guid("333feb9d-4725-4723-b3e1-9e2300289b4c"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("218ccb79-8fc4-4b2d-a240-d717d1f8a1e2"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3508), new Guid("64552aca-21c4-4265-9b11-829ea6767dc9"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("21f7dc82-5a0d-4aeb-9822-5d007396f758"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3510), new Guid("c8a6e07c-dca5-40bb-9051-9ae08e4551a6"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("263c0c9b-a0ab-4bc7-95af-50019786e6d3"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3493), new Guid("4fa15c33-a5bb-4e55-803c-5e078eb43f10"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("2cd31e9e-90cc-40b9-a939-b164386ac02d"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3518), new Guid("07ca6a93-fca9-4914-b680-849cb0b50c96"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("315244e2-d750-476f-8881-ad036e8132c1"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3507), new Guid("43d79ffc-0d06-4bdc-9923-58ba6a4980ba"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("3c55b80f-153e-4eb1-94df-b43f9833d3e7"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3515), new Guid("8c4ec109-dc70-4c0e-82b3-0b8c17a9d82d"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("3df530e4-ed7f-4de1-9319-d01d467cba63"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3487), new Guid("c62c8550-5cf8-48a6-80ac-45c9d5ffecdc"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("4fdd328b-804e-4775-aa0c-84a28571c22a"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3478), new Guid("6fa28efa-2e2e-4133-9557-c472f1dcd4d7"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("5479f34b-9721-4160-95de-a9d652fe4177"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3514), new Guid("24e89552-b0db-4b18-bc39-96cc1583513a"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("559a0fb2-64af-437b-8742-7c23d2aa1a6c"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3477), new Guid("83938f05-6b0d-4eed-b95a-a11a9c6aff2e"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("66c2a3c5-a00f-4a0e-b8d0-a5a19e432ad7"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3506), new Guid("e4c4830f-f787-4831-86e2-5e1a4f7cc736"), "Payroll", "Payroll Run", "Payroll-Run", "Admin,Hr" },
                    { new Guid("6d2ec8f6-c63c-4ed9-b6f8-fadcc9f969d4"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3495), new Guid("7f7bd3ae-3760-459e-9906-4b10ce1adbcc"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("70d8d039-1fd1-406f-9e75-0c76ef8571be"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3454), new Guid("76a2fdba-62fa-4023-9ef4-3dc8969f62aa"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("73861cd9-aeca-490d-a43f-ba6ed4d9cd0c"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3513), new Guid("3bf1b4f4-361d-413e-a975-2baaa5f20bbb"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("7b1317d5-76cb-4932-bbd9-4195fd956422"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3460), new Guid("75bdc28e-9eea-481f-b83b-a2accaf9d940"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("8946f951-70f8-4a9e-9dce-66b869ae32d7"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3499), new Guid("ec56ab3a-fc9b-4aae-8e7d-2241d5aa3c15"), "Payroll", "Loan Types", "Loan-Types", "Admin" },
                    { new Guid("99003342-f4fe-4cf2-92ec-be45f197baf5"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3494), new Guid("8eb6eb26-da36-480c-96c4-76768a7c0041"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("9b2df3a9-f138-4208-977a-a3db712ca28a"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3488), new Guid("c1aa150f-d99c-4561-9c78-52d32fe4aed3"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("a09f37e9-5c07-446e-8b00-13eebb553d70"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3484), new Guid("b5ddbdf4-7d0f-48fc-b5ea-ff0ffeda551b"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("a47f685e-e89f-48c0-ac1b-f39df77fb2d9"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3475), new Guid("9bfaf6b7-9010-421f-b573-04a97c6ee2fc"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("a73a4da9-2adf-4d5f-8f42-ead6d41037a1"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3501), new Guid("fd8f76de-1a7a-4215-856a-455c8c130deb"), "Payroll", "Employee Loans", "Employee-Loans", "Admin,Hr" },
                    { new Guid("b44b68ac-b2ed-4d9e-b30f-0251aae4d3ef"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3502), new Guid("831a2ef7-f9c2-44f7-abcc-26b22d7b6ea6"), "Payroll", "Payroll Configuration", "Payroll-Configuration", "Admin,Hr" },
                    { new Guid("c57276c7-5dad-44fd-895f-9f8ef3b5bfda"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3458), new Guid("f948d1a9-b0bc-46b2-b692-cbfe90c51109"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("ddc167a1-05a7-4cab-b060-4135511e2dea"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3521), new Guid("dfc3d889-44f9-4f5d-98a7-c1cba1c71688"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("f458cdf5-e977-436c-94bd-b00e305006a7"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3483), new Guid("4f93dcae-d3b8-4eca-bf59-a8fa6065f539"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("f8b10bc6-7c21-4038-8a6b-2bf078a93dd2"), true, new DateTime(2024, 4, 23, 6, 59, 27, 844, DateTimeKind.Utc).AddTicks(3491), new Guid("218dc6eb-a3ae-493c-921f-35d07341b612"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0aaa97af-b1b1-454e-9d20-b699e69d4d39"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("16a0864c-8710-4e4a-86df-0c1a71a3bcec"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("18ef96a4-ac71-4bb9-91e3-7dcfad8b2a36"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("218ccb79-8fc4-4b2d-a240-d717d1f8a1e2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("21f7dc82-5a0d-4aeb-9822-5d007396f758"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("263c0c9b-a0ab-4bc7-95af-50019786e6d3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2cd31e9e-90cc-40b9-a939-b164386ac02d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("315244e2-d750-476f-8881-ad036e8132c1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3c55b80f-153e-4eb1-94df-b43f9833d3e7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3df530e4-ed7f-4de1-9319-d01d467cba63"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4fdd328b-804e-4775-aa0c-84a28571c22a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5479f34b-9721-4160-95de-a9d652fe4177"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("559a0fb2-64af-437b-8742-7c23d2aa1a6c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("66c2a3c5-a00f-4a0e-b8d0-a5a19e432ad7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6d2ec8f6-c63c-4ed9-b6f8-fadcc9f969d4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("70d8d039-1fd1-406f-9e75-0c76ef8571be"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("73861cd9-aeca-490d-a43f-ba6ed4d9cd0c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7b1317d5-76cb-4932-bbd9-4195fd956422"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8946f951-70f8-4a9e-9dce-66b869ae32d7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("99003342-f4fe-4cf2-92ec-be45f197baf5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9b2df3a9-f138-4208-977a-a3db712ca28a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a09f37e9-5c07-446e-8b00-13eebb553d70"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a47f685e-e89f-48c0-ac1b-f39df77fb2d9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a73a4da9-2adf-4d5f-8f42-ead6d41037a1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b44b68ac-b2ed-4d9e-b30f-0251aae4d3ef"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c57276c7-5dad-44fd-895f-9f8ef3b5bfda"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ddc167a1-05a7-4cab-b060-4135511e2dea"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f458cdf5-e977-436c-94bd-b00e305006a7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f8b10bc6-7c21-4038-8a6b-2bf078a93dd2"));

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
    }
}
