using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<RecipeEquipment> RecipeEquipments { get; set; }
        public ICollection<IngredientEntry> IngredientEntries { get; set; }
        public ICollection<MealRecipe> MealRecipes { get; set; }
    }
}
