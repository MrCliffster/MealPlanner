using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealPlanner.Pages.IngredientCategories
{
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public IndexModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<IngredientCategory> IngredientCategory { get; set; }

        public async Task OnGetAsync()
        {
            IngredientCategory = await _context.IngredientCategories.ToListAsync();
        }
    }
}
