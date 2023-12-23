using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "NotificationSenderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_NotificationSenderUserId");

            migrationBuilder.AddColumn<bool>(
                name: "NotificationIsSeen",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NotificationOwnerUserId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_NotificationSenderUserId",
                table: "Notifications",
                column: "NotificationSenderUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_NotificationSenderUserId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationIsSeen",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationOwnerUserId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "NotificationSenderUserId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_NotificationSenderUserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
