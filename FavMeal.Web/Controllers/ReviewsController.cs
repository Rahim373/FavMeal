using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FavMeal.Model;
using FavMeal.Web.Models;

namespace FavMeal.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.ApplicationUsers).Include(r => r.Category).Include(r => r.Food).Include(r => r.Restaurants);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FoodCategoryId = new SelectList(db.Categories, "Id", "Name");

            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Body,FoodId,FoodCategoryId,RestaurantId,Uploader")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyAH7Tv5mLe3Nvbtp3E4-LXWF70cR0g-53s"));
            //PlaceDetailsRequest request = new PlaceDetailsRequest { PlaceID = "ChIJswq9hku_VTcRc6XODL8kH3U" };
            //PlaceDetailsResponse placeDetailsResponse = new PlaceDetailsService().GetResponse(request);

            //Console.Write(placeDetailsResponse.Status);

            ViewBag.FoodCategoryId = new SelectList(db.Categories, "Id", "Name", review.FoodCategoryId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", review.FoodId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", review.RestaurantId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodCategoryId = new SelectList(db.Categories, "Id", "Name", review.FoodCategoryId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", review.FoodId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", review.RestaurantId);
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
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodCategoryId = new SelectList(db.Categories, "Id", "Name", review.FoodCategoryId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", review.FoodId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", review.RestaurantId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
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
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
