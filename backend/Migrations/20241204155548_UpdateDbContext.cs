using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCharacters_Books_BooksBookId",
                table: "BookCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCharacters_Characters_CharactersCharacterId",
                table: "BookCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCharacters",
                table: "BookCharacters");

            migrationBuilder.RenameTable(
                name: "BookCharacters",
                newName: "BookCharacter");

            migrationBuilder.RenameIndex(
                name: "IX_BookCharacters_CharactersCharacterId",
                table: "BookCharacter",
                newName: "IX_BookCharacter_CharactersCharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCharacter",
                table: "BookCharacter",
                columns: new[] { "BooksBookId", "CharactersCharacterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCharacter_Books_BooksBookId",
                table: "BookCharacter",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCharacter_Characters_CharactersCharacterId",
                table: "BookCharacter",
                column: "CharactersCharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCharacter_Books_BooksBookId",
                table: "BookCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCharacter_Characters_CharactersCharacterId",
                table: "BookCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCharacter",
                table: "BookCharacter");

            migrationBuilder.RenameTable(
                name: "BookCharacter",
                newName: "BookCharacters");

            migrationBuilder.RenameIndex(
                name: "IX_BookCharacter_CharactersCharacterId",
                table: "BookCharacters",
                newName: "IX_BookCharacters_CharactersCharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCharacters",
                table: "BookCharacters",
                columns: new[] { "BooksBookId", "CharactersCharacterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCharacters_Books_BooksBookId",
                table: "BookCharacters",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCharacters_Characters_CharactersCharacterId",
                table: "BookCharacters",
                column: "CharactersCharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
