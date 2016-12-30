using System.Web.Mvc;
using FavMealService;

namespace FavMeal.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchService _service = new SearchService();
        // GET: Search
        public ActionResult Index(string food = "", string location = "")
        {
            @ViewBag.Food = food;
            @ViewBag.Place = location;
            @ViewBag.Term = food;
            if (food != "" && location != "")
            {
                return View(_service.FoodAndLocation(food, location));
            }
            if (location != "")
            {
                return View(_service.LocationOnly(location));
            }
            if (food != "")
            {
                return View(_service.FoodOnly(food));
            }
           
            return HttpNotFound("No search data");
        }
    }
}