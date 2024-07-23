using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addemployeedeductiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("05e7de5d-bd11-4e25-833f-492896dd3f94"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0b9d36ec-7dba-4f2e-98e7-255c66826b3e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("128360f6-b21b-4542-83aa-0ecb7be29413"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("14f39878-dbf6-4e7e-9ec2-f40c29e8955b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1ca07848-1cdd-48bf-9843-7712786bd4af"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3d3e48d1-4828-481d-b804-16ea0942d18e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3ebc9c56-f0d4-4a0b-9730-805207a0d279"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("55ee4f1a-8245-4339-8691-75adc41aebee"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("56959267-1b0a-467e-be6a-489655ff3030"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5b0cb5fa-82f7-4761-ab73-41b974408dc1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5fd3d2a8-8135-45e5-ac57-399cd4897093"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6635937f-9479-4a24-9644-76ad64128001"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("69b2916f-34be-4f1f-b26f-eea17964795d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("784414b2-093e-4891-ad29-2f39e858063d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("80ca3bdc-83b1-4ce9-9e69-0b4a30d03d43"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8ba6852f-cefe-4394-9149-f8935ccd0595"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b3d8f35c-a996-4801-a665-9671c11f3993"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("dbeed79d-844c-440f-a9b1-77a86a6874ca"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fe07749c-19c6-449b-b933-bc13a9b7d86c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ff90716a-e772-443b-a1af-d89a8519817a"));

            migrationBuilder.CreateTable(
                name: "EmployeesDeduction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeductionTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesDeduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesDeduction_DeductionTypes_DeductionTypesId",
                        column: x => x.DeductionTypesId,
                        principalTable: "DeductionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesDeduction_DeductionTypesId",
                table: "EmployeesDeduction",
                column: "DeductionTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesDeduction");

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
                    { new Guid("05e7de5d-bd11-4e25-833f-492896dd3f94"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(542), new Guid("78357a58-1979-4161-8ee6-2a3c4fb6be4b"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("0b9d36ec-7dba-4f2e-98e7-255c66826b3e"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(496), new Guid("02cafb97-99fe-442f-8b43-8e24fb6fc270"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("128360f6-b21b-4542-83aa-0ecb7be29413"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(544), new Guid("b403e5c7-7df6-469f-ad2c-49cedc5b283c"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("14f39878-dbf6-4e7e-9ec2-f40c29e8955b"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(537), new Guid("e8a8f38d-b3b8-47db-a854-e2289ef9c2d2"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("1ca07848-1cdd-48bf-9843-7712786bd4af"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(522), new Guid("bb93ba9b-5057-45da-8c99-6d0da2f4948b"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("3d3e48d1-4828-481d-b804-16ea0942d18e"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(517), new Guid("9519f9bc-b0f8-4352-a1f3-f6d658e9249e"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("3ebc9c56-f0d4-4a0b-9730-805207a0d279"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(543), new Guid("41ec5bbe-fae8-4c7f-8b53-c9043a212135"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("55ee4f1a-8245-4339-8691-75adc41aebee"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(520), new Guid("490687de-0b34-4449-ba2e-e983c66edb49"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("56959267-1b0a-467e-be6a-489655ff3030"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(533), new Guid("62552b9a-60c1-4534-9a55-44b03cce424f"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("5b0cb5fa-82f7-4761-ab73-41b974408dc1"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(534), new Guid("0ba8dfad-73a0-4f7b-b888-34709cc0a879"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("5fd3d2a8-8135-45e5-ac57-399cd4897093"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(526), new Guid("8eb4a8b2-48b1-4923-a480-ab9912eaaf7b"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("6635937f-9479-4a24-9644-76ad64128001"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(503), new Guid("c58ee0d7-7af6-4271-8e66-d24d7cb1646e"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("69b2916f-34be-4f1f-b26f-eea17964795d"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(529), new Guid("81e08106-56ec-4e85-913e-8c6b957a6f0a"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("784414b2-093e-4891-ad29-2f39e858063d"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(519), new Guid("dc83a219-2eec-490c-b11a-5b5ea00fcc65"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("80ca3bdc-83b1-4ce9-9e69-0b4a30d03d43"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(530), new Guid("cd969b91-be43-4af1-bb3f-16c2355bce95"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("8ba6852f-cefe-4394-9149-f8935ccd0595"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(540), new Guid("6660c413-9cbb-40ae-9e9b-4d1130e91672"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("b3d8f35c-a996-4801-a665-9671c11f3993"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(501), new Guid("9ae1a0d9-0fce-4cea-b069-9e785e253d58"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("dbeed79d-844c-440f-a9b1-77a86a6874ca"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(536), new Guid("a4eafed4-771e-4b44-a2c4-0c75192f884d"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("fe07749c-19c6-449b-b933-bc13a9b7d86c"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(525), new Guid("fb71e24f-8a43-4386-bd60-3bda8d444796"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("ff90716a-e772-443b-a1af-d89a8519817a"), true, new DateTime(2024, 4, 2, 5, 23, 21, 571, DateTimeKind.Utc).AddTicks(547), new Guid("b036be69-c560-4756-91b8-71a01fd42c46"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" }
                });
        }
    }
}
