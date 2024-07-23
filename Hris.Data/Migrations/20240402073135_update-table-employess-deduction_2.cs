using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetableemployessdeduction_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
