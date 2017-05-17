using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using Microsoft.VisualBasic.Logging;
using WebGrease.Activities;

namespace Restaurants.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        RestaurantDbContext _ctx;



        public RestaurantRepository(RestaurantDbContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _ctx.Restaurants.OrderBy(r => r.Name).ToArray();
        }

        public Restaurant[] GetRestaurantByName(string name, string category)
        {
            var restaurants = new Restaurant[] { };
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) && category == "All")
            {
                restaurants = _ctx.Restaurants.Where(r => r.Name == name).OrderBy(n => n.Name).ToArray();
            }
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) && category != "All")
            {
                restaurants = _ctx.Restaurants.Where(r => r.Name == name && r.Type == category).OrderBy(n => n.Name).ToArray();
            }
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) && category != "All")
            {
                restaurants = _ctx.Restaurants.Where(r => r.Type == category).OrderBy(n => n.Name).ToArray();
            }
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(category) && category == "All")
            {
                restaurants = _ctx.Restaurants.OrderBy(n => n.Name).ToArray();
            }

            return restaurants;
        }
    }
}