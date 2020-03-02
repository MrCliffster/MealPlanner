using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MealPlanner.Pages.Menus
{
    public class CampNameModel : PageModel
    {
        public SelectList CampNameSL { get; set; }

        public void PopulateCampsDropDownList()
        { }
    }
}
