using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetableemployessdeduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("08dbb77e-fdae-43c5-b7b0-e9a7b7504297"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("09d67016-605d-4b1f-850e-7121566c0d13"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0c0432cb-b6c4-4ced-80b7-b8cf903851e0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0d75c435-9c17-418e-8f77-eab78f9d12c1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("30efa2ff-c873-4a59-8eb9-29c5260775a6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("32ac8357-3f5a-49c0-84d3-6ed1c5529caf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("476964c8-1aec-42d3-a866-76513c70f785"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("58c0215e-a792-4c88-b210-1cefaec2e357"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6e598b35-3656-47f9-9943-ebb06ede3fb4"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("895cbd31-868c-4b1b-9adb-a26765e2ccec"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9127d1b6-0943-4c3c-891b-b81dbf5df968"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("98b15327-7d99-47dc-a2a3-aab9cbfee095"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("99ecaf51-0cf3-4765-af68-44713a89cca1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9a86e430-c8a9-4ed4-a1e0-d3a5b8a3ba00"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b7cac7d3-a03a-4e52-ab13-a496e72a680a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c419dc1d-8a2e-43e1-bc09-a3bbd84400de"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d482d05d-810e-4d3e-bcfc-946aa0e4228c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ecd9df0b-4188-49a2-9e06-fe9b69d561c8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f5ed2981-6607-46d4-839a-c3eb6cad960b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fac7a004-6bea-48c1-9a04-373a50d7a5f8"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("0f9cf89a-6c08-4d7c-9c32-408cbd0b55c2"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4480), new Guid("f4ed9e7d-a96d-4c03-8374-af639f78dcc9"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("184f92a5-9cfb-4e27-8ac8-e7aae0492410"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4482), new Guid("ab1de066-9b97-4bba-b9c1-8fab412fa58b"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("18c35c4e-c861-4a74-95dc-4bec5b305628"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4475), new Guid("482364fa-fe42-4739-a850-62fff997c7b6"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("2b853cc2-2392-4b6b-95fd-483ff4810b5d"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4472), new Guid("1d938860-584c-4784-b2c6-bb1edb233068"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("2bd361a7-637c-4121-8d79-1b4b9e5db772"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4495), new Guid("10718901-3d21-4897-aa04-bc57e4fd9736"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("313f4902-d007-411a-adad-0f07815d0baf"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4489), new Guid("6d3f1f58-0368-4be2-9dfd-4e59339e18ff"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("42072223-25f6-4805-93f3-97c86cb82217"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4453), new Guid("69ddf2f3-3d07-403e-816b-e5586994cf15"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("4de12764-6cc0-47c9-99da-b9e329441a21"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4473), new Guid("6e3409fc-33b6-47bd-b8fa-8dde46a37975"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("5191298f-25cd-45be-8817-1ae20e11e14e"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4469), new Guid("e599f2ae-011c-421e-a75b-f6a03aa2cdce"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("6aff6ac6-e1ab-4596-b46f-6881442ddba6"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4483), new Guid("e086c6f1-dd22-4a47-9c0c-75b344944d1c"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("76742334-2110-4fff-904d-d5b71b7cfbbe"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4488), new Guid("367d7f5b-5f24-4700-948f-16a64a407e37"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("7d598b9a-0e1a-4c51-9bf3-5c0bda04abc6"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4501), new Guid("6bc3986c-4145-4289-963f-b9f4a4d03f3c"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("9b13a868-d7cc-43c9-83cc-44d112542c87"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4491), new Guid("64bcc38c-bd2c-40cc-b1f7-a7092a774170"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("a0a837de-5a6b-48c1-9325-c96918c88d40"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4486), new Guid("8b35b348-ee76-4247-ad6e-db98d581840a"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("a1f0cb06-b4d8-46d2-aee4-7d5cc90f92ce"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4494), new Guid("623726f3-80ba-450c-9534-f688cf98f8dd"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("acc3f25f-2662-433c-be10-bdcb2f4327f0"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4478), new Guid("d2ad74d7-4633-4c83-a090-562c224994d9"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("c26f669f-75ab-4a96-b90e-494cb9b475e3"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4503), new Guid("abea3911-622f-45ca-8b0c-68062f881438"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("e20f0cfb-ca43-45bb-8f96-50d793d4f324"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4448), new Guid("cd8058a2-56e4-4fac-af26-2c3645788c02"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("e8966f14-d0af-41ce-b9db-7eb479aff1a9"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4497), new Guid("0d1b0ea3-eebe-4ecc-9caf-3c32dcd4e0f9"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("ec99d148-76dd-45d9-b8b5-6afbf7db1590"), true, new DateTime(2024, 4, 2, 7, 18, 36, 824, DateTimeKind.Utc).AddTicks(4498), new Guid("81fce7dc-7bfc-4a67-be47-0156b2412553"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesDeduction_EmployeeId",
                table: "EmployeesDeduction",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesDeduction_Employees_EmployeeId",
                table: "EmployeesDeduction",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesDeduction_Employees_EmployeeId",
                table: "EmployeesDeduction");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesDeduction_EmployeeId",
                table: "EmployeesDeduction");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0f9cf89a-6c08-4d7c-9c32-408cbd0b55c2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("184f92a5-9cfb-4e27-8ac8-e7aae0492410"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("18c35c4e-c861-4a74-95dc-4bec5b305628"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2b853cc2-2392-4b6b-95fd-483ff4810b5d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2bd361a7-637c-4121-8d79-1b4b9e5db772"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("313f4902-d007-411a-adad-0f07815d0baf"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("42072223-25f6-4805-93f3-97c86cb82217"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4de12764-6cc0-47c9-99da-b9e329441a21"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5191298f-25cd-45be-8817-1ae20e11e14e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6aff6ac6-e1ab-4596-b46f-6881442ddba6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("76742334-2110-4fff-904d-d5b71b7cfbbe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7d598b9a-0e1a-4c51-9bf3-5c0bda04abc6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9b13a868-d7cc-43c9-83cc-44d112542c87"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a0a837de-5a6b-48c1-9325-c96918c88d40"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a1f0cb06-b4d8-46d2-aee4-7d5cc90f92ce"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("acc3f25f-2662-433c-be10-bdcb2f4327f0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c26f669f-75ab-4a96-b90e-494cb9b475e3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e20f0cfb-ca43-45bb-8f96-50d793d4f324"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e8966f14-d0af-41ce-b9db-7eb479aff1a9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ec99d148-76dd-45d9-b8b5-6afbf7db1590"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("08dbb77e-fdae-43c5-b7b0-e9a7b7504297"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9729), new Guid("1fb58efb-31af-49b8-950b-ebe479313ab6"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("09d67016-605d-4b1f-850e-7121566c0d13"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9718), new Guid("c7f54a0f-8570-466a-bac9-582d244a645c"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("0c0432cb-b6c4-4ced-80b7-b8cf903851e0"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9727), new Guid("18bbd7dc-3f43-4a03-9de1-eb2ef7741eeb"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("0d75c435-9c17-418e-8f77-eab78f9d12c1"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9714), new Guid("1f8f84b8-b71d-42b1-a8c0-183d0270633b"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("30efa2ff-c873-4a59-8eb9-29c5260775a6"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9715), new Guid("d61c706d-2693-4c5b-bdef-0ca318f5589d"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("32ac8357-3f5a-49c0-84d3-6ed1c5529caf"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9735), new Guid("f6e6a99b-a3b6-4b59-a6eb-9138def060c5"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("476964c8-1aec-42d3-a866-76513c70f785"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9711), new Guid("a1934a05-8dd8-4306-a9be-a8576f27ffaf"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("58c0215e-a792-4c88-b210-1cefaec2e357"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9722), new Guid("b33c51d8-e336-4761-a73a-7db62301add1"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("6e598b35-3656-47f9-9943-ebb06ede3fb4"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9721), new Guid("bf18ba0e-0541-427a-880a-41715689e90c"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("895cbd31-868c-4b1b-9adb-a26765e2ccec"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9719), new Guid("34abb38c-8af5-4829-a1a7-9cadd63a1bb4"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("9127d1b6-0943-4c3c-891b-b81dbf5df968"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9736), new Guid("176d9492-5281-4a0d-8937-f2cc606c3fdc"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("98b15327-7d99-47dc-a2a3-aab9cbfee095"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9728), new Guid("61ace3ed-4e77-448f-a1d6-9762ad1b484b"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("99ecaf51-0cf3-4765-af68-44713a89cca1"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9725), new Guid("017fbca9-cc75-463e-9abb-8b6ad21340b8"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("9a86e430-c8a9-4ed4-a1e0-d3a5b8a3ba00"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9707), new Guid("1fcd7d21-0649-4863-b4cd-722a357fdeac"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("b7cac7d3-a03a-4e52-ab13-a496e72a680a"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9712), new Guid("54468112-0ff8-4b4b-9ef3-0684190b0389"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("c419dc1d-8a2e-43e1-bc09-a3bbd84400de"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9732), new Guid("922796e6-b957-49e5-a8e4-b65e5ead52a7"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("d482d05d-810e-4d3e-bcfc-946aa0e4228c"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9708), new Guid("6134871e-03e0-4785-bcaa-4fc922377faa"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("ecd9df0b-4188-49a2-9e06-fe9b69d561c8"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9699), new Guid("dee6daf3-71a4-449f-b68e-ee6cc066df96"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("f5ed2981-6607-46d4-839a-c3eb6cad960b"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9733), new Guid("7547357c-9cba-4b48-8069-e774d568b71d"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("fac7a004-6bea-48c1-9a04-373a50d7a5f8"), true, new DateTime(2024, 4, 2, 7, 14, 18, 919, DateTimeKind.Utc).AddTicks(9705), new Guid("509f18e0-bd05-46c3-aa06-f0e81388e53f"), "Employees", "Department", "Department", "Admin,Manager" }
                });
        }
    }
}
