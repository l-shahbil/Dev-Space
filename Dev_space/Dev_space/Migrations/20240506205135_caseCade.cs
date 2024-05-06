using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class caseCade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_likes_posts_PostID",
                table: "likes");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "likes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_posts_PostID",
                table: "likes",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_likes_posts_PostID",
                table: "likes");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "likes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_likes_posts_PostID",
                table: "likes",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");
        }
    }
}
