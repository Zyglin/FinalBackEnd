using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 85, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 85, nullable: false),
                    Email = table.Column<string>(maxLength: 85, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 85, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 85, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    YoutubeId = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: false),
                    ImageXPath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 160, nullable: false),
                    FilmId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    FilmId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Comedy" },
                    { 4, "Adventure" },
                    { 5, "Documentaly" },
                    { 6, "Horror" },
                    { 7, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash" },
                values: new object[] { new Guid("b5d8ca58-9a43-483f-b335-bfa35f220bc7"), "zyglin@mail.ru", "15000|1KCtkVnuuQyjfCTS|GSKMUwFtkcsyzri0KM+QhVWexTZx3XTIu7FvlhWvg7Y=" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "GenreId", "ImageXPath", "Name", "YoutubeId" },
                values: new object[,]
                {
                    { new Guid("cc51a9e2-3e0b-45ea-b0f1-7b557dc04da3"), "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.", 1, "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg", "The Green Mile", "CmxArNBJHFQ" },
                    { new Guid("79133b5b-abf2-4d88-86aa-1065e430716e"), "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", 1, "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", "The Shawshank Redemption", "6hB3S9bIaco" },
                    { new Guid("be44635a-ec22-4f43-93ab-3c0809855a28"), "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 1, "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,686,1000_AL_.jpg", "Pulp Fiction", "Y6YBKdmOlM8" },
                    { new Guid("cb821af7-a7f3-4949-a1e9-0ac3d483e316"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 1, "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg", "The GodFather", "sY1S34973zA" },
                    { new Guid("9579ad12-3439-435a-9673-9b82e41b2de0"), "The surviving Resistance faces the First Order once more in the final chapter of the Skywalker saga.", 3, "https://m.media-amazon.com/images/M/MV5BZWU1NDI3YjEtZTlmMy00Y2FmLWI1ZDYtMjYwNDUxYTdlODllXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_SY1000_CR0,0,675,1000_AL_.jpg", "Star Wars", "Q1qZ6oLV3hg" },
                    { new Guid("a70e815f-f4c0-4cac-b2f7-a50f1c180e1f"), "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", 3, "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,684,1000_AL_.jpg", "The Lord of the Rings", "r5X-hFf6Bwo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FilmId",
                table: "Comments",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FilmId",
                table: "Ratings",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
