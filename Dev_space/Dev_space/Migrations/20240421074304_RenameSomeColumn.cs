using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class RenameSomeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_archives_AspNetUsers_ApplicationUser",
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
                name: "FK_likes_posts_postId",
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

            migrationBuilder.DropColumn(
                name: "IdPost",
                table: "likes");

            migrationBuilder.DropColumn(
                name: "ApplicationUser",
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
                name: "postId",
                table: "likes",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "likes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_likes_postId",
                table: "likes",
                newName: "IX_likes_PostID");

            migrationBuilder.RenameIndex(
                name: "IX_likes_ApplicationUser",
                table: "likes",
                newName: "IX_likes_UserId");

            migrationBuilder.RenameColumn(
                name: "Post",
                table: "imgs",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_imgs_Post",
                table: "imgs",
                newName: "IX_imgs_PostID");

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
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "commints",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_commints_Post",
                table: "commints",
                newName: "IX_commints_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_commints_ApplicationUser",
                table: "commints",
                newName: "IX_commints_PostID");

            migrationBuilder.RenameColumn(
                name: "Post",
                table: "codes",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_codes_Post",
                table: "codes",
                newName: "IX_codes_PostID");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "archives",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_archives_UserId",
                table: "archives",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_archives_AspNetUsers_UserId",
                table: "archives",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_codes_posts_PostID",
                table: "codes",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_commints_AspNetUsers_UserId",
                table: "commints",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_commints_posts_PostID",
                table: "commints",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imgs_posts_PostID",
                table: "imgs",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_likes_AspNetUsers_UserId",
                table: "likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_likes_posts_PostID",
                table: "likes",
                column: "PostID",
                principalTable: "posts",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_archives_AspNetUsers_UserId",
                table: "archives");

            migrationBuilder.DropForeignKey(
                name: "FK_codes_posts_PostID",
                table: "codes");

            migrationBuilder.DropForeignKey(
                name: "FK_commints_AspNetUsers_UserId",
                table: "commints");

            migrationBuilder.DropForeignKey(
                name: "FK_commints_posts_PostID",
                table: "commints");

            migrationBuilder.DropForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends");

            migrationBuilder.DropForeignKey(
                name: "FK_imgs_posts_PostID",
                table: "imgs");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_AspNetUsers_UserId",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_posts_PostID",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_links_AspNetUsers_UserId",
                table: "links");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_UserId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_archives_UserId",
                table: "archives");

            migrationBuilder.DropColumn(
                name: "UserId",
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
                name: "PostID",
                table: "likes",
                newName: "postId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "likes",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_likes_PostID",
                table: "likes",
                newName: "IX_likes_postId");

            migrationBuilder.RenameIndex(
                name: "IX_likes_UserId",
                table: "likes",
                newName: "IX_likes_ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "imgs",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_imgs_PostID",
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
                name: "UserId",
                table: "commints",
                newName: "Post");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "commints",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_commints_UserId",
                table: "commints",
                newName: "IX_commints_Post");

            migrationBuilder.RenameIndex(
                name: "IX_commints_PostID",
                table: "commints",
                newName: "IX_commints_ApplicationUser");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "codes",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_codes_PostID",
                table: "codes",
                newName: "IX_codes_Post");

            migrationBuilder.AddColumn<int>(
                name: "IdPost",
                table: "likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser",
                table: "archives",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_archives_ApplicationUser",
                table: "archives",
                column: "ApplicationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_archives_AspNetUsers_ApplicationUser",
                table: "archives",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
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
                name: "FK_likes_posts_postId",
                table: "likes",
                column: "postId",
                principalTable: "posts",
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
    }
}
