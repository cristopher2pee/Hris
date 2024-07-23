using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtableemployeestatutories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statutories");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("018cbc42-6e73-4f4f-985a-fd4a834af32a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("09afe205-f028-45af-b306-b9c0b8740645"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("09da1499-c2ed-46fd-9922-48285fdd315d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("12b27cbd-8b22-4405-a3d7-7c803f736895"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("17b0b5f7-faab-4ab1-a956-cf009568fcf9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("17d0a853-0105-47b6-8a90-b09e6c638663"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("227b502e-7116-43d9-82e4-852e37902761"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2e4b7b85-9fa9-49ab-8bd0-3ae93b1ba301"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4d74563d-5e55-48c6-970d-7586b0c2853c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4e1e3a0e-13c1-4190-9bce-4751dd6be3f5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6f9c88d1-058f-46c9-bec7-8926e1537b29"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("834156c9-82ba-4d16-b27d-df3bc0a0061a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("85de7f2c-81cf-4b4f-8795-a7839f46e9d8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("96be1c56-5b92-488c-ade7-2cf9512aef1f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9bf79277-1d49-4214-b101-c7a2ee7f1514"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9dc76d57-b3db-40a6-a3bd-787d4260fd1c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a2446da2-8f62-46fc-8261-228ce7304b38"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a51f603b-fa81-4f19-8e3c-bcbbffc17ffb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b50ed4f5-c59d-4654-b965-64cfdf8fe4a5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d27a0f0a-a993-4f51-96a2-3f512397a36c"));

            migrationBuilder.CreateTable(
                name: "EmployeeStatutories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SSSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSSEE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSSEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHICER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHICEE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HDMFER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HDMFEE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatutories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeStatutories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("027860c2-edcb-4e4b-952b-37ccac68e9c1"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9430), new Guid("c6983697-f146-432c-9296-838779bd13a5"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("1e7fa783-155b-4962-bd60-d09e8ef46abd"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9440), new Guid("7edab38f-bd62-44c7-92dd-5e111acb0a68"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("24c1667e-d8ab-4c21-8539-99d6290d4c0d"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9417), new Guid("ec24438f-1bd4-48bb-b4e5-2a6b7c703311"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("425d45b4-53a9-43da-b807-3754ba684933"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9437), new Guid("69fb48c5-29c5-4a6b-9121-c0ef8a9a91ca"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("45bc0de3-6c19-4f82-88f6-d01cdd397f44"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9414), new Guid("2eaf8f9a-feb6-4a73-9160-01c6afdf28d5"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("46b86e9c-5e53-4c36-adf3-0c49990b0157"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9425), new Guid("bc90bfec-753f-4b1c-83ca-fc85109b6eb2"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("4d2cb972-1dd5-495c-b7e4-325c4a729cd7"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9420), new Guid("03544d5c-33da-414f-a103-790c08b9acbb"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("6ee89124-cf60-45fd-82e0-34911015b49f"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9407), new Guid("427d7507-59c3-4185-8e0a-2987b35c9cfd"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("74a2e7ae-3494-4678-9a62-617198dadf15"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9391), new Guid("74c48cc1-5d12-44f4-808f-08f4a16d26c1"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("7b8d24d7-3205-49ba-9d72-e56b2cbc6db6"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9422), new Guid("2b256d8c-2c35-4373-888a-d0ac329c7acc"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("88211b11-59d0-4ecd-9034-66c66514efa3"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9419), new Guid("06caa817-34af-4695-910f-b8515f8e45a9"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("8d0e3d08-c00a-4e93-b97c-2cfa88e2b53e"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9433), new Guid("1594ac09-97a0-4753-9797-20544397d531"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("8f01c799-96ef-4f92-9cce-5c464cfb84b2"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9436), new Guid("b2c4b433-178f-48a3-bb88-2b7f6ed5d53a"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("941e0eed-e459-4a6c-9cfc-13d6f248f7fb"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9434), new Guid("bd984f0f-3743-4b45-b26f-8e56a6b90814"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("a87012e3-471f-4bc7-ad51-0169622820db"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9428), new Guid("95a133d0-f263-4fe0-af12-ebf2a9e932ec"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("aad02ea1-d0b5-4397-988d-66f5c32177ac"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9385), new Guid("b8f2932c-aa2a-4c64-bcf5-004a5e08d106"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("c45e3edd-08d4-40e0-bff3-5d57b16c5138"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9393), new Guid("9d2b649a-ff05-4d1c-9741-2fc7e418eb5d"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("e09700a5-062e-4c8d-adc7-c2a83c00a1e1"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9409), new Guid("e6c2f8d9-f050-4e20-8354-3dd0040856c4"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("f115f5bc-8bfe-4855-a3e9-48ec5f9e833f"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9412), new Guid("050204b7-e3d2-4d5d-b72e-da96d0d2ee80"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("feea863b-b9c0-4309-ac82-2a8b419c0e48"), true, new DateTime(2024, 4, 3, 4, 46, 18, 343, DateTimeKind.Utc).AddTicks(9427), new Guid("9be2e615-0bbb-42e5-b9f1-1358353c2eda"), "Admin", "Access", "Access", "Admin,Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStatutories_EmployeeId",
                table: "EmployeeStatutories",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeStatutories");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("027860c2-edcb-4e4b-952b-37ccac68e9c1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1e7fa783-155b-4962-bd60-d09e8ef46abd"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("24c1667e-d8ab-4c21-8539-99d6290d4c0d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("425d45b4-53a9-43da-b807-3754ba684933"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("45bc0de3-6c19-4f82-88f6-d01cdd397f44"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("46b86e9c-5e53-4c36-adf3-0c49990b0157"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4d2cb972-1dd5-495c-b7e4-325c4a729cd7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6ee89124-cf60-45fd-82e0-34911015b49f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("74a2e7ae-3494-4678-9a62-617198dadf15"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7b8d24d7-3205-49ba-9d72-e56b2cbc6db6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("88211b11-59d0-4ecd-9034-66c66514efa3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8d0e3d08-c00a-4e93-b97c-2cfa88e2b53e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8f01c799-96ef-4f92-9cce-5c464cfb84b2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("941e0eed-e459-4a6c-9cfc-13d6f248f7fb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a87012e3-471f-4bc7-ad51-0169622820db"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aad02ea1-d0b5-4397-988d-66f5c32177ac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c45e3edd-08d4-40e0-bff3-5d57b16c5138"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e09700a5-062e-4c8d-adc7-c2a83c00a1e1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f115f5bc-8bfe-4855-a3e9-48ec5f9e833f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("feea863b-b9c0-4309-ac82-2a8b419c0e48"));

            migrationBuilder.CreateTable(
                name: "Statutories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatutoryType = table.Column<int>(type: "int", nullable: false),
                    StutoryId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statutories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statutories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("018cbc42-6e73-4f4f-985a-fd4a834af32a"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3478), new Guid("3dc82b59-34bf-4285-a1ca-524b27386fb9"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("09afe205-f028-45af-b306-b9c0b8740645"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3499), new Guid("ae9d46f0-168e-4a0e-a196-9b12d6acc052"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("09da1499-c2ed-46fd-9922-48285fdd315d"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3514), new Guid("af068d07-8110-42f5-bc68-6e321e71496d"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("12b27cbd-8b22-4405-a3d7-7c803f736895"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3518), new Guid("c77917f9-b346-46a5-9f3f-527f69741101"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("17b0b5f7-faab-4ab1-a956-cf009568fcf9"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3472), new Guid("394d5523-d377-498f-ae51-b1761dd1b162"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("17d0a853-0105-47b6-8a90-b09e6c638663"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3480), new Guid("16dd8373-502f-419c-b322-c86e0fd5ff8c"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("227b502e-7116-43d9-82e4-852e37902761"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3503), new Guid("4c307092-0eac-43ab-a38a-6c32ba357bb2"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("2e4b7b85-9fa9-49ab-8bd0-3ae93b1ba301"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3508), new Guid("f516d96b-fc14-4ea0-bfe0-0d09f007d343"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("4d74563d-5e55-48c6-970d-7586b0c2853c"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3500), new Guid("4e760a5c-27fb-41a5-bd63-38884a01d952"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("4e1e3a0e-13c1-4190-9bce-4751dd6be3f5"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3509), new Guid("137aa12e-4c87-4da7-8573-5a692c39bf68"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("6f9c88d1-058f-46c9-bec7-8926e1537b29"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3493), new Guid("0f62687d-c369-4ae3-8e25-8698af822110"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("834156c9-82ba-4d16-b27d-df3bc0a0061a"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3516), new Guid("0378ab84-ce80-4a71-bb55-4420c8eecaf6"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("85de7f2c-81cf-4b4f-8795-a7839f46e9d8"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3490), new Guid("47d56c75-7ce3-413a-9972-23ba6f32f65d"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("96be1c56-5b92-488c-ade7-2cf9512aef1f"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3491), new Guid("01cbb655-d6b5-4568-a28e-77d36e641a7d"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("9bf79277-1d49-4214-b101-c7a2ee7f1514"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3502), new Guid("1aa2ec61-2ae8-4492-87b4-ddccf07c2bfe"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("9dc76d57-b3db-40a6-a3bd-787d4260fd1c"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3506), new Guid("605a04e4-eb87-4d94-9de0-0dcab089a98b"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("a2446da2-8f62-46fc-8261-228ce7304b38"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3521), new Guid("b418fac4-3bf8-4ae2-8949-b24a456de0bd"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("a51f603b-fa81-4f19-8e3c-bcbbffc17ffb"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3517), new Guid("8166311f-e544-45b0-b9f5-ede29992ae0f"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("b50ed4f5-c59d-4654-b965-64cfdf8fe4a5"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3494), new Guid("f4432d59-0237-4a55-858f-c0b10dd36563"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("d27a0f0a-a993-4f51-96a2-3f512397a36c"), true, new DateTime(2024, 4, 2, 11, 28, 26, 903, DateTimeKind.Utc).AddTicks(3511), new Guid("03677aef-35a9-4ac1-9abf-9b8326ae8b57"), "Admin", "Permission", "Permission", "Admin,Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statutories_EmployeeId",
                table: "Statutories",
                column: "EmployeeId");
        }
    }
}
