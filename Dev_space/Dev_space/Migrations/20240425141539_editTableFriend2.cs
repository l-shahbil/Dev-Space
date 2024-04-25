using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class editTableFriend2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "friends",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "friends",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFollow",
                table: "friends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdFriend",
                table: "friends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends");

            migrationBuilder.DropColumn(
                name: "DateFollow",
                table: "friends");

            migrationBuilder.DropColumn(
                name: "IdFriend",
                table: "friends");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "friends",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "friends",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_friends_AspNetUsers_UserId",
                table: "friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
