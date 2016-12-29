using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FavMeal.Web.Startup))]
namespace FavMeal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
