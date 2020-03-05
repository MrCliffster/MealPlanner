using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner
{
    public class EditModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public EditModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IngredientCategoryID"] = new SelectList(_context.IngredientCategories, "IngredientCategoryID", "IngredientCategoryID");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(Ingredient.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.ID == id);
        }
    }
}
