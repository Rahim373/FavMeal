using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavMeal.ViewModel
{
    public class CreateReview
    {
        public string Body { get; set; }
        public string PlaceId { get; set; }
        public int FoodCategory { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
        public int FoodRating { get; set; }
        public int PriceRating { get; set; }
        public int Environment { get; set; }
        public int RestaurantRating { get; set; }
    }
}
