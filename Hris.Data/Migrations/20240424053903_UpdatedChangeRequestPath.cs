using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedChangeRequestPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0439e4c0-d3d7-411d-8b70-218f84fd6219"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9787), new Guid("808c2c26-e4ff-4f7b-b82d-a260bd633ae2"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("0de178cf-6fe4-4c07-a2d5-be31f5936d2e"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9773), new Guid("0bdd7f35-7fdc-47d2-bd26-c413a97cba43"), "Payroll", "Payroll Configuration", "Payroll-Configuration", "Admin,Hr" },
                    { new Guid("0f81a480-d273-4e38-afdf-e083cd43fafe"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9756), new Guid("88e8a15b-6674-46e1-bad4-4c72eab09395"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("142d7fea-762f-44de-a797-e2237f72be8c"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9775), new Guid("decacb97-289b-4b2e-8b66-f6b67ba187f9"), "Payroll", "Payroll Run", "Payroll-Run", "Admin,Hr" },
                    { new Guid("1ac97638-22bd-4801-8242-761f0348719b"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9776), new Guid("5428bb65-daa2-4e69-8584-0696233de3d5"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("1ee68fde-1bc6-45c7-b96c-896131f2913c"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9757), new Guid("af88cfe2-62be-44e2-887c-77df2f0332b5"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("20901f4f-77f8-4d0c-a0d9-196cc1fcc573"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9762), new Guid("34b12d52-3834-461f-8bbc-c7808adf761a"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("21a384cf-fe4d-4aeb-9bad-711857680032"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9751), new Guid("8fd49300-239f-4fdf-a637-aea238627606"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("24df0e51-77b7-4b07-8b89-f34004ca8bf3"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9782), new Guid("48c00e96-a4a2-426d-8a2c-41b018f5e49e"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("27469bc7-6052-4c2b-9017-52c9b0b0aa8e"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9771), new Guid("eaef3fd0-6c06-4daa-90aa-d4a97a0f95cc"), "Payroll", "Employee Loans", "Employee-Loans", "Admin,Hr" },
                    { new Guid("2def4ab4-cd0c-4eaa-8d92-6080c7e9650f"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9753), new Guid("3bc8f59a-98ca-4c5b-b9da-3abecc72be20"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("50101200-6345-4399-be23-48126870a2b8"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9735), new Guid("9aef2684-7376-4828-a5a1-07538b903c9b"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("528d7ac2-4b91-4270-aa95-60595e99d66f"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9785), new Guid("bb61ddb6-116d-4d73-839b-00839f3ba74a"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("5a831da7-ee8e-4696-9e7d-725c385ce0d5"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9749), new Guid("59e1d076-191c-4a3e-9636-512ac70c2f46"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("5b8b3b60-b30a-407a-b87c-7979476b694a"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9780), new Guid("145a2770-7875-4bba-a210-add864baf5c5"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("630d454a-a2a1-438e-8697-8ceaccc36ddf"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9765), new Guid("c4def472-201b-418d-bfd6-0d184d60d36b"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("6d409df4-ee94-43d6-bd6b-f1b7b9cb063e"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9786), new Guid("e7c8545d-fb69-4374-9dc8-5fbbbc60c0d7"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("7011d303-bb0a-423a-91a8-04819a840c99"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9752), new Guid("65dc6e6b-3f6a-4151-89d1-21fd2680c71a"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("76ff3ff7-f9c5-4019-9cc1-676adb7a4db7"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9738), new Guid("d4b2330e-2c30-4f38-a3f3-7605483a89b0"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("7fdf4fac-d4d1-4b25-8691-a47d14726f0e"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9764), new Guid("18eefafc-541e-4a5e-85da-df8ecf0df00c"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("84c8fbd0-2616-44e4-9e31-5582eb3d213f"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9759), new Guid("ec088f6b-06a6-44da-9e92-5adff2e412c2"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("9312ab9c-91a5-4170-ae5a-f3f3cab1aee6"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9783), new Guid("a0ae6b3e-07f6-406d-88fc-4edc10713b4d"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("973a92fc-3efe-4c2e-98cf-04e38d119375"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9768), new Guid("db206340-1a36-4f11-b59c-5cad7699a49a"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("a094d166-7a51-46e7-8b58-50b7dee6ba77"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9770), new Guid("fc3355c7-3db0-44ca-b11d-cba742e06036"), "Payroll", "Loan Types", "Loan-Types", "Admin" },
                    { new Guid("a9121863-4d0a-49e3-a4d3-82795094f3d0"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9758), new Guid("019bff92-f37a-4f9d-99e6-b8b40320ab86"), "Clock", "Track Request", "Track-Request", "Admin,Manager" },
                    { new Guid("b48aabb2-31c0-4fb8-aaf8-9c3f0deaf01a"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9777), new Guid("6ec77dec-6e75-4c62-ae0f-2319ad07b97d"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("c07b120f-cca8-49ff-826a-0de7df5bce13"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9781), new Guid("0706f39e-b765-4670-8a8c-225e17da1309"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("c1b7e3fb-e990-412b-b0b3-63d17bc492b8"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9769), new Guid("648e8afd-affb-445f-9dab-7db4d3d65306"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("d5095cf5-1e9c-4cff-8f64-078a1bb9c2e9"), true, new DateTime(2024, 4, 24, 5, 39, 3, 409, DateTimeKind.Utc).AddTicks(9763), new Guid("a19e63b0-ff7d-4100-874f-2c723cd14eb3"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0439e4c0-d3d7-411d-8b70-218f84fd6219"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0de178cf-6fe4-4c07-a2d5-be31f5936d2e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0f81a480-d273-4e38-afdf-e083cd43fafe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("142d7fea-762f-44de-a797-e2237f72be8c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1ac97638-22bd-4801-8242-761f0348719b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1ee68fde-1bc6-45c7-b96c-896131f2913c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("20901f4f-77f8-4d0c-a0d9-196cc1fcc573"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("21a384cf-fe4d-4aeb-9bad-711857680032"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("24df0e51-77b7-4b07-8b89-f34004ca8bf3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("27469bc7-6052-4c2b-9017-52c9b0b0aa8e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2def4ab4-cd0c-4eaa-8d92-6080c7e9650f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("50101200-6345-4399-be23-48126870a2b8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("528d7ac2-4b91-4270-aa95-60595e99d66f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5a831da7-ee8e-4696-9e7d-725c385ce0d5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5b8b3b60-b30a-407a-b87c-7979476b694a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("630d454a-a2a1-438e-8697-8ceaccc36ddf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6d409df4-ee94-43d6-bd6b-f1b7b9cb063e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7011d303-bb0a-423a-91a8-04819a840c99"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("76ff3ff7-f9c5-4019-9cc1-676adb7a4db7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7fdf4fac-d4d1-4b25-8691-a47d14726f0e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("84c8fbd0-2616-44e4-9e31-5582eb3d213f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9312ab9c-91a5-4170-ae5a-f3f3cab1aee6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("973a92fc-3efe-4c2e-98cf-04e38d119375"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a094d166-7a51-46e7-8b58-50b7dee6ba77"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a9121863-4d0a-49e3-a4d3-82795094f3d0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b48aabb2-31c0-4fb8-aaf8-9c3f0deaf01a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c07b120f-cca8-49ff-826a-0de7df5bce13"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c1b7e3fb-e990-412b-b0b3-63d17bc492b8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d5095cf5-1e9c-4cff-8f64-078a1bb9c2e9"));

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
    }
}
