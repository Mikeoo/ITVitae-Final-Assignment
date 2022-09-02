using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerRepairStore.Business.Migrations
{
    public partial class AddDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RepairOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "RepairOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "038b8459-ac71-435f-a135-87370c8ca939", "52bf0ffb-c9cc-40f3-bb50-b9a8858744ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RepairOrders");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "RepairOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66b3b3a9-8d9e-49cf-9789-ce79f27d6da5", "40d683b1-44e5-4973-8903-e4a394dc02b6" });
        }
    }
}
