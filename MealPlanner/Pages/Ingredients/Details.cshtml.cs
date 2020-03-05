using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlanner.Pages.Ingredients
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public DetailsModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public Ingredient Ingredient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await _context.Ingredients
                .Include(i => i.IngredientCategory).FirstOrDefaultAsync(m => m.ID == id);

            if (Ingredient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
