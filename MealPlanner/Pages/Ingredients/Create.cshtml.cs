using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner
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
        ViewData["IngredientCategoryID"] = new SelectList(_context.IngredientCategories, "IngredientCategoryID", "IngredientCategoryID");
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
