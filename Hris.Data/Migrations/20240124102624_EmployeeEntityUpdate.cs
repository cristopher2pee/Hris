using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hris.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Break");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permissions");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("07555a62-8e8c-4162-9d41-8a39b939958a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("0f371825-0208-4a63-ad01-ff7eaf186024"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("170c7f13-087d-4c33-b9aa-9dd20b92352b"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("23e6842a-26a1-4153-a164-3343b7b58545"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("2d4ba9ae-1549-40e1-8d48-b3cedfef6cab"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("35e1f9ba-b48d-4e1a-94dc-4bdba4010aaa"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("381f20bd-c684-4d50-bafd-fab15710c807"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("40fdddf9-d43d-42b3-a94f-49c3ca6edcd0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("4f230d6e-1488-49b4-b05e-31bbcc060e18"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("67f5b19d-dfb5-445d-988c-6756fbe31c92"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("9a41eab1-9d5c-4899-b64b-8589056557d2"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a55bbc78-81ca-4ac1-993e-7d8423d2111c"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("af8ee477-1b8b-446c-b944-d72dfcf83d90"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("c8ac7e78-056e-49ed-b90a-2917c54f9079"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("cc3cdeb6-afbd-42f2-861f-4ab8dee51a00"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d3d77e53-d03d-486b-afde-f64bd97a03bc"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("da154543-6001-4fd4-b5bb-19bf76e988cd"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e239a9e0-aad4-4cbb-9bb2-c86b9df5a646"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e46ca2ef-352b-4257-b53f-018e30e3df07"));

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("07799b5c-ecb1-4c40-a0b8-aaa1e34fb927"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(467), new Guid("e1c52a95-9da6-4054-9973-0de91d66561c"), "Clock", "Reports", "Reports", "Admin,Manager" },
                    { new Guid("1d148b29-4860-4220-b72b-9dc397884f45"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(472), new Guid("2bfdd321-baaa-4e65-8a80-2d3d81be06d4"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("1fb1e4b7-3ef3-47b1-9d0c-da2eab92ff37"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(462), new Guid("de60055c-bd92-4bf5-9036-9588d3dbafdc"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("24aae7cb-2ca9-4085-988a-35fd3a42cb26"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(481), new Guid("2589d5e6-abf6-4059-93c3-0bb0ac830a96"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("30fdf0a2-1f29-47b2-8942-e45ddfede71d"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(474), new Guid("496ebca1-0635-49c4-9614-4e7f4f196faa"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("43d11733-6105-444a-b73b-eb8c26fe93b7"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(446), new Guid("a1f95eca-10b3-4385-ae25-c20c95e04c24"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("5a21a181-970a-4601-9573-ac185fc0f0b3"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(458), new Guid("2d101448-05f9-4f31-afd7-7069f50f0a04"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("775b6c0b-fd0f-4546-aae7-3b85706a67a0"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(466), new Guid("22338b92-698e-49e5-9754-3dd39a05672b"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("7ab9c591-f6a0-43fe-a97b-9d737e942297"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(480), new Guid("47016b68-b24a-4323-ace5-71e9067ec3a1"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("81f65bf9-807c-4ab6-92d9-82dfe2bf8abe"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(438), new Guid("6e2c6583-b258-4b5a-bc44-519dc8dd4020"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("8c9711ea-197c-4164-9c5b-1b9442bf0017"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(459), new Guid("07e16921-2ffd-4634-9cc6-f6860dbb617f"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("a4d00c9c-9470-404d-9a0a-c61d36a5be7d"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(478), new Guid("1dce7f17-2a2f-4532-a18b-03957d5d052f"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("a516ac36-2b90-47f1-8098-b98490d1ab03"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(479), new Guid("63351055-93c2-4b66-b4ba-b56f31c0ae25"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("a6d9d0c3-4d40-48cc-97cb-6d0f696a15bb"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(469), new Guid("f323f29d-1aec-49e4-a745-0474e7772db4"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("ae489890-400f-4c78-b1b8-5a3f545e790f"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(465), new Guid("55edf4dd-1eb3-4fe1-9840-158e3a95a205"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("aed8281c-cc7d-4095-8a3a-fe0f033f4b17"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(483), new Guid("27c79d7f-c746-48df-a104-bd5816fd8e89"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("d98a38b0-ccac-4709-afc6-819652fb7fb1"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(473), new Guid("e74d9b69-ff83-4d42-bf05-ff864b4c54a6"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("dd97c2a1-edd0-47e3-936a-4e675ea7d72a"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(461), new Guid("dd48b7ba-1703-4abe-91be-f240e7dc7907"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("e4e003a5-8f97-4d77-b943-dfdc7b286edc"), true, new DateTime(2024, 1, 24, 10, 26, 24, 559, DateTimeKind.Utc).AddTicks(475), new Guid("4323c70c-a2fa-497e-8e0d-81878e4d985a"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permissions",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permissions");

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("07799b5c-ecb1-4c40-a0b8-aaa1e34fb927"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1d148b29-4860-4220-b72b-9dc397884f45"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("1fb1e4b7-3ef3-47b1-9d0c-da2eab92ff37"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("24aae7cb-2ca9-4085-988a-35fd3a42cb26"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("30fdf0a2-1f29-47b2-8942-e45ddfede71d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("43d11733-6105-444a-b73b-eb8c26fe93b7"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("5a21a181-970a-4601-9573-ac185fc0f0b3"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("775b6c0b-fd0f-4546-aae7-3b85706a67a0"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("7ab9c591-f6a0-43fe-a97b-9d737e942297"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("81f65bf9-807c-4ab6-92d9-82dfe2bf8abe"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("8c9711ea-197c-4164-9c5b-1b9442bf0017"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a4d00c9c-9470-404d-9a0a-c61d36a5be7d"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a516ac36-2b90-47f1-8098-b98490d1ab03"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("a6d9d0c3-4d40-48cc-97cb-6d0f696a15bb"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("ae489890-400f-4c78-b1b8-5a3f545e790f"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("aed8281c-cc7d-4095-8a3a-fe0f033f4b17"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("d98a38b0-ccac-4709-afc6-819652fb7fb1"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("dd97c2a1-edd0-47e3-936a-4e675ea7d72a"));

            migrationBuilder.DeleteData(
                table: "Accesses",
                keyColumn: "Id",
                keyValue: new Guid("e4e003a5-8f97-4d77-b943-dfdc7b286edc"));

            migrationBuilder.CreateTable(
                name: "Break",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Break", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Break_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accesses",
                columns: new[] { "Id", "Active", "Modified", "ModifiedBy", "Module", "Name", "Path", "Roles" },
                values: new object[,]
                {
                    { new Guid("07555a62-8e8c-4162-9d41-8a39b939958a"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2303), new Guid("5d6b4aa0-ef9e-4c3a-b391-d0c13735210b"), "Leave", "LeaveType", "Leave-Types", "Admin,Manager,Hr" },
                    { new Guid("0f371825-0208-4a63-ad01-ff7eaf186024"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2271), new Guid("770f77e2-c574-4d04-a076-391868d727ec"), "Clock", "Project", "Project", "Admin,Manager" },
                    { new Guid("170c7f13-087d-4c33-b9aa-9dd20b92352b"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2296), new Guid("4c5bbcc3-af5b-49cb-b0c4-324b6d51d87c"), "Admin", "Invite", "Invite", "Admin,Manager,Hr" },
                    { new Guid("23e6842a-26a1-4153-a164-3343b7b58545"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2309), new Guid("d08aead3-373f-4430-be4b-b08fb91002cf"), "Leave", "LeaveRequest", "Leave-Request", "Admin,Manager,Hr,Lead" },
                    { new Guid("2d4ba9ae-1549-40e1-8d48-b3cedfef6cab"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2264), new Guid("292ef55f-5dfc-4c5d-ae70-933c6b337982"), "Employees", "Employee", "Employee", "Admin,Hr" },
                    { new Guid("35e1f9ba-b48d-4e1a-94dc-4bdba4010aaa"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2302), new Guid("74d5164b-0fe7-4a8f-9068-6fa9c3ecbee1"), "Admin", "Permission", "Permission", "Admin,Manager" },
                    { new Guid("381f20bd-c684-4d50-bafd-fab15710c807"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2284), new Guid("0a9f3c2a-9100-4351-a7b7-64570df0bc2d"), "Clock", "Clients", "Clients", "Admin,Manager" },
                    { new Guid("40fdddf9-d43d-42b3-a94f-49c3ca6edcd0"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2308), new Guid("5e52b6ab-e398-40e4-b891-8d856abf3500"), "Leave", "LeaveApplication", "Leave-Application", "Admin,Manager,Hr,Lead,User" },
                    { new Guid("4f230d6e-1488-49b4-b05e-31bbcc060e18"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2287), new Guid("7b1d5d2f-debd-4948-b97e-90499ddff86c"), "Clock", "ChangeRequest", "ChangeRequest", "Admin,Manager" },
                    { new Guid("67f5b19d-dfb5-445d-988c-6756fbe31c92"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2286), new Guid("caaea997-85cc-4ec7-b317-4376daf30617"), "Clock", "Track", "Track", "User,Admin,Manager" },
                    { new Guid("9a41eab1-9d5c-4899-b64b-8589056557d2"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2295), new Guid("47d61a9a-d8d4-407c-aad1-793dd35bdc8a"), "Payroll", "Entitlements", "Entitlements", "Admin,Hr" },
                    { new Guid("a55bbc78-81ca-4ac1-993e-7d8423d2111c"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2293), new Guid("c9748f95-042a-48e5-b239-c7e01b6955fb"), "Payroll", "AllowanceType", "AllowanceType", "Admin,Hr" },
                    { new Guid("af8ee477-1b8b-446c-b944-d72dfcf83d90"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2269), new Guid("7d86697c-2207-472f-a8aa-e5fb623279d4"), "Employees", "Position", "Position", "Admin,Manager" },
                    { new Guid("c8ac7e78-056e-49ed-b90a-2917c54f9079"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2267), new Guid("88a7efa7-b8bb-4507-a208-12243c4eb1ce"), "Employees", "Department", "Department", "Admin,Manager" },
                    { new Guid("cc3cdeb6-afbd-42f2-861f-4ab8dee51a00"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2307), new Guid("5adac70b-0116-48f0-88e2-69ee7612dfa2"), "Leave", "LeaveEntitlement", "Leave-Entitlement", "Admin,Manager,Hr" },
                    { new Guid("d3d77e53-d03d-486b-afde-f64bd97a03bc"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2288), new Guid("f8482e66-7c17-48c8-a16b-0052e24811d6"), "Clock", "AssignProject", "AssignProject", "Admin,Manager" },
                    { new Guid("da154543-6001-4fd4-b5bb-19bf76e988cd"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2299), new Guid("f88c3722-b779-416f-be43-7aa56c09eb09"), "Admin", "Access", "Access", "Admin,Manager" },
                    { new Guid("e239a9e0-aad4-4cbb-9bb2-c86b9df5a646"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2301), new Guid("54c4eaa9-5cb9-4872-be2f-f15039f13cd3"), "Admin", "Calendar", "Calendar", "Admin,Manager,Hr" },
                    { new Guid("e46ca2ef-352b-4257-b53f-018e30e3df07"), true, new DateTime(2024, 1, 19, 14, 57, 29, 793, DateTimeKind.Utc).AddTicks(2292), new Guid("dd7f9e21-e55d-4558-8a8a-b04a0a6420c6"), "Clock", "Reports", "Reports", "Admin,Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permissions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Break_TrackId",
                table: "Break",
                column: "TrackId");
        }
    }
}
