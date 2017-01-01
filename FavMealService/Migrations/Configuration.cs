using System.Diagnostics;
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
            try
            {
                AddRoles(context);
                AddFoodCategories(context);
            }
            catch (System.Exception exception)
            {
                Debug.Write(exception.Message + "\n" + exception.StackTrace);
            }
        }

        private void AddFoodCategories(ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(x=> x.Name, 
                new Category {Name = "Fastfood"},
                new Category {Name = "Drinks"},
                new Category {Name = "Crusher"},
                new Category {Name = "Set Menu"},
                new Category {Name = "Desi"},
                new Category {Name = "Biriyani"},
                new Category {Name = "Street Food"},
                new Category {Name = "Japanese"},
                new Category {Name = "Thai"},
                new Category {Name = "Mexican"},
                new Category {Name = "Icecream"},
                new Category {Name = "Indian"},
                new Category {Name = "Bakery"},
                new Category {Name = "Korean"},
                new Category {Name = "Sea Food"},
                new Category {Name = "Burger"},
                new Category {Name = "Fastfood"},
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
