using MealPlanner.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace MealPlanner.Models.PlannerViewModels
{
    public class IngredientCategoryNamePageModel : PageModel
    {
        public SelectList IngredientNameSL { get; set; }

        public void PopulateIngredientCategories(MealPlannerContext _context, object selectedCategory = null)
        {
            var categoryQuery = from c in _context.IngredientCategories
                                orderby c.Name
                                select c;

            IngredientNameSL = new SelectList(categoryQuery, "IngredientCategoryID", "Name", selectedCategory);
        }
    }
}
