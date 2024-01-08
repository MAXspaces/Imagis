using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imagist_Backend.Migrations
{
    /// <inheritdoc />
    public partial class PhotoEntityAddattribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailObjectId",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailObjectId",
                table: "Photos");
        }
    }
}
