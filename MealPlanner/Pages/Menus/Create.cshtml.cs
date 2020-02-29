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
        ViewData["CampID"] = new SelectList(_context.Camps, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Menu Menu { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Menus.Add(Menu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
