using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnityAnalytics.Back.Persistence.Migrations
{
    public partial class UserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsersUsers",
                columns: new[] { "Id", "AppRoleId", "CreatedAt", "Password", "UserName" },
                values: new object[] { new Guid("d1ebcafc-85a1-4c6d-a0ad-c23f7267fc9c"), 1, new DateTime(2024, 9, 5, 18, 50, 17, 425, DateTimeKind.Local).AddTicks(6887), "leonbrave", "leonbrave" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsersUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1ebcafc-85a1-4c6d-a0ad-c23f7267fc9c"));
        }
    }
}
