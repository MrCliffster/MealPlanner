using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MealPlanner.Pages.IngredientCategories
{
    public class CreateModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public CreateModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IngredientCategory IngredientCategory { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.IngredientCategories.Add(IngredientCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
