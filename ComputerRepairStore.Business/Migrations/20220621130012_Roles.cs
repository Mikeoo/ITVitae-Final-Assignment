using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerRepairStore.Business.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "RepairOrders",
                newName: "Photos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photos",
                table: "RepairOrders",
                newName: "Photo");
        }
    }
}
