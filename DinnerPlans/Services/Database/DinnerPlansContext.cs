using DinnerPlans.Models;
using Microsoft.EntityFrameworkCore;

namespace DinnerPlans.Services.Database
{
    internal class DinnerPlansContext : DbContext
    {
        public DinnerPlansContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server =.\MSSQLSERVER01; Database = DinnerPlansDB; Trusted_Connection = True; ";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasMany(rec => rec.IngredientEntries).WithOne();
            modelBuilder.Entity<IngredientEntry>().HasOne(ingEnt => ingEnt.Ingredient);
        }

        //entities
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientEntry> IngredientEntries { get; set; }
    }
}