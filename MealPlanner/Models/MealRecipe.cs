using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class MealRecipe
    {
        public int MealID { get; set; }
        public int RecipeID { get; set; }
        public Meal Meal { get; set; }
        public Recipe Recipe { get; set; }
    }
}
