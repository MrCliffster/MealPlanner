using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealPlanner
{
    public class MenuIndexModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public MenuIndexModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<Menu> Menus { get; set; }

        public async Task OnGetAsync()
        {
            Menus = await _context.Menus
                .Include(m => m.Camp)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
