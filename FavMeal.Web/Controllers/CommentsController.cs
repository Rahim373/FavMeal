using System;
using System.Net;
using System.Web.Mvc;
using FavMeal.Model;
using FavMealService;
using Microsoft.AspNet.Identity;

namespace FavMeal.Web.Controllers
{
    public class CommentsController : Controller
    {
        readonly CommentService _service = new CommentService();

        // GET: Comments
        public ActionResult Save(Comment comment)
        {

            comment.DateTime = DateTime.UtcNow;
            comment.ReviewBy = User.Identity.GetUserId();
            if (_service.Save(comment)) return new HttpStatusCodeResult(HttpStatusCode.OK);
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}