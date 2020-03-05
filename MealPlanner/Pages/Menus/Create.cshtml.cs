using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MealPlanner
{
    public class MenuCreateModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public MenuCreateModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CampID"] = new SelectList(_context.Camps, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Menu Menu { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyMenu = new Menu();

            if (await TryUpdateModelAsync<Menu>(
                emptyMenu,
                "menu",
                m => m.Name, m => m.StartDate, m => m.EndDate))
            {
                _context.Menus.Add(Menu);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();

        }
    }
}
