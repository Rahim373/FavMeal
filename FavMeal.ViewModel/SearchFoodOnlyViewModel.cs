namespace FavMeal.ViewModel
{
    public class SearchFoodOnlyViewModel
    {
        public string RestaurantName { get; set; }
        public string RestaurantId { get; set; }
        public double RestaurantRating { get; set; }
        public double EnvironmentRating { get; set; }
        public double FoodRating { get; set; }
        public double PriceRating { get; set; }
        public double RecentPrice { get; set; }
        public int ReviewCount { get; set; }
        public string MatchedString { get; set; }

    }
}
