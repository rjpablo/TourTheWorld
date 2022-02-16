using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourTheWorld.Data.Migrations
{
    public partial class Add_Tours_and_Multimedia_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(11, 2)", nullable: false),
                    PrimaryMediaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Multimedia_PrimaryMediaId",
                        column: x => x.PrimaryMediaId,
                        principalTable: "Multimedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Multimedia",
                columns: new[] { "Id", "DateCreated", "Description", "Discriminator", "Title", "Type", "Url" },
                values: new object[] { -1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dance with the waves", "MultimediaModel", "Beach", 0, "https://thumbs.dreamstime.com/b/sunrise-over-beach-cancun-beautiful-mexico-40065727.jpg" });

            migrationBuilder.InsertData(
                table: "Multimedia",
                columns: new[] { "Id", "DateCreated", "Description", "Discriminator", "Title", "Type", "Url" },
                values: new object[] { -2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Get lost in nature", "MultimediaModel", "Forest", 0, "https://miro.medium.com/max/1400/1*IC7_pdLtDMqwoqLkTib4JQ.jpeg" });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "DateCreated", "Description", "Price", "PrimaryMediaId", "Title" },
                values: new object[] { -1L, new DateTime(2022, 2, 14, 19, 21, 56, 634, DateTimeKind.Local).AddTicks(2348), "Whole day trip around Pangasinan", 2500.00m, -1L, "Pangasinan Day Tour" });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "DateCreated", "Description", "Price", "PrimaryMediaId", "Title" },
                values: new object[] { -2L, new DateTime(2022, 2, 14, 19, 21, 56, 635, DateTimeKind.Local).AddTicks(2099), "Whole day trip around La Union", 2200.00m, -2L, "La Union Day Tour" });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_PrimaryMediaId",
                table: "Tours",
                column: "PrimaryMediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Multimedia");
        }
    }
}
