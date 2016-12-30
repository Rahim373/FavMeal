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
