using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev_space.Migrations
{
    public partial class mainstructuredatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFriend = table.Column<int>(type: "int", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friend_accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTag",
                columns: table => new
                {
                    AccountsId = table.Column<int>(type: "int", nullable: false),
                    tagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTag", x => new { x.AccountsId, x.tagsId });
                    table.ForeignKey(
                        name: "FK_AccountTag_accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTag_Tag_tagsId",
                        column: x => x.tagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Code_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commint_accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commint_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Img",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pathImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Img", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Img_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Like_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    tagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.tagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tag_tagsId",
                        column: x => x.tagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTag_tagsId",
                table: "AccountTag",
                column: "tagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Code_postId",
                table: "Code",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Commint_accountId",
                table: "Commint",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Commint_postId",
                table: "Commint",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_accountId",
                table: "Friend",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Img_postId",
                table: "Img",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_accountId",
                table: "Like",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_postId",
                table: "Like",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_accountId",
                table: "Link",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_IdAccount",
                table: "posts",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_tagsId",
                table: "PostTag",
                column: "tagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTag");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "Commint");

            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Img");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
