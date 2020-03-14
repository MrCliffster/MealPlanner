using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlanner.Pages.IngredientCategories
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public DetailsModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IngredientCategory IngredientCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IngredientCategory = await _context.IngredientCategories.FirstOrDefaultAsync(m => m.IngredientCategoryID == id);

            if (IngredientCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
