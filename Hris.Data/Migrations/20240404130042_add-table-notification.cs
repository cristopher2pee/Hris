using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablenotification : Migration
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

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReadP = table.Column<bool>(type: "bit", nullable: false),
                    RedirectToUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("072f5c62-b4f9-4d4c-9254-6bdceb40016a"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9701), new Guid("0d3cc228-0694-4cdb-960a-28b9528b26ae"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("08ef476e-f9d2-4972-9302-85e1b2db9c3f"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9672), new Guid("9d1d0fa7-939d-42fc-a12e-f413604917f9"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("1621287c-3509-4545-b64c-0090245bfe77"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9710), new Guid("a68fe98f-b40e-477d-8e1e-673c7c931f29"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("1d2710db-9a45-41e6-a6d6-9897c2be728b"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9673), new Guid("5e7bdce8-183f-4a74-9192-0620da843110"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("22ac3714-73a5-4c25-baa3-0515bcfaa086"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9642), new Guid("1dbd4def-c022-4544-83eb-f44a6f07da1f"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("22c57c1c-9059-4677-9f04-e389268ec494"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9697), new Guid("36726483-bbe4-4c7e-9cd4-0d9871755297"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("27fa6323-dd4e-4f3d-81fb-021257affb28"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9689), new Guid("ed4803d5-093a-4b53-8583-78a7b6c55cdd"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("29107917-720d-41d2-b233-9ecf15882653"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9693), new Guid("dcdd0f8c-8bf9-435c-a327-d3dff8e16e88"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("2b9efd4d-3fb8-4ea4-9ae9-dd8d3a83a1dc"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9682), new Guid("622db4d4-28ef-4a6c-9619-aa4feee75dda"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("2c2235de-1f18-4189-8e51-af958c2c1ae1"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9670), new Guid("2d708a67-3903-48ad-881e-cbc6dca2f8aa"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("3e5c3a43-3c33-4b89-adcf-83c12e0a051c"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9684), new Guid("6771d848-de6e-4bd3-a1d7-f2aeb9859e56"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("40e7453b-f815-448a-95e4-97293f32733b"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9650), new Guid("0f755394-4316-4cc1-857c-b06f4f5333de"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("7033c091-049e-43d8-9644-61eedc890ba8"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9698), new Guid("6cc4788b-77fd-4fe5-aa8b-5f380fdc44d0"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("74408898-d638-4de0-9292-1ea1e67090c4"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9704), new Guid("d7f1a93b-d1b8-4c58-b06b-52a5eef5af62"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("75577488-e802-4a9e-b68e-dd2d44ccf1e9"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9686), new Guid("bd9cd52f-1037-4c62-8033-5b38317b29fd"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("90b552fd-4744-48b9-80fa-9234ab2a3368"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9700), new Guid("6628458b-e817-4e42-b1c4-f97c8a898820"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("94f1a244-22b5-469d-ab7d-212963bc1572"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9685), new Guid("48b6329a-ee7c-4cb7-bf7d-a88bfa4fe5cb"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("bbd8103d-d16b-4205-b1d0-8eb4fc162885"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9705), new Guid("a47354ab-f44c-428b-b109-93828ad1b230"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("cd73e140-d495-4910-b5e6-741403b1e669"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9690), new Guid("96060a55-28e9-4cf3-83b1-28421925e770"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("d403d98d-2517-49cf-912a-e7a75864d694"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9679), new Guid("2a00c99e-6f74-411b-a682-ca8141c592b8"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("d95563a8-7d27-4c14-b443-065516de794b"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9707), new Guid("91fc3f41-aded-4e06-891d-87f4bf1762a2"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("eacfaa68-9ed9-488c-b9d4-a4df41402cee"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9706), new Guid("ef932381-0d66-492a-9dde-d80d61817353"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("ee8b437d-93e6-486c-8c32-cebb197843a2"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9648), new Guid("09a6f536-2c6b-4b9a-9ebc-e1e5491c8629"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("f8067b80-fda5-438a-95f8-1247d29d2f77"), true, new DateTime(2024, 4, 4, 13, 0, 41, 868, DateTimeKind.Utc).AddTicks(9694), new Guid("e6e80acf-d0cb-4e44-babe-732f0a3b3eac"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("072f5c62-b4f9-4d4c-9254-6bdceb40016a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("08ef476e-f9d2-4972-9302-85e1b2db9c3f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1621287c-3509-4545-b64c-0090245bfe77"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1d2710db-9a45-41e6-a6d6-9897c2be728b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("22ac3714-73a5-4c25-baa3-0515bcfaa086"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("22c57c1c-9059-4677-9f04-e389268ec494"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("27fa6323-dd4e-4f3d-81fb-021257affb28"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("29107917-720d-41d2-b233-9ecf15882653"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2b9efd4d-3fb8-4ea4-9ae9-dd8d3a83a1dc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2c2235de-1f18-4189-8e51-af958c2c1ae1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3e5c3a43-3c33-4b89-adcf-83c12e0a051c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("40e7453b-f815-448a-95e4-97293f32733b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7033c091-049e-43d8-9644-61eedc890ba8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("74408898-d638-4de0-9292-1ea1e67090c4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("75577488-e802-4a9e-b68e-dd2d44ccf1e9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("90b552fd-4744-48b9-80fa-9234ab2a3368"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("94f1a244-22b5-469d-ab7d-212963bc1572"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bbd8103d-d16b-4205-b1d0-8eb4fc162885"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cd73e140-d495-4910-b5e6-741403b1e669"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d403d98d-2517-49cf-912a-e7a75864d694"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d95563a8-7d27-4c14-b443-065516de794b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("eacfaa68-9ed9-488c-b9d4-a4df41402cee"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ee8b437d-93e6-486c-8c32-cebb197843a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f8067b80-fda5-438a-95f8-1247d29d2f77"));

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
