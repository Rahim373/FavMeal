using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavMeal.Model;

namespace FavMealService
{
    public class CommentService
    {
        readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool Save(Comment comment)
        {
            _context.Comments.Add(comment);
            if (_context.SaveChanges() > 0) return true;
            return false;
        }
    }
}
