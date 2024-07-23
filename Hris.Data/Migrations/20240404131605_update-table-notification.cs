using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetablenotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "IsReadP",
                table: "Notifications",
                newName: "IsRead");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "Notifications",
                newName: "IsReadP");

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
    }
}
