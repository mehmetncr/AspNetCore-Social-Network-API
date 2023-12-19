using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class social : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SocialMediaAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SocialMediaAccountUserId",
                table: "SocialMediaAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts");

            migrationBuilder.DropColumn(
                name: "SocialMediaAccountUserId",
                table: "SocialMediaAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SocialMediaAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
