using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imagist_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityAddattribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profileId",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profileId",
                table: "Users");
        }
    }
}
