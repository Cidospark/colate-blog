using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorlateBlog.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PostText = table.Column<string>(type: "text", nullable: false),
                    PostPhotoUrl = table.Column<string>(type: "text", nullable: false),
                    PostLikesCount = table.Column<int>(type: "integer", nullable: false),
                    CommentsReplies = table.Column<int>(type: "integer", nullable: false),
                    CommentCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategoryTbls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PostCategory = table.Column<string>(type: "text", nullable: false),
                    BlogId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategoryTbls_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    BlogId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    BlogId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplyTbls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Reply = table.Column<string>(type: "text", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    PostCommentId = table.Column<string>(type: "text", nullable: false),
                    BlogId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyTbls_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplyTbls_PostComments_PostCommentId",
                        column: x => x.PostCommentId,
                        principalTable: "PostComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryTbls_BlogId",
                table: "PostCategoryTbls",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_BlogId",
                table: "PostComments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyTbls_BlogId",
                table: "ReplyTbls",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyTbls_PostCommentId",
                table: "ReplyTbls",
                column: "PostCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogId",
                table: "Tags",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCategoryTbls");

            migrationBuilder.DropTable(
                name: "ReplyTbls");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
