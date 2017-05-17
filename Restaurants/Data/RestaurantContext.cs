using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurants.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("RestaurantDbContext")
        {

        }

        public IQueryable<Restaurant> Restaurants { get; set; }
    }
}