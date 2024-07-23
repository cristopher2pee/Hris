using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class deductiontypesmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("03d64b4a-e146-4cc7-a2dc-dde187cb66a0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0509ce1c-17bf-4002-8859-b1f83af1b8cb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("17e9977e-e87c-4867-95ac-940c04c600ce"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("21e4e238-e6d1-4736-be4b-73f25cb8b3a5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("23eeeabf-89ec-41a4-b2d7-082b29a6b3b5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4bb4f96e-5a79-498f-accf-4bb73502f13d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("500295a4-d83d-4cb1-b72e-cdda800bbf95"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6d9eb846-21d9-44a7-8ad0-a38696848a0e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("892ba8e2-8bc0-4009-aa1e-a263e71345aa"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ad97f67f-8a14-4b81-bb18-fc49a67d1e7b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b335da23-cbbb-415f-beb7-91f56fa5ebb2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c2a7ca1e-7453-4d1d-9c9a-ebc7f21cde45"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c7a40c61-b5e9-42fb-b0c4-7b0e4542ad79"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d285327e-58c8-40b7-9b3d-121f01c448a2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e1692ebe-0411-4a15-af96-d490f706a1b3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e3d7ebe3-d145-4240-a82b-24d30b129eff"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f2c98cea-3991-40c5-802f-cdf0b5ec4cd9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f39dcb68-b327-466e-88b7-eafa1c495f96"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f67cf6e5-5484-48c0-948d-6f4441fd01ab"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fe0578a8-062a-4786-aee8-ebb54d553220"));

            migrationBuilder.CreateTable(
                name: "DeductionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionTypes", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeductionTypes");

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

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("03d64b4a-e146-4cc7-a2dc-dde187cb66a0"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5815), new Guid("a872cc18-ae95-49a8-8424-d4a70284709f"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("0509ce1c-17bf-4002-8859-b1f83af1b8cb"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5857), new Guid("edde9228-7974-4927-bfba-e5db6481941e"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("17e9977e-e87c-4867-95ac-940c04c600ce"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5838), new Guid("900debcc-45ac-4e5c-9228-b715ec5324c0"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("21e4e238-e6d1-4736-be4b-73f25cb8b3a5"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5869), new Guid("fc335374-10ce-4764-881f-e32bcc0de528"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("23eeeabf-89ec-41a4-b2d7-082b29a6b3b5"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5864), new Guid("a3bf1459-25dd-46a8-a40c-589dab6d8218"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("4bb4f96e-5a79-498f-accf-4bb73502f13d"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5810), new Guid("8d5f34b4-c5fc-4acc-b704-a326ef9a9b54"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("500295a4-d83d-4cb1-b72e-cdda800bbf95"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5855), new Guid("408d5a9e-d14a-4fb6-8b05-b7cd02264ffc"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("6d9eb846-21d9-44a7-8ad0-a38696848a0e"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5842), new Guid("4319a5aa-3cdd-4312-b92a-71edb4474490"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("892ba8e2-8bc0-4009-aa1e-a263e71345aa"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5865), new Guid("274c39f1-a739-436f-8f53-a92c79682775"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("ad97f67f-8a14-4b81-bb18-fc49a67d1e7b"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5860), new Guid("e6db4ab1-c6d4-447e-b4f7-0becec846694"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("b335da23-cbbb-415f-beb7-91f56fa5ebb2"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5859), new Guid("7adb05d0-c69e-4413-8818-be0bebd24e62"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("c2a7ca1e-7453-4d1d-9c9a-ebc7f21cde45"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5851), new Guid("415df56b-a3d1-4272-b8b4-328ce00ec442"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("c7a40c61-b5e9-42fb-b0c4-7b0e4542ad79"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5850), new Guid("6339a165-3d7d-4823-8a37-ba179d273e23"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("d285327e-58c8-40b7-9b3d-121f01c448a2"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5863), new Guid("5562f1ab-5964-425a-a7d0-a535b4b83022"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("e1692ebe-0411-4a15-af96-d490f706a1b3"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5867), new Guid("8d3eab2f-af71-4bd1-8873-925690f68432"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("e3d7ebe3-d145-4240-a82b-24d30b129eff"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5834), new Guid("60f6bb41-9828-4ba6-904d-efc724d99de1"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("f2c98cea-3991-40c5-802f-cdf0b5ec4cd9"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5852), new Guid("b786af65-8ffe-49e0-bc53-820195ac2bd6"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("f39dcb68-b327-466e-88b7-eafa1c495f96"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5817), new Guid("69379662-e692-414d-be2f-4dce4c7cc690"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("f67cf6e5-5484-48c0-948d-6f4441fd01ab"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5835), new Guid("50d48dee-0155-45fb-8b53-63772c14f80b"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("fe0578a8-062a-4786-aee8-ebb54d553220"), true, new DateTime(2024, 4, 2, 5, 8, 22, 935, DateTimeKind.Utc).AddTicks(5836), new Guid("88005cfd-82ac-482d-8acc-d47832a33bd9"), "Clock", "Track", "Track", "User,Admin,Manager" }
                });
        }
    }
}
