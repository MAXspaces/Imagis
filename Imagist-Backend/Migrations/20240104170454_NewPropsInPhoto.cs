using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imagist_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewPropsInPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_OwingUserUserId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_OwingUserUserId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "Photos",
                newName: "MetaData_ImageWidth");

            migrationBuilder.RenameColumn(
                name: "format",
                table: "Photos",
                newName: "MetaData_ShutterSpeed");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Photos",
                newName: "MetaData_ImageHeight");

            migrationBuilder.RenameColumn(
                name: "OwingUserUserId",
                table: "Photos",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Device",
                table: "Photos",
                newName: "MetaData_Model");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Photos",
                newName: "MetaData_OriginalTime");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_OwingUserUserId",
                table: "Photos",
                newName: "IX_Photos_UserId");

            migrationBuilder.RenameColumn(
                name: "OwingUserUserId",
                table: "Albums",
                newName: "OwingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_OwingUserUserId",
                table: "Albums",
                newName: "IX_Albums_OwingUserId");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_Aperture",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_FileExtensionName",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_FileType",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_FocalLength35",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_ISO",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_Lens",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_MIMEType",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MetaData_Make",
                table: "Photos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_OwingUserId",
                table: "Albums",
                column: "OwingUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_OwingUserId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_Aperture",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_FileExtensionName",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_FileType",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_FocalLength35",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_ISO",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_Lens",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_MIMEType",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MetaData_Make",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Photos",
                newName: "OwingUserUserId");

            migrationBuilder.RenameColumn(
                name: "MetaData_ShutterSpeed",
                table: "Photos",
                newName: "format");

            migrationBuilder.RenameColumn(
                name: "MetaData_OriginalTime",
                table: "Photos",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "MetaData_Model",
                table: "Photos",
                newName: "Device");

            migrationBuilder.RenameColumn(
                name: "MetaData_ImageWidth",
                table: "Photos",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "MetaData_ImageHeight",
                table: "Photos",
                newName: "Width");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                newName: "IX_Photos_OwingUserUserId");

            migrationBuilder.RenameColumn(
                name: "OwingUserId",
                table: "Albums",
                newName: "OwingUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_OwingUserId",
                table: "Albums",
                newName: "IX_Albums_OwingUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_OwingUserUserId",
                table: "Albums",
                column: "OwingUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_OwingUserUserId",
                table: "Photos",
                column: "OwingUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
