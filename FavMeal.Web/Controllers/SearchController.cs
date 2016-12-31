using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FavMeal.ViewModel;
using FavMealService;

namespace FavMeal.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchService _service = new SearchService();


        public ActionResult Index(string food = "", string location = "",
                                string sortby = "restaurant", string orderby = "desc")
        {
            ViewBag.Food = food;
            ViewBag.Place = location;

            int sortByFlag = 0;

            if (sortby.Equals("restaurant")) sortByFlag = 1;
            else if (sortby.Equals("price")) sortByFlag = 2;
            else if (sortby.Equals("environment")) sortByFlag = 3;
            else if (sortby.Equals("food")) sortByFlag = 4;
            else if (sortby.Equals("restaurantname")) sortByFlag = 5;

            List<SearchFoodOnlyViewModel> list = new List<SearchFoodOnlyViewModel>();

            if (food != "" && location != "")
            {
                list = _service.FoodAndLocation(food, location);
            }
            else if (location != "")
            {
                list = _service.LocationOnly(location);
            }
            else if (food != "")
            {
                list = _service.FoodOnly(food);
            }


            if (orderby.Equals("asc"))
            {
                switch (sortByFlag)
                {
                    case 1:
                        return View(list.OrderBy(x => x.RestaurantRating));
                    case 2:
                        return View(list.OrderBy(x => x.PriceRating));
                    case 3:
                        return View(list.OrderBy(x => x.EnvironmentRating));
                    case 4:
                        return View(list.OrderBy(x => x.FoodRating));
                    case 5:
                        return View(list.OrderBy(x => x.RestaurantName));
                }
            }
            else
            {
                switch (sortByFlag)
                {
                    case 1:
                        return View(list.OrderByDescending(x => x.RestaurantRating));
                    case 2:
                        return View(list.OrderByDescending(x => x.PriceRating));
                    case 3:
                        return View(list.OrderByDescending(x => x.EnvironmentRating));
                    case 4:
                        return View(list.OrderByDescending(x => x.FoodRating));
                    case 5:
                        return View(list.OrderByDescending(x => x.RestaurantName));
                }
            }

            return View(list);
        }
    }
}