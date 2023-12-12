using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class messadedetaisd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "MessageDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "MessageDetail");
        }
    }
}
