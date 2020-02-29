using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public enum MealType
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack,
        General
    }

    public class Meal
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public MealType MealType { get; set; }
        public DayOfWeek Day { get; set; }
        
        public Menu Menu { get; set; }
        public ICollection<MealRecipe> MealRecipes { get; set; }
    }
}
