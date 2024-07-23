using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPagesToContext : Migration
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

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("09b733af-947f-4196-b201-45adaa9f0ee7"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1721), new Guid("1ff61ada-eb51-4b15-8f33-4f42f3b4bc08"), "Employees", "My Department Team", "My-Department-Team", "Admin,Manager,Lead" },
                    { new Guid("16d2270d-fd43-42f4-a77f-e3174d8657f8"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1685), new Guid("f010b9f5-c343-48ea-bdee-5607d4915c48"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("28789567-566e-4a2d-9d2a-eb54e9d8e117"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1698), new Guid("cbfad239-783b-4307-bf99-5bb311196134"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("28852bb6-18d0-414b-a031-359944128a60"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1694), new Guid("b683b42a-45ea-496b-8370-d3bf81c28835"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("3dbb05a1-afd4-48a2-b867-320b58bf54d5"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1718), new Guid("6d5a5845-8369-4c1f-84ab-6be099b4b137"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("3fd24731-ff87-459c-8e36-7cd336a99c1d"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1710), new Guid("668a1135-0f46-4832-a8c2-67b5d9ceee26"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("42a3ce86-96a3-4c6c-a3ae-065423ea5e3e"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1668), new Guid("c6799656-ffd1-483f-8190-4ae04c7cda16"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("59fe02c2-d7d1-4e2b-9132-96efa54e226f"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1709), new Guid("4d281036-5338-4231-a66d-06483ed8fb35"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("5fd1dd81-af54-48bd-b5fe-560ab62edb19"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1683), new Guid("e86d6250-991c-4973-9a38-9b8e1d147086"), "Employees", "Generate Employee COE", "Employee-Reports/Generate-Coe", "Admin,Manager,Hr" },
                    { new Guid("6458e77c-92a8-4c3c-bdb1-e85dbf1390fe"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1666), new Guid("d7e132f5-1b7d-4ca3-865a-1c36a3d0a2ed"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("6dca4ee3-059a-4a7b-85d6-967568ee035e"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1687), new Guid("c4d78ded-bee8-4774-810f-f5515a58ed8f"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("7a5be50b-ccda-48b3-8d6f-72d30b1826fa"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1719), new Guid("296084f6-8dd2-4ab7-ac76-aeadf3a3430e"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("7bb6bf59-6d60-428a-b27c-c26e2579457f"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1693), new Guid("ae112326-5d41-4be0-a509-a9dad1a9f1b3"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("7f6e1d55-8ab6-44b4-ab9b-152382f2c640"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1704), new Guid("e280a8ac-56b8-4b30-b992-f85eaf652e13"), "Payroll", "Shift Schedules", "Shift-Schedules", "Admin,Hr" },
                    { new Guid("9bcaf44e-0650-49de-876c-83d9412586b7"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1716), new Guid("41dd6e96-df4f-41b3-93f8-1029075475d8"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("aac2d816-a15f-47a6-9714-bde1b87f2da6"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1713), new Guid("2cb55152-ffcb-4e2e-b033-9c9c6ba8ec3e"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("b98fd52d-5f19-461e-9490-1fae91946f82"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1702), new Guid("220b8017-9c1a-4446-ac99-9700f2c8890d"), "Payroll", "Deduction Type", "Deduction-Type", "Admin,Hr" },
                    { new Guid("dd3f2386-b0b9-4ca8-90fd-00402e7178f7"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1696), new Guid("aa28ad52-50c1-4ee0-9a0e-49db1b98b617"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("e0bff17a-7707-4a99-89aa-afbe58c6d3d9"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1689), new Guid("c1e68381-678d-40f2-9e19-23cbff4a3e4b"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("eab8b47c-5bb0-43a9-ac83-b24ee10f6029"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1712), new Guid("4632557d-fd0c-42c8-83c6-e81ef411c9b4"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("f1c03ab3-6cb3-4fb4-bf0a-485f7b58aefb"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1662), new Guid("3bd959fa-f526-44be-a0b6-e1d517ce4633"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("f34ade57-a64d-4204-910b-2f96a18a4e1b"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1670), new Guid("124540b1-db99-44e5-ac12-08acef5de86d"), "Employees", "Employee Reports", "Employee-Reports", "Admin,Manager,Hr" },
                    { new Guid("f6d7ee3d-4100-48e6-856e-5695401476fc"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1701), new Guid("fbc5b9b4-bdd6-42a3-8d19-62de28bfd5a0"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("fa8767c1-683d-4c95-b197-efafbe5bddf0"), true, new DateTime(2024, 4, 2, 9, 21, 15, 499, DateTimeKind.Utc).AddTicks(1705), new Guid("3d0291f3-91f3-4e86-9fbd-9c3b946d611a"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("09b733af-947f-4196-b201-45adaa9f0ee7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("16d2270d-fd43-42f4-a77f-e3174d8657f8"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("28789567-566e-4a2d-9d2a-eb54e9d8e117"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("28852bb6-18d0-414b-a031-359944128a60"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3dbb05a1-afd4-48a2-b867-320b58bf54d5"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("3fd24731-ff87-459c-8e36-7cd336a99c1d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("42a3ce86-96a3-4c6c-a3ae-065423ea5e3e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("59fe02c2-d7d1-4e2b-9132-96efa54e226f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5fd1dd81-af54-48bd-b5fe-560ab62edb19"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6458e77c-92a8-4c3c-bdb1-e85dbf1390fe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("6dca4ee3-059a-4a7b-85d6-967568ee035e"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7a5be50b-ccda-48b3-8d6f-72d30b1826fa"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7bb6bf59-6d60-428a-b27c-c26e2579457f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7f6e1d55-8ab6-44b4-ab9b-152382f2c640"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9bcaf44e-0650-49de-876c-83d9412586b7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aac2d816-a15f-47a6-9714-bde1b87f2da6"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("b98fd52d-5f19-461e-9490-1fae91946f82"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("dd3f2386-b0b9-4ca8-90fd-00402e7178f7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e0bff17a-7707-4a99-89aa-afbe58c6d3d9"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("eab8b47c-5bb0-43a9-ac83-b24ee10f6029"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f1c03ab3-6cb3-4fb4-bf0a-485f7b58aefb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f34ade57-a64d-4204-910b-2f96a18a4e1b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("f6d7ee3d-4100-48e6-856e-5695401476fc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("fa8767c1-683d-4c95-b197-efafbe5bddf0"));

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
