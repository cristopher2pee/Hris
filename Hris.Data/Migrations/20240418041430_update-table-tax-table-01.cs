using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetabletaxtable01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("028f5ac6-1dea-409f-a2d7-0b2f82b32975"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0a3b289d-dc29-49a7-97f0-fa8e0d1c860d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0faf914e-2e64-4c0f-b048-0b863111a65c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("16d7a854-7ac6-4b60-bf93-4700ec1a4d3d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("23b3725b-8cd5-4ef9-aa1f-a2c3bec1ef5c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("26d6c661-0956-410a-9609-aea6eef0fde4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("396816a4-40f0-49d0-bf71-a59d69c31087"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3c861374-e1bb-4abf-aad1-42092e51b35d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4528d699-eebc-41b5-bc33-f0a74f8d36b5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("467b2d96-77c2-423e-b934-69e3ef43d533"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("48742a75-b0ed-4e61-8b52-e607a46fe29b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("58414145-14d4-4f85-84b2-b290b93eaad5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6c5898a3-f7d4-46ca-b0b1-bfeb0290bda5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6f38c8f2-2ef1-4c93-ae03-71645cd5ba2d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("71446120-3d4b-4a1d-b8a7-c2ec7b469a0e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("781e6b12-993f-4f79-9a26-0fde36e88ad1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("80b981b1-1e80-4c69-b3d7-d4cad5d7a002"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("85adafb6-5d09-4b4a-90a4-a61257522443"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8bb8a91f-4a47-427a-bc28-3f7e802aa8a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("98984bbc-865b-4584-8003-af21254c3c9c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("bd0c89de-338d-4c59-a56f-bbf81daabe52"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("daf85a9a-f7b3-4577-b279-876e82b20eb8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f4163527-bd77-4fbf-a563-bc11bfea62b6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f70a250b-1eba-4170-822b-8ae1f6da878e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f7b2106d-c7a8-4922-966f-99d573640ded"));

            migrationBuilder.AddColumn<decimal>(
                name: "ExcessOver",
                table: "TaxTable",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TaxPeriodType",
                table: "TaxTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ExcessOver",
                table: "TaxTable");

            migrationBuilder.DropColumn(
                name: "TaxPeriodType",
                table: "TaxTable");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("028f5ac6-1dea-409f-a2d7-0b2f82b32975"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3739), new Guid("d7d73b06-de12-4098-bcf0-6add134e3e09"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("0a3b289d-dc29-49a7-97f0-fa8e0d1c860d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3760), new Guid("2bf19ba0-2d9c-49ef-a0f5-1ab6f60a6b91"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("0faf914e-2e64-4c0f-b048-0b863111a65c"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3737), new Guid("5770ea8d-b24b-4f48-bfc2-99012083d287"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("16d7a854-7ac6-4b60-bf93-4700ec1a4d3d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3755), new Guid("8ea670e0-4fd3-4d61-a87a-d9f078ec6f49"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("23b3725b-8cd5-4ef9-aa1f-a2c3bec1ef5c"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3763), new Guid("a8f2d59f-40f9-48f8-85e2-7d83141e6166"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("26d6c661-0956-410a-9609-aea6eef0fde4"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3750), new Guid("83ccccce-5bb8-4fab-83bf-d3106bb1b35d"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("396816a4-40f0-49d0-bf71-a59d69c31087"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3747), new Guid("bac20b3f-7922-4cdd-b938-b1ee646fffa2"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("3c861374-e1bb-4abf-aad1-42092e51b35d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3767), new Guid("5a7692df-2654-4581-be9e-a225b2ab052d"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("4528d699-eebc-41b5-bc33-f0a74f8d36b5"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3733), new Guid("1fe8d201-f8cd-43d9-a057-57c0bff7d247"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("467b2d96-77c2-423e-b934-69e3ef43d533"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3745), new Guid("001b2639-e97a-4f4b-98d3-ba54d1188666"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("48742a75-b0ed-4e61-8b52-e607a46fe29b"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3773), new Guid("0df57083-4a83-4886-84e3-f4db21cd3980"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("58414145-14d4-4f85-84b2-b290b93eaad5"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3752), new Guid("dbd49501-a465-4bdf-906c-0b958f540caa"), "Clock", "ImportTracks", "Import-Tracks", "Admin,Hr" },
                    { new Guid("6c5898a3-f7d4-46ca-b0b1-bfeb0290bda5"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3754), new Guid("148177f6-38ec-4691-ae86-009b14e8cc38"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("6f38c8f2-2ef1-4c93-ae03-71645cd5ba2d"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3667), new Guid("192e5e36-f43e-4c19-a3f6-392a980c6295"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("71446120-3d4b-4a1d-b8a7-c2ec7b469a0e"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3744), new Guid("feb4e0a8-1943-45d4-8428-59e371ee8e43"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("781e6b12-993f-4f79-9a26-0fde36e88ad1"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3775), new Guid("db8e6fb0-e6fb-4afb-8ceb-391410ef3079"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("80b981b1-1e80-4c69-b3d7-d4cad5d7a002"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3770), new Guid("66a3c6b6-5dc8-4b24-9589-fd5ad741c495"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("85adafb6-5d09-4b4a-90a4-a61257522443"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3672), new Guid("b9758710-fd4d-4c34-b986-2ec1faa1729a"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("8bb8a91f-4a47-427a-bc28-3f7e802aa8a2"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3768), new Guid("b7e5ff48-00e7-452e-81bf-aec8512687f2"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("98984bbc-865b-4584-8003-af21254c3c9c"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3761), new Guid("7ae9324b-eb27-467e-9b3a-638605f9ab21"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("bd0c89de-338d-4c59-a56f-bbf81daabe52"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3776), new Guid("f663c79e-a1f7-4c4d-9565-7c740e093526"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("daf85a9a-f7b3-4577-b279-876e82b20eb8"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3742), new Guid("c1de185c-acf8-4e63-a222-c8737fdea530"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("f4163527-bd77-4fbf-a563-bc11bfea62b6"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3735), new Guid("d3877e3f-4e03-48c5-9410-52ebb81a935e"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("f70a250b-1eba-4170-822b-8ae1f6da878e"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3758), new Guid("58fce9ea-c85f-47ec-95d4-3db6e18063d3"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("f7b2106d-c7a8-4922-966f-99d573640ded"), true, new DateTime(2024, 4, 17, 7, 23, 31, 781, DateTimeKind.Utc).AddTicks(3766), new Guid("715040a5-3d38-468b-987b-31f32f5a198b"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" }
                });
        }
    }
}
