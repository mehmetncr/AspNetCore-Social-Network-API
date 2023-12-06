using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class postt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "ReplyComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComments_PostId",
                table: "ReplyComments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_Posts_PostId",
                table: "ReplyComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_Posts_PostId",
                table: "ReplyComments");

            migrationBuilder.DropIndex(
                name: "IX_ReplyComments_PostId",
                table: "ReplyComments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "ReplyComments");
        }
    }
}
