using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Pages.IngredientCategories
{
    public class EditModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public EditModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(IngredientCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientCategoryExists(IngredientCategory.IngredientCategoryID))
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

        private bool IngredientCategoryExists(int id)
        {
            return _context.IngredientCategories.Any(e => e.IngredientCategoryID == id);
        }
    }
}
