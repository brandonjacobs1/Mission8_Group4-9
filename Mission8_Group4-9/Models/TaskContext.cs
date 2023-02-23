using Microsoft.EntityFrameworkCore;
using Mission8_Group4_9.Models;
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

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        //seeding
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Home"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "School"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Work"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Church"
                }
                );
            mb.Entity<Tasks>().HasData(
                new Tasks
                {
                    TaskID = 1,
                    TaskName = "test",
                    DueDate = DateTime.Now,
                    Quadrant = 1,
                    CategoryID = 1,
                    Completed = false
                });
        }
    }
}

