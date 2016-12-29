using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavMeal.Model
{
    public class Photo
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public DateTime UploadDateTime { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Uploader { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
