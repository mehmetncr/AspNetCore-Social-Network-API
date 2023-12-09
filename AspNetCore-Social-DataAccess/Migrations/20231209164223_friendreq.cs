using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class friendreq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendRequest",
                columns: table => new
                {
                    FriendReqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendReqCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FriendReqStatus = table.Column<bool>(type: "bit", nullable: false),
                    FriendReqUserId = table.Column<int>(type: "int", nullable: false),
                    FriendReqFriendReqSenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.FriendReqId);
                    table.ForeignKey(
                        name: "FK_FriendRequest_Users_FriendReqFriendReqSenderId",
                        column: x => x.FriendReqFriendReqSenderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_FriendReqFriendReqSenderId",
                table: "FriendRequest",
                column: "FriendReqFriendReqSenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequest");
        }
    }
}
