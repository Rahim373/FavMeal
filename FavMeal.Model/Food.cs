using System.Collections.Generic;

namespace FavMeal.Model
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
