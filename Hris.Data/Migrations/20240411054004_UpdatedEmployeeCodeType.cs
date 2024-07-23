using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEmployeeCodeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("08fec076-58bb-4038-bb4e-5760d90be08e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a871a7f-cd39-40c3-b4f0-78b7dbd8432b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1672fb59-4666-4df3-afde-a81abd72753e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1f2693d6-25b1-4519-ba06-30e6d84d2e39"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("20f8ff8e-d108-436a-b2ee-0b66eb757536"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("24bbee6d-ee2b-4edc-9267-177191780665"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("31b8cfd0-14fd-4622-8702-c66b487967c6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("39d22ddd-aff0-48e8-bb02-775e81daf640"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("44cadcda-6210-41c8-a769-62ef288116ad"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("537ffb7d-47d0-4754-874f-d41c37919728"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5395ecd0-203f-4687-8202-18222daccb60"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("658eee38-2363-4a83-876f-b5951e54acbe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6a046949-0ffb-4069-b974-4e3a63cb46b4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6ecd1916-6076-4e62-bac5-40ebdef2a4f2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("735276db-b763-4593-a71e-5a37d49e2071"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a40adb3f-fd8e-40ba-834f-c64600d32bbe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aae4f5e7-8209-452d-a639-f391f7a32aa3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ac178a87-1097-4dee-8c87-ba921be3be2c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("afb2cd04-2b1a-4f92-8a38-2147eb9904ee"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b075d46b-4480-4021-94d0-ac9ebcbc98b6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c1eec4d3-dc13-4cfc-adaf-b261603893d1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c2e1dddd-78d6-44e1-b01b-cfeb7c369908"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c90c76bd-483e-43ec-8c92-1b63814fb984"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cd7a2105-b14e-4112-8961-a5b567e43d22"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ff6aa1a7-9d1b-4c81-addc-fbed065f130b"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("066425dd-f06c-4037-83a9-dae7c9d8bfd2"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9678), new Guid("3fa5d3a6-f111-4b7e-a95d-ca849411e955"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("0b6b9819-7695-4d9e-82db-3196f9189b20"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9645), new Guid("fcb0154f-e31c-4850-bdb0-109d47a9df82"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("0e35376f-6597-4f00-b4cd-bb7602dd1fa8"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9643), new Guid("ad8ac4f5-7519-4dca-9b22-dfd13c013cf9"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("0eb09eaf-6834-4f39-8b59-2916231714ab"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9621), new Guid("c90a843e-92de-46e6-a9fa-df8cffc14b86"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("175bfb82-5da5-4674-b910-7b8a7e578d23"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9639), new Guid("cb35f73b-81e5-4b7c-b89c-152f4dcb17a2"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("26c5b510-8c97-4c93-8b54-5adeea491c64"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9661), new Guid("2be9c019-8942-4e1a-a4e2-8da8536b0b82"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("2e0a8c5b-a29d-4e44-8705-89f6b9428c64"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9654), new Guid("18a9ae26-f40d-426a-9a59-97b28adb1eab"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("2f2e47b9-62d8-4241-afca-56bd1d59c011"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9632), new Guid("39934978-7737-46f2-8953-c5fd7c878663"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("4678e1a1-06fe-45c9-8e99-c5486c3fc917"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9676), new Guid("1dc438fb-2bd8-415a-80d1-4130b85291c4"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("4e5c3493-f705-4e0a-a832-0cad591bcfe4"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9641), new Guid("c5b51c39-41b1-4f8c-93b4-c9f37d672002"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("69b93c8f-2e75-4e23-919c-bad0b3f97699"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9663), new Guid("8be6ccf2-362f-4424-a597-60b0a8406045"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("69bc684e-7519-4a39-88ea-39e988e54b66"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9674), new Guid("3e751213-029f-47bd-85e0-35e000bd6028"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("7896ca87-1f88-45d5-9dbc-85f57e784e23"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9652), new Guid("186db636-8db1-42fc-a65e-6306ea15ffc5"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("96938c1a-be4f-44cf-a23f-58d6c578f5e3"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9628), new Guid("08edca5e-0bf2-46d9-bdac-886229e4399b"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("96c6a0c1-304e-4733-a4fc-d9a431f3bfa5"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9598), new Guid("a1025cb9-e475-4dc2-a614-da779eb77e6b"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("985c41e4-8674-47d0-874f-f03b248aaa05"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9666), new Guid("20a54429-e5cc-4c9f-bdf8-f2f842d202ed"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("a0773279-09a6-442a-b35a-f8349f811ae0"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9623), new Guid("82e7db71-94f7-44a5-93a9-9f0061f60017"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("a70f42bb-14d5-495e-81df-e426a6073c23"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9634), new Guid("78cfd22a-8e48-435e-ad9f-e9b78b9b5efc"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("addb26ca-c553-4670-a8c4-233663eef9c5"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9616), new Guid("cba3456f-c37d-4d57-a603-98732d3ef67d"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("ade5c215-69ba-4ad2-a7b4-d216b61b2e51"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9619), new Guid("a022031a-0083-4a9c-91bc-a3d25138ab66"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("b7c28212-1bad-4ed0-ad9f-34d0df913869"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9672), new Guid("8d100e49-dba7-4dd5-816c-8a4b6a8f36cb"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("b7f132d0-be41-41d8-b697-902d80416269"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9668), new Guid("4373bcd2-fdc4-470f-a358-b3cfa42f632f"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("c7261c3f-7837-4ed2-a0b0-55349e8c7129"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9630), new Guid("e54e1086-86d7-40e7-9448-417bcc2d363d"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("c89f8a4b-76ad-473b-9a98-7512e7dd4508"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9656), new Guid("7571610d-7ac9-41b3-918d-f4c13d6285df"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("f6009e63-b1c0-4493-9dbc-313f33df7998"), true, new DateTime(2024, 4, 11, 5, 40, 4, 543, DateTimeKind.Utc).AddTicks(9650), new Guid("033a43f7-895a-46e8-b598-cc113ce073a3"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("066425dd-f06c-4037-83a9-dae7c9d8bfd2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0b6b9819-7695-4d9e-82db-3196f9189b20"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0e35376f-6597-4f00-b4cd-bb7602dd1fa8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0eb09eaf-6834-4f39-8b59-2916231714ab"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("175bfb82-5da5-4674-b910-7b8a7e578d23"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("26c5b510-8c97-4c93-8b54-5adeea491c64"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2e0a8c5b-a29d-4e44-8705-89f6b9428c64"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2f2e47b9-62d8-4241-afca-56bd1d59c011"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4678e1a1-06fe-45c9-8e99-c5486c3fc917"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4e5c3493-f705-4e0a-a832-0cad591bcfe4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("69b93c8f-2e75-4e23-919c-bad0b3f97699"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("69bc684e-7519-4a39-88ea-39e988e54b66"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7896ca87-1f88-45d5-9dbc-85f57e784e23"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("96938c1a-be4f-44cf-a23f-58d6c578f5e3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("96c6a0c1-304e-4733-a4fc-d9a431f3bfa5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("985c41e4-8674-47d0-874f-f03b248aaa05"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a0773279-09a6-442a-b35a-f8349f811ae0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a70f42bb-14d5-495e-81df-e426a6073c23"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("addb26ca-c553-4670-a8c4-233663eef9c5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ade5c215-69ba-4ad2-a7b4-d216b61b2e51"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b7c28212-1bad-4ed0-ad9f-34d0df913869"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b7f132d0-be41-41d8-b697-902d80416269"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c7261c3f-7837-4ed2-a0b0-55349e8c7129"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c89f8a4b-76ad-473b-9a98-7512e7dd4508"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f6009e63-b1c0-4493-9dbc-313f33df7998"));

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("08fec076-58bb-4038-bb4e-5760d90be08e"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(758), new Guid("652978d8-e782-4225-b644-8fd41318d903"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("0a871a7f-cd39-40c3-b4f0-78b7dbd8432b"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(794), new Guid("88ecae04-d3a1-462a-9a7d-8c9d2d5425c0"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("1672fb59-4666-4df3-afde-a81abd72753e"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(719), new Guid("de20e8af-7d15-49f3-99f9-4dffc846fc8b"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("1f2693d6-25b1-4519-ba06-30e6d84d2e39"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(799), new Guid("008e2477-65e1-4221-92d1-873a2c237943"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("20f8ff8e-d108-436a-b2ee-0b66eb757536"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(786), new Guid("f331b30c-7c01-437a-b6c5-83d26e0f5a03"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("24bbee6d-ee2b-4edc-9267-177191780665"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(790), new Guid("af2a87cb-a5a3-443f-88fb-e64fe6662241"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("31b8cfd0-14fd-4622-8702-c66b487967c6"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(810), new Guid("d5d6c262-c866-49dd-926c-e8f285f878af"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("39d22ddd-aff0-48e8-bb02-775e81daf640"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(808), new Guid("68f10fe1-2302-4155-93a2-2d4207e9cd4d"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("44cadcda-6210-41c8-a769-62ef288116ad"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(806), new Guid("25e651c8-c03d-44d5-a61e-4df8b4cdf4da"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("537ffb7d-47d0-4754-874f-d41c37919728"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(762), new Guid("51365b2a-6860-4cdf-904e-13caaf7cbbd6"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("5395ecd0-203f-4687-8202-18222daccb60"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(776), new Guid("8672692d-30f5-4c11-9894-2ae3192a6e3b"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("658eee38-2363-4a83-876f-b5951e54acbe"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(772), new Guid("27781010-11ed-4e49-a4b2-7f5f5be45dc9"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("6a046949-0ffb-4069-b974-4e3a63cb46b4"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(774), new Guid("aad7e958-3747-4cbd-96d0-81b4f50bc550"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("6ecd1916-6076-4e62-bac5-40ebdef2a4f2"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(746), new Guid("c2ab696f-1ae4-45fe-b6c4-03d1af8d984f"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("735276db-b763-4593-a71e-5a37d49e2071"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(796), new Guid("12f17791-2ae3-4693-a72f-de0b2a20577d"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("a40adb3f-fd8e-40ba-834f-c64600d32bbe"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(784), new Guid("99415bc4-f088-45ff-a151-80971d196b8a"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("aae4f5e7-8209-452d-a639-f391f7a32aa3"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(801), new Guid("6a317fa5-b1a5-4110-b2ba-2871224d1c45"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("ac178a87-1097-4dee-8c87-ba921be3be2c"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(724), new Guid("769d54a4-8e40-411e-91dd-ec1052cf99cf"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("afb2cd04-2b1a-4f92-8a38-2147eb9904ee"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(752), new Guid("ce37ac6f-06c6-4c6e-9714-407e7a07f8b8"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("b075d46b-4480-4021-94d0-ac9ebcbc98b6"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(779), new Guid("d7a9d206-d8da-4bd7-b637-bf5c97031423"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("c1eec4d3-dc13-4cfc-adaf-b261603893d1"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(760), new Guid("57c9cae6-166b-4968-8258-49202ac28de3"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("c2e1dddd-78d6-44e1-b01b-cfeb7c369908"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(743), new Guid("7938d5c7-0eb6-49e8-9b58-4b1c3254c58b"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("c90c76bd-483e-43ec-8c92-1b63814fb984"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(764), new Guid("ac6e38b6-680d-4964-9ef4-9a42de30d435"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("cd7a2105-b14e-4112-8961-a5b567e43d22"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(788), new Guid("ffbb425b-f39d-4346-89c2-c59f0e8987bd"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("ff6aa1a7-9d1b-4c81-addc-fbed065f130b"), true, new DateTime(2024, 4, 11, 5, 28, 46, 416, DateTimeKind.Utc).AddTicks(749), new Guid("9aa11a33-9585-4d3a-bedc-0c84f977d583"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" }
                });
        }
    }
}
