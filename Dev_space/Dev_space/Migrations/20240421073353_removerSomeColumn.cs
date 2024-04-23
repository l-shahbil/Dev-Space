using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class removerSomeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_codes_posts_postId",
                table: "codes");

            migrationBuilder.DropForeignKey(
                name: "FK_commints_AspNetUsers_UserId",
                table: "commints");

            migrationBuilder.DropForeignKey(
                name: "FK_commints_posts_postId",
                table: "commints");

            migrationBuilder.DropForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends");

            migrationBuilder.DropForeignKey(
                name: "FK_imgs_posts_postId",
                table: "imgs");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_AspNetUsers_UserId",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_links_AspNetUsers_UserId",
                table: "links");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_UserId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "links");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "likes");

            migrationBuilder.DropColumn(
                name: "IdPost",
                table: "imgs");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "friends");

            migrationBuilder.DropColumn(
                name: "IdPost",
                table: "commints");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "commints");

            migrationBuilder.DropColumn(
                name: "IdPost",
                table: "codes");

            migrationBuilder.DropColumn(
                name: "IdPost",
                table: "archives");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "archives");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "posts",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_posts_UserId",
                table: "posts",
                newName: "IX_posts_ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "links",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_links_UserId",
                table: "links",
                newName: "IX_links_ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "likes",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_likes_UserId",
                table: "likes",
                newName: "IX_likes_ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "imgs",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_imgs_postId",
                table: "imgs",
                newName: "IX_imgs_Post");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "friends",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_friends_UserId",
                table: "friends",
                newName: "IX_friends_ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "commints",
                newName: "Post");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "commints",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_commints_UserId",
                table: "commints",
                newName: "IX_commints_ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_commints_postId",
                table: "commints",
                newName: "IX_commints_Post");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "codes",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_codes_postId",
                table: "codes",
                newName: "IX_codes_Post");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser",
                table: "archives",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostID",
                table: "archives",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_archives_ApplicationUser",
                table: "archives",
                column: "ApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_archives_PostID",
                table: "archives",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_archives_AspNetUsers_ApplicationUser",
                table: "archives",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_archives_posts_PostID",
                table: "archives",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_codes_posts_Post",
                table: "codes",
                column: "Post",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_commints_AspNetUsers_ApplicationUser",
                table: "commints",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_commints_posts_Post",
                table: "commints",
                column: "Post",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_friends_AspNetUsers_ApplicationUser",
                table: "friends",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imgs_posts_Post",
                table: "imgs",
                column: "Post",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_likes_AspNetUsers_ApplicationUser",
                table: "likes",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_links_AspNetUsers_ApplicationUser",
                table: "links",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_ApplicationUser",
                table: "posts",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_archives_AspNetUsers_ApplicationUser",
                table: "archives");

            migrationBuilder.DropForeignKey(
                name: "FK_archives_posts_PostID",
                table: "archives");

            migrationBuilder.DropForeignKey(
                name: "FK_codes_posts_Post",
                table: "codes");

            migrationBuilder.DropForeignKey(
                name: "FK_commints_AspNetUsers_ApplicationUser",
                table: "commints");

            migrationBuilder.DropForeignKey(
                name: "FK_commints_posts_Post",
                table: "commints");

            migrationBuilder.DropForeignKey(
                name: "FK_friends_AspNetUsers_ApplicationUser",
                table: "friends");

            migrationBuilder.DropForeignKey(
                name: "FK_imgs_posts_Post",
                table: "imgs");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_AspNetUsers_ApplicationUser",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_links_AspNetUsers_ApplicationUser",
                table: "links");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_ApplicationUser",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_archives_ApplicationUser",
                table: "archives");

            migrationBuilder.DropIndex(
                name: "IX_archives_PostID",
                table: "archives");

            migrationBuilder.DropColumn(
                name: "ApplicationUser",
                table: "archives");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "archives");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_ApplicationUser",
                table: "posts",
                newName: "IX_posts_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "links",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_links_ApplicationUser",
                table: "links",
                newName: "IX_links_UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "likes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_likes_ApplicationUser",
                table: "likes",
                newName: "IX_likes_UserId");

            migrationBuilder.RenameColumn(
                name: "Post",
                table: "imgs",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_imgs_Post",
                table: "imgs",
                newName: "IX_imgs_postId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "friends",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_friends_ApplicationUser",
                table: "friends",
                newName: "IX_friends_UserId");

            migrationBuilder.RenameColumn(
                name: "Post",
                table: "commints",
                newName: "postId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "commints",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_commints_Post",
                table: "commints",
                newName: "IX_commints_postId");

            migrationBuilder.RenameIndex(
                name: "IX_commints_ApplicationUser",
                table: "commints",
                newName: "IX_commints_UserId");

            migrationBuilder.RenameColumn(
                name: "Post",
                table: "codes",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_codes_Post",
                table: "codes",
                newName: "IX_codes_postId");

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "likes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdPost",
                table: "imgs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "friends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdPost",
                table: "commints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "commints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdPost",
                table: "codes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdPost",
                table: "archives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "archives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_codes_posts_postId",
                table: "codes",
                column: "postId",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_commints_AspNetUsers_UserId",
                table: "commints",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_commints_posts_postId",
                table: "commints",
                column: "postId",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imgs_posts_postId",
                table: "imgs",
                column: "postId",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_likes_AspNetUsers_UserId",
                table: "likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_links_AspNetUsers_UserId",
                table: "links",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_UserId",
                table: "posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
