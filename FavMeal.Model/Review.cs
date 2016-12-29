using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FavMeal.Model
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }

        [Required]
        [ForeignKey("Food")]
        public int FoodId { get; set; }

        public virtual Food Food { get; set; }



        [ForeignKey("Category")]
        public int FoodCategoryId { get; set; }
        public virtual Category Category { get; set; }


        [ForeignKey("Restaurants")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurants { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        [ForeignKey("ApplicationUsers")]
        public string Uploader { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
