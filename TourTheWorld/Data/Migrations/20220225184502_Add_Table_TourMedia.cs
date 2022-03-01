using Microsoft.EntityFrameworkCore.Migrations;

namespace TourTheWorld.Data.Migrations
{
    public partial class Add_Table_TourMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourMedia",
                columns: table => new
                {
                    MediaId = table.Column<long>(nullable: false),
                    TourId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourMedia", x => new { x.TourId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_TourMedia_Multimedia_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Multimedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TourMedia_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourMedia_MediaId",
                table: "TourMedia",
                column: "MediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourMedia");
        }
    }
}
