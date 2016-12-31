using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FavMealService;

namespace FavMeal.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantService _service;

        public RestaurantsController()
        {
            _service = new RestaurantService();
        }

        public ActionResult Index(string id)
        {
            return View(_service.GetRestaurantById(id));
        }
    }
}