using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner
{
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public IndexModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<Ingredient> Ingredient { get;set; }

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredients
                .Include(i => i.IngredientCategory).ToListAsync();
        }
    }
}
