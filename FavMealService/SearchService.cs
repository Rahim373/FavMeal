using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FavMeal.Model;
using FavMeal.ViewModel;

namespace FavMealService
{
    public class SearchService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<SearchFoodOnlyViewModel> FoodOnly(string foodName)
        {
            IQueryable<Review> reviews = _context.Reviews.Where(x => x.Food.Name.Contains(foodName)).Include(x=> x.Restaurants).Include(x=> x.Food).AsQueryable();
            IQueryable<SearchFoodOnlyViewModel> queryable = reviews.GroupBy(x => x.Restaurants).AsEnumerable().Select(p => new SearchFoodOnlyViewModel
            {
                EnvironmentRating = p.Average(c => c.EnvironmentRating),
                FoodRating = p.Average(c => c.FoodRating),
                PriceRating = p.Average(c => c.PriceRating),
                RestaurantRating = p.Average(c => c.RestaurantRating),
                RestaurantName = p.Key.Name,
                RestaurantId = p.Key.RestaurantId,
                RecentPrice = p.OrderByDescending(c => c.UploadTime).First().Price,
                ReviewCount = p.Count(),
                MatchedString = p.FirstOrDefault()?.Food.Name
            }).AsQueryable();
            return queryable.ToList();
        }

        public List<SearchFoodOnlyViewModel> FoodAndLocation(string food, string location)
        {
            IQueryable<Review> reviews = _context.Reviews.Where(x => x.Food.Name.Contains(food) && x.Restaurants.Address.Contains(location)).Include(x => x.Restaurants).Include(x => x.Food).AsQueryable();
            IQueryable<SearchFoodOnlyViewModel> queryable = reviews.GroupBy(x => x.Restaurants).AsEnumerable().Select(p => new SearchFoodOnlyViewModel
            {
                EnvironmentRating = p.Average(c => c.EnvironmentRating),
                FoodRating = p.Average(c => c.FoodRating),
                PriceRating = p.Average(c => c.PriceRating),
                RestaurantRating = p.Average(c => c.RestaurantRating),
                RestaurantName = p.Key.Name,
                RestaurantId = p.Key.RestaurantId,
                RecentPrice = p.OrderByDescending(c => c.UploadTime).First().Price,
                ReviewCount = p.Count(),
                MatchedString = p.FirstOrDefault()?.Food.Name
            }).AsQueryable();
            return queryable.ToList();
        }

        public List<SearchFoodOnlyViewModel> LocationOnly(string location)
        {
            IQueryable<Review> reviews = _context.Reviews.Where(x=> x.Restaurants.Address.Contains(location)).Include(x => x.Restaurants).Include(x => x.Food).AsQueryable();
            IQueryable<SearchFoodOnlyViewModel> queryable = reviews.GroupBy(x => x.Restaurants).AsEnumerable().Select(p => new SearchFoodOnlyViewModel
            {
                EnvironmentRating = p.Average(c => c.EnvironmentRating),
                FoodRating = p.Average(c => c.FoodRating),
                PriceRating = p.Average(c => c.PriceRating),
                RestaurantRating = p.Average(c => c.RestaurantRating),
                RestaurantName = p.Key.Name,
                RestaurantId = p.Key.RestaurantId,
                RecentPrice = p.OrderByDescending(c => c.UploadTime).First().Price,
                ReviewCount = p.Count(),
                MatchedString = p.FirstOrDefault()?.Food.Name
            }).AsQueryable();
            return queryable.ToList();
        }
    }
}
