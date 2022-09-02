using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerRepairStore.Business.Migrations
{
    public partial class ReSeedingAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType", "ZipCode" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, null, null, "66b3b3a9-8d9e-49cf-9789-ce79f27d6da5", "admin@ad.min", true, null, null, false, null, null, null, null, null, false, "40d683b1-44e5-4973-8903-e4a394dc02b6", false, "Admin", 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");
        }
    }
}
