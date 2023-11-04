using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entertainment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Release = table.Column<string>(type: "longtext", nullable: false),
                    Date = table.Column<string>(type: "longtext", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    Genres = table.Column<string>(type: "longtext", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false),
                    Anime_Seasons = table.Column<int>(type: "int", nullable: true),
                    Studio = table.Column<string>(type: "longtext", nullable: true),
                    Anime_Episodes = table.Column<int>(type: "int", nullable: true),
                    Book_Pages = table.Column<int>(type: "int", nullable: true),
                    Book_Author = table.Column<string>(type: "longtext", nullable: true),
                    Comic_Pages = table.Column<int>(type: "int", nullable: true),
                    Comic_Author = table.Column<string>(type: "longtext", nullable: true),
                    Manga_Pages = table.Column<int>(type: "int", nullable: true),
                    Manga_Author = table.Column<string>(type: "longtext", nullable: true),
                    Duration = table.Column<string>(type: "longtext", nullable: true),
                    Movie_Director = table.Column<string>(type: "longtext", nullable: true),
                    Pages = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "longtext", nullable: true),
                    Seasons = table.Column<int>(type: "int", nullable: true),
                    Episodes = table.Column<string>(type: "longtext", nullable: true),
                    Director = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entertainment", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    IdEntertainment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Entertainment_IdEntertainment",
                        column: x => x.IdEntertainment,
                        principalTable: "Entertainment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IdEntertainment",
                table: "Characters",
                column: "IdEntertainment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Entertainment");
        }
    }
}
