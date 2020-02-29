using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class IngredientEntry
    {
        public int IngredientID { get; set; }
        public int RecipeID { get; set; }
        [Display(Name = "Quantity Needed")]
        public decimal QuantityNeeded { get; set; }

        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
