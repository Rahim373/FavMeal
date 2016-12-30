using FavMeal.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FavMealService.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            AddRoles(context);
            AddFoodCategories(context);
        }

        private void AddFoodCategories(ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(x=> x.Name, 
                new Category {Name = "Fastfood"},
                new Category {Name = "Drinks"},
                new Category {Name = "Chinese"}
                );
        }

        private void AddRoles(ApplicationDbContext context)
        {
            var roles = new[] { "Admin", "User" };
            foreach (string role in roles)
            {
                IdentityRole r = new IdentityRole(role);
                context.Roles.AddOrUpdate(r);
            }
        }
    }
}
