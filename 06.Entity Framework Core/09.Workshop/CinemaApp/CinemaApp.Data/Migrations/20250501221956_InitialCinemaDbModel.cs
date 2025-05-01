using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCinemaDbModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Cinema identifier"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Cinema name"),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Cinema location"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if cinema is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                },
                comment: "Cinemas in the system");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Movie identifier"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Movie title"),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Movie genre"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Movie release date"),
                    Director = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Movie director"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Movie duration"),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "Movie description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "Movie image url from the image store"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if movie is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                },
                comment: "Movie in the system");

            migrationBuilder.CreateTable(
                name: "applicationUserMovies",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the user"),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the movie"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if movie from user watchlist is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationUserMovies", x => new { x.ApplicationUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_applicationUserMovies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_applicationUserMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                },
                comment: "Movie watchlist for system user");

            migrationBuilder.CreateTable(
                name: "CinemaMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the movie"),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the cinema"),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false, comment: "Amount of available tickets for this movie in this cinema"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if movie in a cinema is deleted"),
                    Showtimes = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true, defaultValue: "00000", comment: "Showtimes for the movie in a cinema")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaMovies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CinemaMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                },
                comment: "Movies in a cinema with available tickets and schedule");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Ticket identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Ticket price"),
                    CinemaMovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the CinemaMovie projection entity"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the user bought the ticket")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_CinemaMovies_CinemaMovieId",
                        column: x => x.CinemaMovieId,
                        principalTable: "CinemaMovies",
                        principalColumn: "Id");
                },
                comment: "Tickets in the system");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("4cf2dd14-fde0-4a65-85ba-28fbb30ffbbd"), "Plovdiv", "Cinema city" },
                    { new Guid("868837f6-dc86-4ed1-a864-ca3bd05945c9"), "Varna", "Cinemax" },
                    { new Guid("c148d3f3-9e99-465b-ab4d-a8c458ec1cbd"), "Sofia", "Cinema city" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ImageUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("02b52bb0-1c2b-49a4-ba66-6d33f81d38d1"), "Batman faces the Joker, who seeks to create chaos in Gotham through psychological warfare.", "Christopher Nolan", 152, "Action", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("16376cc6-b3e0-4bf7-a0e4-9cbd1490522c"), "A group of explorers travel through a wormhole in space in search of a new habitable planet.", "Christopher Nolan", 169, "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_.jpg", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { new Guid("4491b6f5-2a11-4c4c-8c6b-c371f47d2152"), "The lives of two hitmen, a boxer, and a gangster intertwine in four tales of violence and redemption.", "Quentin Tarantino", 154, "Crime", "https://www.tallengestore.com/cdn/shop/products/PulpFiction-JohnTravoltaAndSamuelLJackson-MovieStill1_d3db6d19-235a-45aa-97b2-ab690665c224.jpg?v=1684129898", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("54082f99-023b-4d68-89ac-44c00a0958d0"), "The story of a man with a kind heart and an incredible life journey.", "Robert Zemeckis", 142, "Drama", "https://m.media-amazon.com/images/M/MV5BNDYwNzVjMTItZmU5YS00YjQ5LTljYjgtMjY2NDVmYWMyNWFmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { new Guid("68fb84b9-ef2a-402f-b4fc-595006f5c275"), "A thief who enters the dreams of others to steal secrets is given the inverse task: planting an idea into someone's mind.", "Christopher Nolan", 148, "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { new Guid("777634e2-3bb6-4748-8e91-7a10b70c78ac"), "The Lord of the Rings: The Fellowship of the Ring is a 2001 epic high fantasy adventure film directed by Peter Jackson from a screenplay by Fran Walsh, Philippa Boyens, and Jackson, based on 1954's The Fellowship of the Ring, the first volume of the novel The Lord of the Rings by J. R. R. Tolkien.", "Peter Jackson", 178, "Fantasy", "https://m.media-amazon.com/images/M/MV5BNzIxMDQ2YTctNDY4MC00ZTRhLTk4ODQtMTVlOWY4NTdiYmMwXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", new DateTime(2001, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Rings" },
                    { new Guid("811a1a9e-61a8-4f6f-acb0-55a252c2b713"), "A paraplegic Marine is sent to the moon Pandora on a mission but becomes torn between following orders and protecting an alien civilization.", "James Cameron", 162, "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BMDEzMmQwZjctZWU2My00MWNlLWE0NjItMDJlYTRlNGJiZjcyXkEyXkFqcGc@._V1_.jpg", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar" },
                    { new Guid("844d9abd-104d-41ab-b14a-ce059779ad91"), "A computer hacker learns about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Sci-Fi", "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_.jpg", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("ab2c3213-48a7-41ea-9393-45c60ef813e6"), "A love story unfolds on the doomed voyage of the Titanic.", "James Cameron", 195, "Romance", "https://m.media-amazon.com/images/M/MV5BYzYyN2FiZmUtYWYzMy00MzViLWJkZTMtOGY1ZjgzNWMwN2YxXkEyXkFqcGc@._V1_.jpg", new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic" },
                    { new Guid("ae50a5ab-9642-466f-b528-3cc61071bb4c"), "Harry Potter and the Goblet of Fire is a 2005 fantasy film directed by Mike Newell from a screenplay by Steve Kloves. It is based on the 2000 novel Harry Potter and the Goblet of Fire by J. K. Rowling.", "Mike Newel", 157, "Fantasy", "https://m.media-amazon.com/images/M/MV5BMTI1NDMyMjExOF5BMl5BanBnXkFtZTcwOTc4MjQzMQ@@._V1_.jpg", new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Goblet of Fire" },
                    { new Guid("bf9ff8b3-3209-4b18-9f4b-5172c45b73f9"), "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family and sent him into slavery.", "Ridley Scott", 155, "Action", "https://upload.wikimedia.org/wikipedia/en/f/fb/Gladiator_%282000_film_poster%29.png", new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiator" },
                    { new Guid("e00208b1-cb12-4bd4-8ac1-36ab62f7b4c9"), "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", 142, "Drama", "https://m.media-amazon.com/images/M/MV5BMDAyY2FhYjctNDc5OS00MDNlLThiMGUtY2UxYWVkNGY2ZjljXkEyXkFqcGc@._V1_.jpg", new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicationUserMovies_MovieId",
                table: "applicationUserMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovies_CinemaId_MovieId",
                table: "CinemaMovies",
                columns: new[] { "CinemaId", "MovieId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovies_MovieId",
                table: "CinemaMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ApplicationUserId",
                table: "Tickets",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaMovieId",
                table: "Tickets",
                column: "CinemaMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicationUserMovies");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "CinemaMovies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
