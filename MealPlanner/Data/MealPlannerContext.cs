using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Data
{
    public class MealPlannerContext : DbContext
    {
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options)
        {

        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealRecipe> MealRecipes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeEquipment> RecipeEquipment { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<IngredientEntry> IngredientEntries { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntry>().HasKey(i => new { i.IngredientID, i.RecipeID });
            modelBuilder.Entity<RecipeEquipment>().HasKey(r => new { r.EquipmentID, r.RecipeID });
            modelBuilder.Entity<MealRecipe>().HasKey(m => new { m.RecipeID, m.MealID });
        }
    }
}
