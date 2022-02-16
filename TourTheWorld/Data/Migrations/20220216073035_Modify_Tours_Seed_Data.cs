using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourTheWorld.Data.Migrations
{
    public partial class Modify_Tours_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: -2L,
                column: "DateCreated",
                value: new DateTime(2022, 2, 14, 15, 28, 39, 282, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: -1L,
                column: "DateCreated",
                value: new DateTime(2022, 2, 14, 15, 28, 39, 282, DateTimeKind.Local).AddTicks(7149));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: -2L,
                column: "DateCreated",
                value: new DateTime(2022, 2, 14, 19, 21, 56, 635, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: -1L,
                column: "DateCreated",
                value: new DateTime(2022, 2, 14, 19, 21, 56, 634, DateTimeKind.Local).AddTicks(2348));
        }
    }
}
