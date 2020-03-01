using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public int CampID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("CampID")]
        public Camp Camp { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
