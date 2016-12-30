using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavMeal.Model
{
    public class Photo
    {
        public Photo()
        {
            UploadDateTime = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Url { get; set; }

        
        public DateTime UploadDateTime { get; set; }


        [ForeignKey("Review")]
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}
