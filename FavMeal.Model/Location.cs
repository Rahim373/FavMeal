﻿using System.Collections.Generic;

namespace FavMeal.Model
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}