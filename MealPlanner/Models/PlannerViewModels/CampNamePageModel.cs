using MealPlanner.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MealPlanner.Models.PlannerViewModels
{
    /// <summary>
    /// Class used to populate camp names in dropdown lists
    /// </summary>
    public class CampNamePageModel : PageModel
    {
        public SelectList CampNameSL { get; set; }

        public void PopulateCampsDropDownList(MealPlannerContext _context, object selectedCamp = null)
        {
            var campsQuery = from c in _context.Camps
                             orderby c.Name
                             select c;

            CampNameSL = new SelectList(campsQuery.AsNoTracking(), "ID", "Name", selectedCamp);
        }
    }
}
