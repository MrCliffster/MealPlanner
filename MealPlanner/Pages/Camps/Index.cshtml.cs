using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealPlanner
{
    public class CampIndexModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public CampIndexModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<Camp> Camp { get; set; }

        public async Task OnGetAsync()
        {
            Camp = await _context.Camps.ToListAsync();
        }
    }
}
