using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class archiveFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_archives_posts_PostID",
                table: "archives");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "archives",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateAdded",
                table: "archives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_archives_posts_PostID",
                table: "archives",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_archives_posts_PostID",
                table: "archives");

            migrationBuilder.DropColumn(
                name: "dateAdded",
                table: "archives");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "archives",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_archives_posts_PostID",
                table: "archives",
                column: "PostID",
                principalTable: "posts",
                principalColumn: "Id");
        }
    }
}
