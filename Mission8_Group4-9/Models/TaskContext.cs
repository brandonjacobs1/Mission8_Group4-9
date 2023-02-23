using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIssion6_jacobs27.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        //seeding
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "VHS"
                },
                new Category
                {
                    CategoryID = 9,
                    CategoryName = "Other"
                });
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieID = 2,
                    Title = "Starwars: Episode 2 - Attack of the Clones",
                    Year = "2002",
                    CategoryID = 1,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Brandon Jacobs",
                    Notes = "No Notes"
                },
                new Movie
                {
                    MovieID = 1,
                    Title = "Starwars: Episode 1 - The Phantom Menace",
                    Year = "1999",
                    CategoryID = 1,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Brandon Jacobs",
                    Notes = "No Notes"
                },
                new Movie
                {
                    MovieID = 3,
                    Title = "Starwars: Episode 3 - Revenge of the Sith",
                    Year = "2005",
                    CategoryID = 1,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Brandon Jacobs",
                    Notes = "No Notes"
                });
        }
    }
}

