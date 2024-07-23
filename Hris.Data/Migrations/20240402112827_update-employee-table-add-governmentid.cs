using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateemployeetableaddgovernmentid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("05acf3d3-690f-484c-bbe0-4e8a4e4906b3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("13f3a0e8-18ce-4297-bc96-824ba3c79bbe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("21619a94-f742-45b2-9987-62d4926e0439"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("319f91bd-f5f6-4ddc-a000-3f015ccb359d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("344b2dd7-d8c2-42f0-a2d6-fbbebaeb5d15"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("37fecb9e-92bb-4e31-927a-7770e761c0df"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3b72ccd4-06b1-4510-8ae0-4abddd2c181a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("434337bb-f494-4ca6-b62a-647c2a7bd777"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4737df49-b06b-4cc9-bf1c-bb18174370c2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("53891e92-c27c-4127-9898-e877f416125e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("53ef3828-9cee-48ac-89a8-f493ae8543ed"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("65b42ef0-6a91-41c4-8f3e-53314600f1d2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7aedab50-d922-420c-b01f-6bfdb9d5a17b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("853e06b3-288f-4846-94c8-e29eba460da2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("88bfb00a-b2af-4562-854b-ecc88f3d956c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a4d1334a-636a-4ced-85e7-df8d2d3488c2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a956ab27-f2b3-46e4-87cd-39f402b20aac"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b1ad66f3-5f28-49d0-af1c-089f15b0beb6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c8bc5cfe-3bc0-40b5-869a-0c6be8615e1b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fd5a05bb-ca08-4577-9aa9-c353ce4d7cb1"));

            migrationBuilder.AddColumn<string>(
                name: "PagIbigId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhilHealthId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSSId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TIN",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "PagIbigId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhilHealthId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SSSId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TIN",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("05acf3d3-690f-484c-bbe0-4e8a4e4906b3"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9780), new Guid("f1d11f21-214b-4bc1-a15c-785856d0dce5"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("13f3a0e8-18ce-4297-bc96-824ba3c79bbe"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9778), new Guid("18c5c2be-a005-4bd1-b885-6ba178d1ce07"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("21619a94-f742-45b2-9987-62d4926e0439"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9783), new Guid("14cf2fcb-bb93-4312-992d-1548e88f696a"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("319f91bd-f5f6-4ddc-a000-3f015ccb359d"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9772), new Guid("7589dea6-4e57-4274-af6f-a7251a63689a"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("344b2dd7-d8c2-42f0-a2d6-fbbebaeb5d15"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9735), new Guid("29d82d8a-f38d-48c6-acea-0383473adc6a"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("37fecb9e-92bb-4e31-927a-7770e761c0df"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9776), new Guid("d6ecca4c-defd-4fa5-9882-fe11a65eda6e"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("3b72ccd4-06b1-4510-8ae0-4abddd2c181a"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9777), new Guid("9e056021-7068-4021-ac84-5ec90789e81a"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("434337bb-f494-4ca6-b62a-647c2a7bd777"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9753), new Guid("a16b5317-c62f-4465-98e0-d48b593b92a1"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("4737df49-b06b-4cc9-bf1c-bb18174370c2"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9773), new Guid("b381e6dd-564e-461a-9b22-8418aa38eab1"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("53891e92-c27c-4127-9898-e877f416125e"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9768), new Guid("1c881d1c-65bd-4533-b14f-98c5d58415c1"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("53ef3828-9cee-48ac-89a8-f493ae8543ed"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9761), new Guid("359e8947-f08d-4505-99e6-0077ba095ac6"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("65b42ef0-6a91-41c4-8f3e-53314600f1d2"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9765), new Guid("814e0e80-ef68-440f-b9ee-529acafa10ee"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("7aedab50-d922-420c-b01f-6bfdb9d5a17b"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9785), new Guid("921f0ffa-cef2-4347-b368-d3550467d4b9"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("853e06b3-288f-4846-94c8-e29eba460da2"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9784), new Guid("01e2c2da-775d-4fe3-9274-c30f26dd6e16"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("88bfb00a-b2af-4562-854b-ecc88f3d956c"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9764), new Guid("bd604e42-d54a-4296-ac88-643d2709ba28"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("a4d1334a-636a-4ced-85e7-df8d2d3488c2"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9769), new Guid("04d6dac0-e9d1-4736-a4a0-635c028e8bac"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("a956ab27-f2b3-46e4-87cd-39f402b20aac"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9754), new Guid("8b0264af-4b0e-425c-81bb-af0fe1020aea"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("b1ad66f3-5f28-49d0-af1c-089f15b0beb6"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9756), new Guid("8149ae8e-7080-46fc-951f-9f0bfe3563c8"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("c8bc5cfe-3bc0-40b5-869a-0c6be8615e1b"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9763), new Guid("e323ba02-1d6e-4d1b-8ebc-f28eb66c60f8"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("fd5a05bb-ca08-4577-9aa9-c353ce4d7cb1"), true, new DateTime(2024, 4, 2, 7, 31, 35, 203, DateTimeKind.Utc).AddTicks(9758), new Guid("f9bcbf7e-f9b2-4e7f-9021-f5ec70d96a10"), "Clock", "Clients", "Clients", "Admin,Manager" }
                });
        }
    }
}
