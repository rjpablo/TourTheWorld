using Microsoft.EntityFrameworkCore.Migrations;

namespace TourTheWorld.Data.Migrations
{
    public partial class Modify_PrimaryMediaId_Column_Tours_Table_Made_Optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Multimedia_PrimaryMediaId",
                table: "Tours");

            migrationBuilder.AlterColumn<long>(
                name: "PrimaryMediaId",
                table: "Tours",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Multimedia_PrimaryMediaId",
                table: "Tours",
                column: "PrimaryMediaId",
                principalTable: "Multimedia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Multimedia_PrimaryMediaId",
                table: "Tours");

            migrationBuilder.AlterColumn<long>(
                name: "PrimaryMediaId",
                table: "Tours",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Multimedia_PrimaryMediaId",
                table: "Tours",
                column: "PrimaryMediaId",
                principalTable: "Multimedia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
