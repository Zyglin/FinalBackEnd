using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.DataAccess
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] GenreTypes = new[] { "Action", "Drama", "Comedy", "Adventure", "Documentaly", "Horror", "Romance" };

                    modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Email = "zyglin@mail.ru",
                PasswordHash = PBKDF2Helper.CalculateHash("password")
            }
                );

            for (int i = 1; i < GenreTypes.Length+1; i++)
            {
                modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = i,
                    Name = GenreTypes[i-1],
                }
                );
            }

            modelBuilder.Entity<Film>().HasData(
             new Film
             {
                Id = Guid.NewGuid(),
                Name = "Star Wars",
                GenreId = 3,
                ImageXPath = "https://m.media-amazon.com/images/M/MV5BZWU1NDI3YjEtZTlmMy00Y2FmLWI1ZDYtMjYwNDUxYTdlODllXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                Description = "The surviving Resistance faces the First Order once more in the final chapter of the Skywalker saga.",
                YoutubeId = "Q1qZ6oLV3hg"
             },
             new Film
             {
                Id = Guid.NewGuid(),
                Name = "The Green Mile",
                GenreId = 1,
                ImageXPath = "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg",
                Description = "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.",
                YoutubeId = "CmxArNBJHFQ"
             } 
             ,
             new Film
             {
                 Id = Guid.NewGuid(),
                 Name = "The Shawshank Redemption",
                 GenreId = 1,
                 ImageXPath = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
                 Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                 YoutubeId = "6hB3S9bIaco"
             },
             new Film
             {
                 Id = Guid.NewGuid(),
                 Name = "Pulp Fiction",
                 GenreId = 1,
                 ImageXPath = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,686,1000_AL_.jpg",
                 Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                 YoutubeId = "Y6YBKdmOlM8"
             },
             new Film
             {
                 Id = Guid.NewGuid(),
                 Name = "The GodFather",
                 GenreId = 1,
                 ImageXPath = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg",
                 Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                 YoutubeId = "sY1S34973zA"
             },
             new Film
             {
                 Id = Guid.NewGuid(),
                 Name = "The Lord of the Rings",
                 GenreId = 3,
                 ImageXPath = "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,684,1000_AL_.jpg",
                 Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                 YoutubeId = "r5X-hFf6Bwo"
             }
            );    
        }
   
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
