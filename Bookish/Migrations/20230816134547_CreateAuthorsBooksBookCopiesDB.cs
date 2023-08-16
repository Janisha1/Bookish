using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookish.Migrations
{
    /// <inheritdoc />
    public partial class CreateAuthorsBooksBookCopiesDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    YearOfBirth = table.Column<int>(type: "integer", nullable: true),
                    AuthorPhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CoverPhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Blurb = table.Column<string>(type: "text", nullable: true),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    YearPublished = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Isbn);
                });

            migrationBuilder.CreateTable(
                name: "AuthorModelBookModel",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "integer", nullable: false),
                    BooksIsbn = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModelBookModel", x => new { x.AuthorsId, x.BooksIsbn });
                    table.ForeignKey(
                        name: "FK_AuthorModelBookModel_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorModelBookModel_Books_BooksIsbn",
                        column: x => x.BooksIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    BookIsbn = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModelBookModel_BooksIsbn",
                table: "AuthorModelBookModel",
                column: "BooksIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookIsbn",
                table: "BookCopies",
                column: "BookIsbn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorModelBookModel");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
