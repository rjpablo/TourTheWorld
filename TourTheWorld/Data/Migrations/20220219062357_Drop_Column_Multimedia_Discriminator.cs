using Microsoft.EntityFrameworkCore.Migrations;

namespace TourTheWorld.Data.Migrations
{
    public partial class Drop_Column_Multimedia_Discriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Multimedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Multimedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Multimedia",
                keyColumn: "Id",
                keyValue: -2L,
                column: "Discriminator",
                value: "MultimediaModel");

            migrationBuilder.UpdateData(
                table: "Multimedia",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Discriminator",
                value: "MultimediaModel");
        }
    }
}
