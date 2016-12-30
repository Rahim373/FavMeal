using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavMeal.Model
{
    public class Review
    {
        public Review()
        {
            UploadTime = DateTime.UtcNow;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }

        [Required]
        public int FoodRating { get; set; }
        [Required]
        public int PriceRating { get; set; }
        [Required]
        public int EnvironmentRating { get; set; }
        [Required]
        public int RestaurantRating { get; set; }

        [Required]
        [ForeignKey("Food")]
        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        public int View { get; set; }


        [ForeignKey("Category")]
        public int FoodCategoryId { get; set; }
        public virtual Category Category { get; set; }


        [ForeignKey("Restaurants")]
        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurants { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        [ForeignKey("ApplicationUsers")]
        public string Uploader { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public DateTime UploadTime { get; set; }
    }
}
