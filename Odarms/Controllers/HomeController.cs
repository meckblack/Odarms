using Odarms.Data.DataContext.DataContext;
using Odarms.Data.Objects.Entities.SystemManagement;
using Odarms.Data.Service.Enums;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Odarms.Controllers.Landing
{
    public class HomeController : Controller
    {

        private readonly DataContext _db = new DataContext();

        #region Select Restaurant

        [HttpGet]
        public ActionResult SelectRestaurant()
        {
            Session["restaurant"] = null;
            ViewBag.Restaurants = new SelectList(_db.Restaurants.Where(r => r.SubscriptonEndDate > DateTime.Now 
                                                   /*&& r.SetUpStatus == SetUpStatus.Completed.ToString()*/), "RestaurantId", "Name");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SelectRestaurant(Restaurant restaurant, FormCollection collectedValues)
        {
            if (restaurant == null) throw new ArgumentNullException(nameof(restaurant));
            var restaurantId = Convert.ToInt64(collectedValues["RestaurantId"]);
            var accessCode = collectedValues["AccessCode"];

            restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant.AccessCode == accessCode)
            {
                Session["restaurant"] = restaurant;
            }
            else
            {
                ViewBag.Restaurants = new SelectList(_db.Restaurants.Where(r => r.SubscriptonEndDate > DateTime.Now
                                                   /*&& r.SetUpStatus == SetUpStatus.Completed.ToString()*/), "RestaurantId", "Name");
                TempData["access"] = "Access code doesn't match institution!Try Again";
                TempData["notificationType"] = NotificationType.Error.ToString();
                return View(restaurant);
            }

            return RedirectToAction("PersonalData", "EmployeeManagement");
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}