using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealPlanner.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public IndexModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<Ingredient> Ingredient { get; set; }

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredients
                .Include(i => i.IngredientCategory).ToListAsync();
        }
    }
}
