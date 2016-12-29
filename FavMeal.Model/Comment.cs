using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavMeal.Model
{
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime DateTime { get; set; }


        [ForeignKey("Reviews")]
        public long ReviewId { get; set; }
        public virtual Review Reviews { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ReviewBy { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}