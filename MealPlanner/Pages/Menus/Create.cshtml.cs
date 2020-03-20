using MealPlanner.Models;
using MealPlanner.Models.PlannerViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MealPlanner.Pages.Menus
{
    public class MenuCreateModel : CampNamePageModel
    {
        private readonly Data.MealPlannerContext _context;

        public MenuCreateModel(Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCampsDropDownList(_context);
            //ViewData["CampID"] = new SelectList(_context.Camps, "ID", "ID");
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
                m => m.MenuName, m => m.StartDate, m => m.EndDate, m => m.CampID))
            {
                _context.Menus.Add(Menu);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            PopulateCampsDropDownList(_context, emptyMenu.CampID);
            return Page();

        }
    }
}
