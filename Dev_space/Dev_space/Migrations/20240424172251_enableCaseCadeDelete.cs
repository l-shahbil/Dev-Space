using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class enableCaseCadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_codes_posts_PostID",
                table: "codes");

            migrationBuilder.DropForeignKey(
                name: "FK_imgs_posts_PostID",
                table: "imgs");

            migrationBuilder.DropForeignKey(
                name: "FK_links_AspNetUsers_UserId",
                table: "links");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "links",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pathImg",
                table: "imgs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "imgs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "codes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_codes_posts_PostID",
                table: "codes",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_imgs_posts_PostID",
                table: "imgs",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_links_AspNetUsers_UserId",
                table: "links",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_codes_posts_PostID",
                table: "codes");

            migrationBuilder.DropForeignKey(
                name: "FK_imgs_posts_PostID",
                table: "imgs");

            migrationBuilder.DropForeignKey(
                name: "FK_links_AspNetUsers_UserId",
                table: "links");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "links",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "pathImg",
                table: "imgs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "imgs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "codes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_codes_posts_PostID",
                table: "codes",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imgs_posts_PostID",
                table: "imgs",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_links_AspNetUsers_UserId",
                table: "links",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
