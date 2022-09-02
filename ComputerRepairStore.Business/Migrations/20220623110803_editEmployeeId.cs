using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerRepairStore.Business.Migrations
{
    public partial class editEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId1",
                table: "RepairOrders");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrders_EmployeeId1",
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

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_EmployeeId",
                table: "RepairOrders",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId",
                table: "RepairOrders",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId",
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

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "RepairOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_EmployeeId1",
                table: "RepairOrders",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrders_AspNetUsers_EmployeeId1",
                table: "RepairOrders",
                column: "EmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
