using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Entertainment",
                newName: "ImageFile");

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "Entertainment",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Entertainment",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Entertainment");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Entertainment");

            migrationBuilder.RenameColumn(
                name: "ImageFile",
                table: "Entertainment",
                newName: "Image");
        }
    }
}
