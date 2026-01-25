using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCharactersFromBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCharacter");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CharacterId",
                table: "Books",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Characters_CharacterId",
                table: "Books",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Characters_CharacterId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CharacterId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookCharacter",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "integer", nullable: false),
                    CharactersCharacterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCharacter", x => new { x.BooksBookId, x.CharactersCharacterId });
                    table.ForeignKey(
                        name: "FK_BookCharacter_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCharacter_Characters_CharactersCharacterId",
                        column: x => x.CharactersCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCharacter_CharactersCharacterId",
                table: "BookCharacter",
                column: "CharactersCharacterId");
        }
    }
}
