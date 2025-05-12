using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCinemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applicationUserMovies_AspNetUsers_ApplicationUserId",
                table: "applicationUserMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_applicationUserMovies_Movies_MovieId",
                table: "applicationUserMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_applicationUserMovies",
                table: "applicationUserMovies");

            migrationBuilder.RenameTable(
                name: "applicationUserMovies",
                newName: "ApplicationUserMovies");

            migrationBuilder.RenameIndex(
                name: "IX_applicationUserMovies_MovieId",
                table: "ApplicationUserMovies",
                newName: "IX_ApplicationUserMovies_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMovies",
                table: "ApplicationUserMovies",
                columns: new[] { "ApplicationUserId", "MovieId" });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("59e9653b-3c88-4456-b582-88cefe1f0c1c"), "Plovdiv", "Cinema city" },
                    { new Guid("8610db83-ba55-4065-b213-b7a3d11f3bca"), "Sofia", "Cinema city" },
                    { new Guid("fcc8ad66-e1c5-4479-8efb-52bee713c603"), "Varna", "Cinemax" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovies_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserMovies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovies_Movies_MovieId",
                table: "ApplicationUserMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovies_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovies_Movies_MovieId",
                table: "ApplicationUserMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMovies",
                table: "ApplicationUserMovies");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("59e9653b-3c88-4456-b582-88cefe1f0c1c"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("8610db83-ba55-4065-b213-b7a3d11f3bca"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("fcc8ad66-e1c5-4479-8efb-52bee713c603"));

            migrationBuilder.RenameTable(
                name: "ApplicationUserMovies",
                newName: "applicationUserMovies");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserMovies_MovieId",
                table: "applicationUserMovies",
                newName: "IX_applicationUserMovies_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicationUserMovies",
                table: "applicationUserMovies",
                columns: new[] { "ApplicationUserId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_applicationUserMovies_AspNetUsers_ApplicationUserId",
                table: "applicationUserMovies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_applicationUserMovies_Movies_MovieId",
                table: "applicationUserMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
