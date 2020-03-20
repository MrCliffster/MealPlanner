using MealPlanner.Models;
using MealPlanner.Models.PlannerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Pages.Menus
{
    public class MenuEditModel : CampNamePageModel
    {
        private readonly Data.MealPlannerContext _context;

        public MenuEditModel(Data.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu Menu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menus
                .Include(m => m.Camp).FirstOrDefaultAsync(m => m.ID == id);

            if (Menu == null)
            {
                return NotFound();
            }
            PopulateCampsDropDownList(_context, Menu.CampID);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuToUpdate = await _context.Menus.FindAsync(id);

            if (menuToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                menuToUpdate,
                "menu", // Prefix for form value.
                m => m.MenuName, m => m.CampID, m => m.StartDate, m => m.EndDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select CampID if TryUpdateModelAsync fails.
            PopulateCampsDropDownList(_context, Menu.CampID);
            return Page();
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.ID == id);
        }
    }
}
