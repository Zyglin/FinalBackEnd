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
                    FullName = table.Column<string>(maxLength: 85, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 85, nullable: false),
                    Filebase64 = table.Column<string>(nullable: true)
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
                columns: new[] { "Id", "Email", "Filebase64", "FullName", "PasswordHash", "PhoneNumber" },
                values: new object[] { new Guid("5a6ad620-4e5b-4aab-9e23-234037b040ed"), "zyglin@mail.ru", "data:image/png;base64,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", "Zyglin Artem Pavlovich", "15000|KQ3CUj7nXKlScD0I|MaQvusdzu2a63sF+AhaniFO4X7wHYxPo8qQKRNjWNbo=", "+375291641585" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "GenreId", "ImageXPath", "Name", "YoutubeId" },
                values: new object[,]
                {
                    { new Guid("d48c20c2-7d7e-4123-bf0c-e5e5fa8fb3b0"), "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.", 1, "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg", "The Green Mile", "CmxArNBJHFQ" },
                    { new Guid("182c5588-c842-4435-ae7e-195738a73613"), "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", 1, "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", "The Shawshank Redemption", "6hB3S9bIaco" },
                    { new Guid("9991d39f-07d8-49b7-8809-619dce615c00"), "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 1, "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,686,1000_AL_.jpg", "Pulp Fiction", "Y6YBKdmOlM8" },
                    { new Guid("dcee2615-8371-4260-bb31-6e91b02a4c2a"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 1, "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg", "The GodFather", "sY1S34973zA" },
                    { new Guid("a777fa4d-25d4-40a8-b54f-f0176505b44c"), "The surviving Resistance faces the First Order once more in the final chapter of the Skywalker saga.", 3, "https://m.media-amazon.com/images/M/MV5BZWU1NDI3YjEtZTlmMy00Y2FmLWI1ZDYtMjYwNDUxYTdlODllXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_SY1000_CR0,0,675,1000_AL_.jpg", "Star Wars", "Q1qZ6oLV3hg" },
                    { new Guid("055588b2-3185-4c2d-8158-f78518470ab7"), "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", 3, "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,684,1000_AL_.jpg", "The Lord of the Rings", "r5X-hFf6Bwo" }
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
