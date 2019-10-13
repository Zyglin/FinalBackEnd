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
                    Filebase64 = table.Column<byte[]>(nullable: true)
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
                values: new object[] { new Guid("c1a0878f-0d0a-43fa-ab88-6e6d9a494a77"), "zyglin@mail.ru", new byte[] { 100, 97, 116, 97, 58, 105, 109, 97, 103, 101, 47, 112, 110, 103, 59, 98, 97, 115, 101, 54, 52, 44, 105, 86, 66, 79, 82, 119, 48, 75, 71, 103, 111, 65, 65, 65, 65, 78, 83, 85, 104, 69, 85, 103, 65, 65, 65, 77, 103, 65, 65, 65, 68, 73, 67, 65, 73, 65, 65, 65, 65, 105, 79, 106, 110, 74, 65, 65, 65, 65, 71, 88, 82, 70, 87, 72, 82, 84, 98, 50, 90, 48, 100, 50, 70, 121, 90, 81, 66, 66, 90, 71, 57, 105, 90, 83, 66, 74, 98, 87, 70, 110, 90, 86, 74, 108, 89, 87, 82, 53, 99, 99, 108, 108, 80, 65, 65, 65, 66, 55, 57, 74, 82, 69, 70, 85, 101, 78, 114, 115, 110, 99, 70, 76, 71, 49, 115, 85, 104, 50, 78, 52, 122, 83, 90, 90, 78, 67, 54, 48, 89, 70, 112, 73, 68, 65, 48, 87, 82, 81, 104, 73, 67, 56, 86, 70, 51, 102, 82, 118, 55, 107, 89, 88, 73, 108, 81, 69, 73, 85, 81, 115, 75, 90, 113, 65, 106, 86, 66, 100, 78, 75, 85, 107, 76, 113, 97, 98, 100, 53, 53, 53, 108, 78, 74, 113, 84, 79, 74, 77, 77, 114, 57, 122, 118, 52, 56, 105, 50, 102, 87, 101, 109, 87, 47, 79, 79, 102, 102, 79, 110, 90, 109, 70, 109, 53, 115, 102, 71, 89, 67, 52, 121, 88, 73, 73, 65, 76, 69, 65, 115, 81, 67, 120, 65, 66, 65, 76, 69, 65, 115, 81, 67, 119, 67, 120, 65, 76, 69, 65, 115, 81, 65, 81, 67, 120, 65, 76, 69, 65, 115, 65, 115, 81, 67, 120, 65, 76, 69, 65, 69, 65, 115, 81, 67, 120, 65, 76, 65, 76, 69, 65, 115, 81, 67, 120, 65, 66, 65, 76, 48, 115, 103, 47, 72, 73, 73, 55, 117, 98, 55, 43, 101, 118, 118, 51, 121, 118, 55, 50, 101, 116, 43, 105, 75, 66, 111, 77, 43, 118, 89, 55, 110, 121, 47, 107, 99, 114, 108, 105, 99, 100, 70, 43, 76, 121, 48, 116, 51, 47, 53, 57, 120, 117, 72, 54, 109, 119, 85, 101, 87, 66, 49, 105, 51, 110, 83, 55, 70, 55, 49, 101, 122, 53, 81, 97, 79, 106, 81, 43, 90, 112, 118, 112, 86, 83, 119, 87, 83, 54, 85, 88, 57, 112, 117, 68, 105, 86, 106, 47, 90, 97, 78, 79, 53, 57, 121, 85, 109, 108, 83, 109, 69, 90, 75, 90, 88, 117, 88, 121, 54, 106, 67, 114, 73, 86, 90, 119, 43, 99, 108, 56, 97, 114, 102, 80, 52, 118, 76, 112, 84, 115, 77, 113, 108, 97, 111, 90, 70, 109, 89, 79, 67, 48, 52, 115, 113, 51, 84, 116, 57, 110, 109, 110, 99, 122, 97, 122, 47, 55, 70, 99, 114, 108, 89, 113, 113, 54, 71, 49, 89, 103, 71, 74, 90, 85, 111, 49, 109, 52, 49, 104, 86, 122, 53, 55, 84, 75, 121, 78, 106, 99, 49, 119, 57, 65, 112, 67, 76, 75, 116, 51, 112, 116, 81, 115, 115, 57, 83, 73, 55, 71, 86, 54, 104, 86, 65, 99, 47, 89, 116, 49, 99, 116, 74, 111, 116, 85, 54, 106, 75, 69, 114, 74, 101, 72, 75, 53, 88, 75, 51, 50, 97, 110, 49, 57, 69, 55, 71, 69, 69, 57, 88, 43, 47, 112, 55, 78, 43, 49, 73, 52, 78, 112, 115, 122, 98, 109, 43, 47, 99, 53, 121, 54, 51, 73, 112, 108, 104, 101, 47, 52, 43, 67, 103, 57, 105, 101, 114, 79, 49, 70, 87, 118, 98, 49, 108, 120, 82, 67, 119, 90, 84, 67, 107, 114, 102, 120, 74, 68, 116, 98, 74, 111, 101, 118, 107, 55, 66, 100, 53, 117, 54, 86, 105, 75, 77, 113, 118, 83, 48, 75, 101, 80, 121, 98, 68, 47, 77, 55, 99, 115, 103, 90, 71, 120, 48, 109, 118, 86, 55, 117, 54, 72, 100, 68, 90, 86, 68, 55, 90, 99, 79, 122, 118, 118, 80, 98, 109, 86, 120, 97, 111, 48, 89, 77, 79, 50, 119, 97, 101, 53, 73, 119, 120, 88, 76, 75, 117, 65, 111, 108, 98, 57, 99, 115, 116, 67, 81, 75, 122, 85, 87, 83, 88, 85, 86, 52, 50, 101, 121, 83, 74, 87, 87, 117, 104, 50, 76, 49, 84, 109, 103, 79, 80, 48, 56, 104, 89, 79, 89, 115, 50, 102, 119, 97, 66, 47, 101, 72, 106, 103, 97, 84, 53, 108, 52, 84, 104, 111, 116, 117, 84, 70, 83, 118, 107, 113, 54, 72, 83, 122, 69, 65, 101, 88, 105, 114, 90, 89, 86, 106, 86, 56, 70, 65, 53, 47, 99, 87, 109, 76, 53, 87, 107, 97, 53, 83, 119, 48, 89, 98, 70, 115, 68, 112, 88, 99, 47, 115, 56, 48, 57, 73, 55, 83, 56, 49, 120, 104, 115, 90, 114, 78, 82, 115, 89, 49, 48, 103, 71, 113, 105, 117, 85, 55, 88, 84, 108, 73, 87, 108, 109, 117, 90, 115, 74, 69, 114, 80, 43, 90, 52, 116, 69, 47, 51, 97, 81, 49, 114, 48, 51, 54, 73, 89, 114, 86, 98, 112, 57, 110, 103, 107, 69, 48, 87, 69, 109, 120, 76, 105, 56, 118, 119, 104, 70, 76, 78, 70, 103, 57, 115, 98, 114, 100, 67, 50, 100, 76, 55, 97, 79, 120, 89, 66, 85, 88, 83, 120, 88, 70, 43, 112, 73, 74, 68, 77, 87, 81, 57, 99, 81, 75, 113, 103, 55, 113, 104, 105, 119, 109, 108, 107, 50, 82, 103, 113, 113, 68, 118, 54, 113, 104, 51, 78, 120, 81, 84, 113, 121, 114, 84, 74, 68, 73, 66, 83, 52, 109, 49, 116, 88, 86, 49, 122, 68, 70, 107, 103, 116, 99, 114, 120, 83, 71, 109, 114, 69, 81, 75, 122, 71, 107, 110, 53, 85, 73, 76, 88, 119, 108, 115, 98, 53, 47, 68, 49, 111, 115, 114, 97, 83, 108, 108, 98, 70, 54, 73, 89, 115, 49, 71, 65, 119, 81, 105, 49, 112, 65, 75, 97, 81, 85, 69, 110, 55, 73, 89, 107, 87, 51, 104, 67, 121, 87, 49, 104, 72, 73, 99, 114, 50, 83, 116, 69, 76, 80, 87, 73, 104, 70, 120, 107, 114, 105, 89, 117, 48, 104, 108, 116, 66, 66, 52, 67, 78, 78, 69, 76, 90, 89, 103, 97, 56, 49, 121, 66, 48, 69, 101, 105, 120, 54, 76, 69, 111, 104, 85, 65, 112, 106, 53, 43, 100, 80, 77, 112, 98, 83, 81, 97, 68, 72, 111, 115, 101, 105, 70, 65, 75, 108, 69, 66, 65, 76, 65, 76, 69, 65, 115, 81, 67, 120, 65, 66, 65, 76, 69, 65, 115, 81, 67, 119, 67, 120, 65, 76, 72, 105, 111, 108, 104, 99, 53, 71, 119, 116, 76, 84, 49, 68, 114, 74, 104, 53, 56, 105, 83, 72, 87, 71, 81, 115, 81, 67, 119, 82, 110, 72, 48, 121, 101, 84, 114, 121, 43, 81, 74, 105, 48, 87, 80, 70, 84, 54, 71, 65, 87, 69, 65, 112, 108, 79, 68, 112, 48, 121, 74, 110, 97, 50, 108, 112, 71, 98, 72, 111, 115, 99, 104, 89, 71, 104, 109, 76, 72, 107, 118, 112, 73, 74, 67, 120, 108, 66, 65, 54, 67, 69, 114, 78, 101, 43, 65, 84, 81, 54, 51, 119, 108, 99, 81, 75, 102, 80, 70, 100, 75, 51, 119, 108, 115, 90, 97, 88, 110, 52, 85, 115, 108, 108, 98, 52, 83, 109, 76, 108, 56, 47, 109, 81, 120, 100, 73, 75, 88, 48, 117, 115, 81, 116, 104, 105, 70, 82, 65, 114, 69, 89, 81, 50, 106, 82, 67, 43, 50, 67, 50, 100, 89, 67, 101, 71, 99, 111, 71, 76, 105, 82, 88, 115, 77, 113, 108, 99, 52, 72, 73, 90, 75, 57, 65, 55, 104, 110, 75, 66, 105, 52, 107, 86, 98, 74, 115, 108, 70, 55, 104, 101, 106, 120, 88, 103, 118, 82, 48, 76, 109, 82, 54, 76, 97, 53, 101, 81, 86, 99, 86, 97, 68, 107, 43, 115, 90, 99, 84, 105, 56, 105, 86, 107, 84, 98, 71, 115, 50, 119, 104, 113, 67, 100, 54, 67, 86, 86, 121, 57, 107, 57, 122, 122, 88, 105, 113, 57, 67, 69, 99, 115, 48, 87, 65, 108, 120, 81, 113, 113, 122, 82, 73, 78, 86, 106, 86, 106, 66, 98, 76, 111, 89, 71, 71, 83, 115, 87, 98, 75, 121, 107, 111, 81, 49, 86, 65, 51, 84, 70, 87, 120, 75, 112, 88, 86, 69, 77, 84, 83, 68, 86, 78, 86, 76, 74, 117, 66, 117, 53, 56, 98, 87, 111, 67, 54, 97, 121, 116, 90, 53, 97, 117, 53, 54, 106, 49, 100, 67, 81, 99, 111, 76, 70, 97, 53, 55, 76, 119, 97, 83, 103, 99, 111, 76, 74, 90, 86, 67, 115, 99, 76, 87, 104, 97, 97, 100, 75, 51, 88, 102, 105, 108, 73, 114, 98, 98, 109, 86, 83, 122, 49, 48, 76, 84, 70, 56, 116, 114, 67, 83, 55, 102, 116, 72, 115, 81, 121, 78, 106, 89, 50, 47, 89, 110, 108, 73, 67, 104, 53, 115, 99, 114, 108, 113, 114, 79, 107, 90, 101, 70, 89, 85, 73, 106, 70, 57, 85, 48, 52, 84, 115, 88, 121, 108, 76, 82, 56, 112, 75, 117, 77, 109, 49, 100, 70, 117, 107, 108, 97, 98, 103, 74, 120, 73, 112, 97, 80, 112, 79, 85, 109, 88, 87, 85, 56, 118, 100, 122, 87, 119, 98, 88, 117, 113, 86, 110, 48, 73, 53, 90, 54, 48, 118, 75, 85, 114, 106, 76, 79, 88, 115, 99, 116, 102, 99, 85, 55, 109, 57, 117, 54, 69, 107, 115, 51, 97, 82, 87, 76, 105, 53, 55, 83, 86, 99, 98, 102, 66, 119, 82, 69, 114, 47, 116, 54, 102, 99, 118, 90, 105, 102, 65, 109, 108, 109, 76, 83, 99, 110, 66, 110, 48, 76, 57, 89, 105, 107, 110, 76, 53, 101, 49, 79, 104, 50, 75, 116, 114, 67, 103, 57, 119, 50, 78, 68, 100, 100, 90, 100, 117, 82, 88, 76, 84, 112, 88, 81, 119, 121, 48, 117, 114, 99, 112, 52, 47, 102, 112, 88, 113, 102, 83, 99, 111, 83, 74, 87, 47, 65, 106, 49, 119, 108, 55, 102, 99, 101, 74, 84, 76, 75, 117, 71, 69, 110, 78, 68, 120, 43, 47, 113, 100, 102, 115, 104, 84, 65, 109, 120, 72, 72, 47, 69, 66, 98, 72, 73, 87, 73, 103, 49, 67, 82, 75, 102, 84, 51, 98, 56, 97, 104, 79, 43, 67, 81, 50, 73, 66, 89, 103, 70, 105, 65, 87, 65, 87, 73, 66, 89, 103, 70, 103, 65, 105, 65, 87, 73, 66, 89, 106, 108, 106, 88, 54, 47, 122, 121, 65, 82, 75, 51, 52, 71, 103, 122, 54, 68, 82, 67, 122, 69, 81, 105, 119, 70, 111, 105, 104, 83, 69, 99, 117, 71, 105, 108, 103, 121, 88, 70, 57, 47, 90, 97, 105, 73, 108, 99, 84, 90, 117, 109, 75, 111, 105, 66, 85, 47, 51, 101, 52, 70, 81, 48, 87, 115, 43, 69, 43, 86, 85, 70, 78, 115, 81, 51, 88, 112, 108, 107, 79, 120, 87, 113, 49, 80, 68, 66, 105, 120, 52, 117, 43, 70, 53, 100, 112, 104, 120, 84, 71, 72, 74, 90, 90, 78, 51, 84, 57, 43, 80, 70, 65, 99, 117, 81, 51, 98, 50, 98, 113, 68, 75, 55, 71, 79, 106, 52, 57, 69, 108, 120, 120, 116, 50, 68, 90, 52, 120, 69, 111, 106, 110, 99, 54, 90, 47, 87, 80, 56, 105, 66, 88, 122, 87, 82, 69, 116, 103, 110, 56, 85, 82, 68, 100, 117, 101, 82, 67, 114, 49, 84, 112, 49, 89, 78, 85, 118, 116, 121, 119, 99, 66, 52, 69, 115, 51, 78, 122, 56, 107, 79, 55, 87, 68, 119, 56, 80, 47, 75, 48, 68, 108, 85, 111, 118, 88, 114, 57, 43, 75, 47, 48, 52, 113, 55, 66, 89, 78, 107, 87, 51, 54, 57, 118, 114, 66, 111, 70, 56, 118, 118, 68, 109, 122, 86, 118, 100, 100, 57, 70, 73, 105, 106, 87, 99, 81, 51, 109, 57, 71, 102, 74, 72, 54, 113, 114, 88, 116, 120, 82, 102, 66, 83, 48, 109, 108, 105, 110, 86, 98, 68, 89, 56, 122, 90, 55, 71, 111, 86, 121, 117, 98, 109, 120, 115, 97, 117, 107, 108, 73, 49, 97, 89, 83, 117, 110, 113, 74, 83, 67, 87, 108, 98, 120, 87, 54, 53, 80, 88, 102, 85, 117, 84, 89, 108, 49, 88, 114, 98, 97, 87, 47, 113, 43, 115, 112, 49, 99, 115, 83, 49, 71, 100, 122, 110, 109, 55, 102, 101, 90, 52, 47, 43, 53, 106, 87, 118, 116, 75, 112, 86, 111, 117, 114, 54, 89, 50, 103, 97, 86, 79, 114, 67, 105, 75, 76, 105, 56, 118, 117, 116, 48, 118, 73, 102, 84, 109, 115, 88, 84, 51, 112, 100, 76, 122, 70, 76, 54, 66, 80, 69, 86, 105, 109, 85, 110, 109, 107, 49, 110, 108, 100, 82, 116, 52, 99, 103, 122, 102, 81, 71, 54, 71, 112, 97, 100, 69, 122, 108, 43, 115, 88, 117, 43, 98, 108, 84, 121, 116, 51, 88, 108, 112, 76, 112, 72, 109, 108, 112, 88, 73, 117, 98, 43, 69, 99, 109, 53, 105, 68, 88, 100, 79, 87, 108, 101, 79, 84, 119, 107, 90, 78, 117, 122, 120, 53, 57, 87, 69, 122, 86, 113, 115, 89, 81, 118, 86, 98, 112, 56, 122, 121, 53, 118, 90, 76, 76, 74, 83, 87, 90, 49, 57, 69, 122, 89, 55, 115, 97, 122, 107, 87, 88, 54, 105, 104, 90, 112, 106, 69, 50, 89, 53, 98, 71, 89, 108, 99, 104, 90, 105, 100, 84, 112, 110, 112, 75, 104, 85, 74, 98, 65, 90, 102, 77, 65, 110, 81, 98, 69, 115, 77, 51, 51, 43, 47, 73, 109, 70, 113, 72, 82, 50, 89, 74, 86, 75, 57, 101, 88, 76, 116, 101, 84, 113, 89, 121, 74, 105, 68, 90, 86, 113, 116, 85, 54, 112, 101, 105, 109, 118, 106, 55, 88, 97, 113, 52, 84, 48, 105, 108, 107, 115, 108, 69, 75, 118, 43, 77, 87, 121, 88, 117, 114, 52, 43, 65, 105, 108, 82, 80, 87, 113, 49, 55, 100, 105, 55, 76, 51, 105, 69, 99, 115, 97, 99, 49, 80, 75, 53, 110, 50, 99, 73, 87, 108, 115, 122, 109, 104, 54, 120, 98, 75, 55, 56, 76, 70, 105, 87, 88, 52, 54, 79, 87, 110, 52, 50, 75, 89, 78, 81, 54, 119, 121, 114, 113, 57, 118, 80, 114, 73, 121, 80, 107, 111, 115, 51, 53, 117, 68, 65, 53, 56, 50, 80, 110, 74, 106, 57, 80, 82, 105, 87, 101, 48, 106, 85, 98, 108, 80, 88, 86, 89, 90, 90, 121, 101, 87, 112, 97, 106, 57, 47, 84, 48, 54, 113, 107, 67, 54, 114, 117, 51, 116, 100, 49, 80, 99, 99, 74, 120, 89, 76, 80, 78, 112, 100, 47, 99, 68, 85, 55, 43, 103, 74, 111, 119, 55, 79, 43, 56, 110, 118, 82, 99, 48, 109, 86, 103, 43, 72, 106, 105, 71, 75, 98, 67, 87, 97, 54, 76, 70, 105, 67, 120, 87, 119, 84, 104, 77, 43, 118, 104, 47, 70, 113, 115, 103, 67, 98, 101, 121, 87, 65, 86, 74, 117, 80, 87, 119, 87, 78, 97, 116, 89, 120, 88, 56, 55, 116, 89, 52, 67, 119, 73, 80, 105, 71, 87, 122, 80, 53, 115, 68, 99, 106, 84, 104, 100, 56, 90, 90, 70, 110, 104, 65, 114, 80, 51, 57, 80, 86, 89, 87, 52, 79, 57, 48, 89, 50, 74, 77, 76, 49, 97, 114, 100, 99, 113, 50, 84, 55, 103, 84, 69, 50, 80, 48, 102, 90, 100, 55, 120, 82, 111, 77, 43, 105, 99, 110, 68, 89, 52, 103, 51, 73, 102, 112, 77, 101, 73, 50, 56, 98, 49, 105, 78, 90, 115, 78, 105, 105, 67, 77, 76, 111, 103, 109, 121, 87, 82, 105, 51, 98, 52, 51, 52, 89, 120, 106, 66, 54, 77, 120, 83, 101, 53, 76, 87, 118, 56, 75, 77, 65, 67, 66, 120, 80, 50, 104, 68, 73, 97, 109, 80, 103, 65, 65, 65, 65, 66, 74, 82, 85, 53, 69, 114, 107, 74, 103, 103, 103, 61, 61 }, "Zyglin Artem Pavlovich", "15000|JsoHFJChDDP7PkmW|xZ1fABcgr2REfrz5iFBkD0Z794gchllvXJ9N3BIqN/Q=", "+375291641585" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "GenreId", "ImageXPath", "Name", "YoutubeId" },
                values: new object[,]
                {
                    { new Guid("e504f122-50dc-45dc-b0ac-fe90c62a0d9d"), "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.", 1, "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg", "The Green Mile", "CmxArNBJHFQ" },
                    { new Guid("d00967f4-fe1e-44dc-9bb3-0ae15746aea4"), "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", 1, "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", "The Shawshank Redemption", "6hB3S9bIaco" },
                    { new Guid("fa128317-1ea5-4288-bb41-cba62079f3ab"), "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 1, "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,686,1000_AL_.jpg", "Pulp Fiction", "Y6YBKdmOlM8" },
                    { new Guid("7d3a6e37-09ac-4aa6-9dee-74e023e275ad"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 1, "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg", "The GodFather", "sY1S34973zA" },
                    { new Guid("4a445bed-7c81-4503-a988-9f5ffa145807"), "The surviving Resistance faces the First Order once more in the final chapter of the Skywalker saga.", 3, "https://m.media-amazon.com/images/M/MV5BZWU1NDI3YjEtZTlmMy00Y2FmLWI1ZDYtMjYwNDUxYTdlODllXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_SY1000_CR0,0,675,1000_AL_.jpg", "Star Wars", "Q1qZ6oLV3hg" },
                    { new Guid("81b9b9cb-551e-4fd9-99bf-53938f301d7f"), "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", 3, "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,684,1000_AL_.jpg", "The Lord of the Rings", "r5X-hFf6Bwo" }
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
