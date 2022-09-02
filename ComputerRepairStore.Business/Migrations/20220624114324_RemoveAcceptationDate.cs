using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ComputerRepairStore.Business.Migrations
{
    public partial class RemoveAcceptationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptationDate",
                table: "RepairOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4b9061ee-955b-4a21-95d1-f45283622f35", "d97700b7-90ed-4452-bafe-aed3f9963795" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptationDate",
                table: "RepairOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "038b8459-ac71-435f-a135-87370c8ca939", "52bf0ffb-c9cc-40f3-bb50-b9a8858744ae" });
        }
    }
}
