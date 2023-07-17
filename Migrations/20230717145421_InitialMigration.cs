using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    song = table.Column<string>(type: "TEXT", nullable: true),
                    album = table.Column<string>(type: "TEXT", nullable: true),
                    artist = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "id", "album", "artist", "name", "song" },
                values: new object[,]
                {
                    { "song1", "Without Warning", "Metro Boomin", "Rap Saved Me", "21 Savage, Offset & Metro Boomin -  Rap Saved Me  Ft Quavo (Official Audio)" },
                    { "song2", "Live.Love.A$AP", "A$AP Rocky", "Trilla", "A$AP Rocky - Trilla (Ft. A$AP Twelvy & A$AP Nast) [LiveLoveAsap]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
