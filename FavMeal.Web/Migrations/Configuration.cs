using FavMeal.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FavMeal.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FavMeal.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FavMeal.Web.Models.ApplicationDbContext context)
        {
            AddRoles(context);
        }

        private void AddRoles(ApplicationDbContext context)
        {
            var roles = new[] {"Admin", "User"};
            foreach (string role in roles)
            {
                IdentityRole r = new IdentityRole(role);
                context.Roles.AddOrUpdate(r);
            }
        }
    }
}
