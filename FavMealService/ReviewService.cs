﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FavMeal.Model;
using FavMeal.ViewModel;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;

namespace FavMealService
{
    public class ReviewService
    {
        readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task SaveReview (CreateReview review, string userId)
        {
            var list = new List<Photo>();
            const string clientId = "f5bdf6e7f18c5e9";
            const string clientSecret = "ea040fe8774f5c90c61e3aa74abc74026c99165a";


            ImgurClient client = new ImgurClient(clientId, clientSecret);
            ImageEndpoint imageEndpoint = new ImageEndpoint(client);

            foreach (HttpPostedFileBase photo in review.Photos)
            {
                try
                {
                    IImage image;
                    using (var binaryReader = new BinaryReader(photo.InputStream))
                    {
                        var fileData = binaryReader.ReadBytes(photo.ContentLength);
                        using (Stream stream = new MemoryStream(fileData))
                        {
                            image = await imageEndpoint.UploadImageStreamAsync(stream);
                            list.Add(new Photo
                            {
                                Id = image.Id,
                                UploadDateTime = DateTime.UtcNow,
                                Url =image.Link,

                            });
                        }
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
           
            FoodService fs = new FoodService();
            Food food = fs.AddFood(review.FoodName);

            RestaurantService rs = new RestaurantService();
            Restaurant restaurant = rs.GetRestaurant(review.PlaceId);

            _context.Reviews.Add(new Review
            {
                Uploader = userId,
                RestaurantId = restaurant.RestaurantId,
                FoodCategoryId = review.FoodCategory,
                FoodId = food.Id,
                Body = review.Body,
                Photos = list,
                FoodRating = review.FoodRating,
                EnvironmentRating = review.Environment,
                PriceRating = review.PriceRating,
                RestaurantRating = review.RestaurantRating,
                Price = review.Price
            });
            _context.SaveChanges();
        }

        public List<Review> MostViewed()
        {
            return _context.Reviews.OrderByDescending(x => x.View).Take(10).Include(x=> x.Photos).Include(x=> x.Restaurants).ToList();
        }

        public List<Review> RecentReviewed(int count)
        {
            return _context.Reviews.OrderByDescending(x => x.UploadTime).Take(count).Include(x => x.Photos).Include(x => x.Restaurants).ToList();
        }

        public List<Review> GetUserReviews(string userId)
        {
            return _context.Reviews.Where(x => x.Uploader == userId).ToList();
        }
    }
}
