using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using FavMeal.Model;
using FavMeal.ViewModel;
using FavMealService;
using Microsoft.AspNet.Identity;
using PagedList;

namespace FavMeal.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        readonly ReviewService _reviewService = new ReviewService();

        public ActionResult Index(int? page)
        {
            IPagedList<Review> reviews = _db.Reviews.Include(x => x.Restaurants).Include(x => x.Photos).Include(x => x.Category).Include(x => x.Food).Include(x => x.ApplicationUsers).OrderByDescending(x=> x.UploadTime).ToList().ToPagedList(page ?? 1, 10);
            return View(reviews);
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            review.View += 1;
            _db.Entry(review).State = EntityState.Modified;
            _db.SaveChanges();
            return View(review);
        }
        

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FoodCategory = new SelectList(_db.Categories, "Id", "Name");
            return View();
        }
        

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateReview review)
        {
            if (ModelState.IsValid)
            {
                await _reviewService.SaveReview(review, User.Identity.GetUserId());
              
                
                return RedirectToAction("Index");
            }
            ViewBag.FoodCategory = new SelectList(_db.Categories, "Id", "Name");
            return View();
        }


        public ActionResult MostViewed()
        {
            return PartialView("MostViewed", _reviewService.MostViewed());
        }

        public ActionResult GetUserReviews()
        {
            return PartialView("GetUserReviews", _reviewService.GetUserReviews(User.Identity.GetUserId()));
        }


        public ActionResult RecentReviewsHorizontal4()
        {
            return PartialView("_RecentReviewdHorizontal", _reviewService.RecentReviewed(4));
        }

        //public ActionResult TrentingFood()
        //{
        //    return PartialView("TrentingFood", _reviewService.TrendingRetsurant());
        //}


        // GET: Reviews/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodCategoryId = new SelectList(_db.Categories, "Id", "Name", review.FoodCategoryId);
            ViewBag.FoodId = new SelectList(_db.Foods, "Id", "Name", review.FoodId);
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "Id", "Name", review.RestaurantId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Body,FoodId,FoodCategoryId,RestaurantId,Uploader")] Review review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodCategoryId = new SelectList(_db.Categories, "Id", "Name", review.FoodCategoryId);
            ViewBag.FoodId = new SelectList(_db.Foods, "Id", "Name", review.FoodId);
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "Id", "Name", review.RestaurantId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Review review = _db.Reviews.Find(id);
            _db.Reviews.Remove(review);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
