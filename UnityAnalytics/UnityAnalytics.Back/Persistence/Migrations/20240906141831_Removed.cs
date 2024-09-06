using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnityAnalytics.Back.Persistence.Migrations
{
    public partial class Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsersUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1ebcafc-85a1-4c6d-a0ad-c23f7267fc9c"));

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AppUsersUsers",
                columns: new[] { "Id", "AppRoleId", "CreatedAt", "Password", "UserName" },
                values: new object[] { new Guid("cf209c0e-9d5d-48a1-8d2e-799f1245bdc2"), 1, new DateTime(2024, 9, 6, 17, 18, 31, 738, DateTimeKind.Local).AddTicks(8830), "leonbrave", "leonbrave" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsersUsers",
                keyColumn: "Id",
                keyValue: new Guid("cf209c0e-9d5d-48a1-8d2e-799f1245bdc2"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AppUsersUsers",
                columns: new[] { "Id", "AppRoleId", "CreatedAt", "Password", "UserName" },
                values: new object[] { new Guid("d1ebcafc-85a1-4c6d-a0ad-c23f7267fc9c"), 1, new DateTime(2024, 9, 5, 18, 50, 17, 425, DateTimeKind.Local).AddTicks(6887), "leonbrave", "leonbrave" });
        }
    }
}
