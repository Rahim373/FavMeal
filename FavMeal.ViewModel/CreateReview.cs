using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace FavMeal.ViewModel
{
    public class CreateReview
    {
        [DisplayName("Details")]
        public string Body { get; set; }

        [DisplayName("Restaurant Name *")]
        public string PlaceId { get; set; }

        [DisplayName("Food Type *")]
        public int FoodCategory { get; set; }

        [DisplayName("Food Name *")]
        public string FoodName { get; set; }

        [DisplayName("Price *")]
        public int Price { get; set; }

        [DisplayName("Food")]
        public int FoodRating { get; set; }

        [DisplayName("Price")]
        public int PriceRating { get; set; }

        [DisplayName("Environment")]
        public int Environment { get; set; }

        [DisplayName("Restaurant")]
        public int RestaurantRating { get; set; }

        [DisplayName("Photos *")]
        public ICollection<HttpPostedFileBase> Photos { get; set; }
    }
}
