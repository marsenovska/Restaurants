using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Services;
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
        public Restaurant[] Get()
        {
            return _restaurantsRepository.GetRestaurants().ToArray();

        }

        [HttpPost]
        public Restaurant[] Post([FromBody] object searchField)
        {
            dynamic restaurant = JsonConvert.DeserializeObject(searchField.ToString());
            
            return _restaurantsRepository.GetRestaurantByName(restaurant.name.ToString(), restaurant.category.ToString());
        }
       
    }
}
