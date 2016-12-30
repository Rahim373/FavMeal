using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FavMeal.Model;
using FavMealService;
using Microsoft.AspNet.Identity;

namespace FavMeal.Web.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        readonly CommentService service = new CommentService();

        // GET: Comments
        [HttpPost]
        public ActionResult Save(Comment comment)
        {

            comment.DateTime = DateTime.UtcNow;
            comment.ReviewBy = User.Identity.GetUserId();
            if (service.Save(comment)) return new HttpStatusCodeResult(HttpStatusCode.OK);
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}