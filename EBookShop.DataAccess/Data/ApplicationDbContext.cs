
using EBookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EBookShop.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //whatever option that are passed to option is passsed to base class of dbcontext
        {

        }

        //Creates aproperty of generic DbSet Category class type
        //which creates a table
        //TO ADD TABLE TO DATABASE USE [ ADD-MIGRATION, MEANING FUL NAME] COMMAND IN NUGET PACKAGE MANAGER TERMINAL
        //nOW ENTER UPDATE-DATABASE TO APPLY THE MIGRATION TO THE DATABASE WHICH WILL ADD THE THE TABLE
        public DbSet<Category> Categories { get; set; }

        //OnModelCreating a default method that ENtiyframework uses
        //This inserts data to a tabase
        //AGAIN THIS IS A MIGRATION USE [ADD MIGRATION] and UPDATE DATABASE
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Inserts the data in the table
            //ModelBuild has a Generica Entity Method which has a HasData function that takes array of category class
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
        }
}
