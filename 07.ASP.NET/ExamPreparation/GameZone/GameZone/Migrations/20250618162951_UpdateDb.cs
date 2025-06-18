using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames",
                column: "GamerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames",
                column: "GamerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
