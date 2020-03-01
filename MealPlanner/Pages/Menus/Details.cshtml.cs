﻿using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlanner
{
    public class MenuDetailsModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public MenuDetailsModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
