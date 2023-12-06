using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostType",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "YoutubeUrl",
                table: "Posts");
        }
    }
}
