using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlanner.Pages.Menus
{
    public class MenuDetailsModel : PageModel
    {
        private readonly Data.MealPlannerContext _context;

        public MenuDetailsModel(Data.MealPlannerContext context)
        {
            _context = context;
        }

        public Menu Menu { get; set; }
        public Meal MealToCreate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menus
                .Include(m => m.Camp)
                .Include(m => m.Meals)
                    .ThenInclude(m => m.MealRecipes)
                        .ThenInclude(m => m.Recipe)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Menu == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSaveMeal()
        {
            var emptyMeal = new Meal();
            if (await TryUpdateModelAsync<Meal>(
                emptyMeal,
                "meal",
                m => m.Day, m => m.MealType))
            {
                _context.Meals.Add(MealToCreate);
                await _context.SaveChangesAsync();

                return RedirectToPage("#");
            }

            return Page();
        }
    }
}
