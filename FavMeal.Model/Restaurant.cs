using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FavMeal.Model
{
    public class Restaurant
    {
        [Key]
        public string RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}