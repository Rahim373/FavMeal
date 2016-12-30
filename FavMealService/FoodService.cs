using System.Linq;
using FavMeal.Model;

namespace FavMealService
{
    public class FoodService
    {
        readonly ApplicationDbContext _context = new ApplicationDbContext();

        public Food AddFood(string name)
        {
            Food food = GetFoodByName(name);
            if (food == null)
            {
                var f = new Food {Name = name};
                _context.Foods.Add(f);
                _context.SaveChanges();
                food = f;
            }
            return food;
        }

        public Food GetFoodByName(string name )
        {
            return _context.Foods.AsNoTracking().FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
