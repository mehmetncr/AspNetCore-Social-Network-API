using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adduseremail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Users");
        }
    }
}
