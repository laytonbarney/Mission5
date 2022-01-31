using System;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieInfoContext : DbContext
    {
        public MovieInfoContext (DbContextOptions<MovieInfoContext> options) : base (options)
        {
            //Leave Blank for now
        }

        //This sets the name of the tables
        public DbSet<MovieDB> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        //This is how the database is initaially seeded
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Fantasy" },
                new Category { CategoryId = 5, CategoryName = "Horror" },
                new Category { CategoryId = 6, CategoryName = "Mystery" },
                new Category { CategoryId = 7, CategoryName = "Romance" },
                new Category { CategoryId = 8, CategoryName = "Thriller" },
                new Category { CategoryId = 9, CategoryName= "Western" }
                );


            mb.Entity<MovieDB>().HasData(
                new MovieDB
                {
                    MovieId = 1,
                    CategoryId = 3,
                    Title = "Schindler's List",
                    Year = 1993,
                    DirectorName = "Steven Spielberg",
                    Rating = "R",
                    Edited = false

                },
                new MovieDB
                {
                    MovieId = 2,
                    CategoryId = 3,
                    Title = "Inception",
                    Year = 2010,
                    DirectorName = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                },
                new MovieDB
                {
                    MovieId = 3,
                    CategoryId = 3,
                    Title = "It's a Wonderful Life",
                    Year = 1946,
                    DirectorName = "Frank Capra",
                    Rating = "PG",
                    Edited = false
                }
                );
        }
    }
}
