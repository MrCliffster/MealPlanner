using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class RecipeEquipment
    {
        public int EquipmentID { get; set; }
        public int RecipeID { get; set; }
        public Equipment Equipment { get; set; }
        public Recipe Recipe { get; set; }
    }
}
