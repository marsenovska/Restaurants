using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Data
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurants();
    }
}
