using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Restaurants.Data;

namespace Restaurants.Controllers
{
    public class RestaurantController : ApiController
    {

        private RestaurantRepository _restaurantsRepository;

        public RestaurantController()
        {
            this._restaurantsRepository = new RestaurantRepository(new RestaurantDbContext());
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var restaurants = _restaurantsRepository.GetRestaurants().ToArray();
            return restaurants.Length != 0 ? Request.CreateResponse(HttpStatusCode.Created, restaurants) : Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] object restaurantJson)
        {
            var restaurant = JsonConvert.DeserializeObject<Dictionary<string, string>>(restaurantJson.ToString());
            var name = restaurant["name"];
            var category = restaurant["category"];
            var restaurants = _restaurantsRepository.GetRestaurantByName(name, category);
            return restaurants != null ? Request.CreateResponse(HttpStatusCode.Created, restaurants) : Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
