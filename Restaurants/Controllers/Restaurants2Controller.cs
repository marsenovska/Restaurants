using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurants.Views.Restaurants2
{
    public class Restaurants2Controller : Controller
    {
        // GET: Restaurants
        public ActionResult Index()
        {
            return View();
        }

        //Send params example - restaurants/Restaurants/Welcome?name=Monika
        public ActionResult Welcome(string name)
        {
            ViewBag.Message = "Welcome " + name;

            return View();
        }
    }
}