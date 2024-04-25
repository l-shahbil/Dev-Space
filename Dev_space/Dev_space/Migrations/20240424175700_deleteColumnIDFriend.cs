using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class deleteColumnIDFriend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFriend",
                table: "friends");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdFriend",
                table: "friends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
