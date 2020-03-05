using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlanner.Pages.Camps
{
    public class CampDeleteModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public CampDeleteModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Camp Camp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Camp = await _context.Camps.FirstOrDefaultAsync(m => m.ID == id);

            if (Camp == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Camp = await _context.Camps.FindAsync(id);

            if (Camp != null)
            {
                _context.Camps.Remove(Camp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
