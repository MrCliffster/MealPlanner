using MealPlanner.Models;
using MealPlanner.Models.PlannerViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MealPlanner.Pages.Ingredients
{
    public class CreateModel : IngredientCategoryNamePageModel
    {
        private readonly Data.MealPlannerContext _context;

        public CreateModel(Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateIngredientCategories(_context);
            return Page();
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ingredients.Add(Ingredient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
