using MealPlanner.Models;
using System;
using System.Linq;

namespace MealPlanner.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(MealPlannerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Menus
            if (context.Menus.Any())
                return; // DB has been seeded

            var fakeCamp = new Camp
            {
                Name = "Fake Camp"
            };

            var straddy = new Camp
            {
                Name = "Stradbroke Cup"
            };

            var camps = new Camp[]
            {
                fakeCamp,
                straddy
            };

            foreach (var camp in camps)
                context.Camps.Add(camp);

            context.SaveChanges();

            var menus = new Menu[]
            {
                new Menu{MenuName="Tristan's First Menu", StartDate=DateTime.Parse("2020-03-02"), EndDate=DateTime.Parse("2020-03-04"), CampID = fakeCamp.ID},
                new Menu{MenuName="Straddy 2020", StartDate=DateTime.Parse("2020-04-10"), EndDate=DateTime.Parse("2020-04-14"), CampID = straddy.ID}
            };

            foreach (var menu in menus)
                context.Menus.Add(menu);

            context.SaveChanges();
        }
    }
}
