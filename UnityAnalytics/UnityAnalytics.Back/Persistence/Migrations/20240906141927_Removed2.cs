using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnityAnalytics.Back.Persistence.Migrations
{
    public partial class Removed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsersUsers",
                keyColumn: "Id",
                keyValue: new Guid("cf209c0e-9d5d-48a1-8d2e-799f1245bdc2"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AppUsersUsers",
                columns: new[] { "Id", "AppRoleId", "CreatedAt", "Password", "UserName" },
                values: new object[] { new Guid("f30f8268-f62e-4008-8cab-3ba5ad0bc7d7"), 1, new DateTime(2024, 9, 6, 17, 19, 27, 775, DateTimeKind.Local).AddTicks(2726), "leonbrave", "leonbrave" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsersUsers",
                keyColumn: "Id",
                keyValue: new Guid("f30f8268-f62e-4008-8cab-3ba5ad0bc7d7"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppUsersUsers",
                columns: new[] { "Id", "AppRoleId", "CreatedAt", "Password", "UserName" },
                values: new object[] { new Guid("cf209c0e-9d5d-48a1-8d2e-799f1245bdc2"), 1, new DateTime(2024, 9, 6, 17, 18, 31, 738, DateTimeKind.Local).AddTicks(8830), "leonbrave", "leonbrave" });
        }
    }
}
