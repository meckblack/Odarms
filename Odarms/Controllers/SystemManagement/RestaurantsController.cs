﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Odarms.Data.DataContext.DataContext;
using Odarms.Data.Objects.Entities.SystemManagement;
using Odarms.Data.Factory.AuthenticationManagement;
using System.Threading.Tasks;

namespace Odarms.Controllers.SystemManagement
{
    public class RestaurantsController : Controller
    {
        private DataContext _db;

        #region Constructor

        public RestaurantsController()
        {
            _db = new DataContext();
        }

        #endregion

        #region Index Restaurant

        // GET: Restaurants
        public ActionResult Index()
        {
            ViewBag.Header = "List Of Restaurants";
            return View(_db.Restaurants.ToList());
        }

        #endregion

        #region Get Restaurant By Category

        // GET: RestaurantsByCategory
        public ActionResult GetRestaurantsByCategory()
        {
            var restaurants = new RestaurantFactory().GetListOfRestaurants();
            return View("Index", restaurants);
        }

        #endregion

        #region Get Active Restaurants

        // GET: GetActiveRestaurants
        public ActionResult GetActiveRestaurants()
        {
            ViewBag.Header = "List Of Active Restaurants";
            var restaurants = new RestaurantFactory().GetListOfRestaurants();
            return View("Index", restaurants.Where(n => n.SubscriptonEndDate > DateTime.Now));
        }

        #endregion

        #region Get Inactive Restaurants

        // GET: GetInActiveRestaurants
        public ActionResult GetInActiveRestaurants()
        {
            ViewBag.Header = "List Of Inactive Restaurants";
            var restaurants = new RestaurantFactory().GetListOfRestaurants();
            return View("Index", restaurants.Where(n => n.SubscriptonEndDate < DateTime.Now));
        }

        #endregion
        
        #region Details Restaurant

        // GET: Restaurants/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        #endregion

        #region Create Restaurant

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            ViewBag.PackageId = new SelectList(_db.Packages, "PackageId", "Name");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantId,Name,Motto,Logo,SubscriprionStartDate,SubscriptonEndDate,SubscriptionDuration,State,LGA,Location,ContactEmail,ContactNumber,SetUpStatus,AccessCode,RegistrationNumber,PackageId")] Restaurant restaurant, FormCollection collectedValues)
        {
            if (ModelState.IsValid)
            {
                restaurant.SubscriprionStartDate = DateTime.Now;
                restaurant.SubscriptonEndDate = restaurant.SubscriprionStartDate.AddYears(1);
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PackageId = new SelectList(_db.Packages, "PackageId", "Name", restaurant.PackageId);
            return View(restaurant);
        }

        #endregion

        #region Edit Restaurant

        // GET: Restaurants/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackageId = new SelectList(_db.Packages, "PackageId", "Name", restaurant.PackageId);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantId,Name,Motto,Logo,SubscriprionStartDate,SubscriptonEndDate,SubscriptionDuration,State,LGA,Location,ContactEmail,ContactNumber,SetUpStatus,AccessCode,RegistrationNumber,PackageId")] Restaurant restaurant, FormCollection collectedValues)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                Session["restaurant"] = restaurant;
                return RedirectToAction("Dashboard", "Home");
            }
            ViewBag.PackageId = new SelectList(_db.Packages, "PackageId", "Name", restaurant.PackageId);
            return View(restaurant);
        }

        #endregion

        #region Delete Restaurant

        // GET: Restaurants/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Register Restaurant

        // GET: /Vendor/Requests
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Restaurant/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include ="Name,Motto,")] Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                if (await _db.Restaurants.AnyAsync(record => record.Name == restaurant.Name))
                {
                    ModelState.AddModelError("", "Company name is taken!!!");
                }
                if (await _db.Restaurants.AnyAsync(r => r.ContactEmail == restaurant.ContactEmail))
                {
                    ModelState.AddModelError("", "Contact mail is taken!!!");
                }
                else
                {
                    var reg = new Restaurant
                    {
                        RestaurantId = restaurant.RestaurantId,
                        Name = restaurant.Name,
                        ContactEmail = restaurant.ContactEmail,
                        ContactNumber = restaurant.ContactNumber,
                        Logo = restaurant.Logo,
                        State = restaurant.State,
                        LGA = restaurant.LGA,
                        Location = restaurant.Location,
                        SubscriptionDuration = restaurant.SubscriptionDuration
                    };

                    _db.Restaurants.Add(reg);
                    _db.SaveChanges();
                    RedirectToAction("Login", "Restaurant");
                }
            }
            return View();
        }


        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion











    }
}
