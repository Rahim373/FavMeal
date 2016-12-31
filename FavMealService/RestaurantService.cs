using FavMeal.Model;
using Google.Maps;
using Google.Maps.Places.Details;

namespace FavMealService
{
    public class RestaurantService
    {
        readonly ApplicationDbContext _context = new ApplicationDbContext();
        private const string ClientId = "AIzaSyAH7Tv5mLe3Nvbtp3E4-LXWF70cR0g-53s";

        public Restaurant GetRestaurant(string id)
        {
            Restaurant restaurant = GetRestaurantById(id);
            if (restaurant == null)
            {
                GoogleSigned.AssignAllServices(new GoogleSigned(ClientId));
                PlaceDetailsRequest request = new PlaceDetailsRequest {PlaceID = id};
                PlaceDetailsResponse placeDetailsResponse = new PlaceDetailsService().GetResponse(request);

                if (placeDetailsResponse.Status == ServiceResponseStatus.Ok)
                {
                    string name = placeDetailsResponse.Result.Name;
                    string address = placeDetailsResponse.Result.FormattedAddress;
                    
                    restaurant = SaveRestaurant(id, name, address);
                }
            }
            return restaurant;
        }

        private Restaurant SaveRestaurant(string id, string name, string address)
        {
            var r = new Restaurant
            {
                Name = name,
                Address = address,
                RestaurantId = id
            };
            _context.Restaurants.Add(r);
            _context.SaveChanges();
            return r;
        }

        public Restaurant GetRestaurantById(string id)
        {
            return _context.Restaurants.Find(id);
        }

        public Restaurant RestaurantDeatails(string id)
        {
            return _context.Restaurants.Find(id);
        }
    }
}
