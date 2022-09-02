using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ComputerRepairStore.Business.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AspNetUsers_CustomerId",
                table: "RepairOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId",
                table: "RepairOrders");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrders_CustomerId",
                table: "RepairOrders");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrders_EmployeeId",
                table: "RepairOrders");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "RepairOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "RepairOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "RepairOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "RepairOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "ZipCode" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, null, null, "b050d278-56b4-43f8-a9d6-c6438cdb1889", "admin@ad.min", true, null, false, null, null, null, null, null, false, "ff3bd721-41de-4b5e-8b1a-eb2a45523ee6", false, "Admin", 0, null });

            migrationBuilder.InsertData(
                table: "RepairOrders",
                columns: new[] { "Id", "AcceptationDate", "CommentCancellation", "CustomerId", "CustomerId1", "Deleted", "EmployeeId", "EmployeeId1", "Photo", "PlannedFinishDate", "RegistrationDate", "RepairStatus" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null, false, 1, null, null, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(2022, 6, 9, 11, 0, 17, 290, DateTimeKind.Local).AddTicks(6430), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_CustomerId1",
                table: "RepairOrders",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_EmployeeId1",
                table: "RepairOrders",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AspNetUsers_CustomerId1",
                table: "RepairOrders",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId1",
                table: "RepairOrders",
                column: "EmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AspNetUsers_CustomerId1",
                table: "RepairOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId1",
                table: "RepairOrders");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrders_CustomerId1",
                table: "RepairOrders");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrders_EmployeeId1",
                table: "RepairOrders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");

            migrationBuilder.DeleteData(
                table: "RepairOrders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "RepairOrders");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "RepairOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "RepairOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_CustomerId",
                table: "RepairOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_EmployeeId",
                table: "RepairOrders",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AspNetUsers_CustomerId",
                table: "RepairOrders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId",
                table: "RepairOrders",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
