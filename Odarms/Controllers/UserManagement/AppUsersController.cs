using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Odarms.Data.DataContext.DataContext;
using Odarms.Data.Objects.Entities.User;

namespace Odarms.Controllers.UserManagement
{
    public class AppUsersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AppUsers
        public ActionResult Index()
        {
            var appUsers = db.AppUsers.Include(a => a.Restaurant);
            return View(appUsers.ToList());
        }

        // GET: AppUsers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.AppUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // GET: AppUsers/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restuarnts, "RestaurantId", "Name");
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppUserId,FirstName,LastName,MiddleName,Email,Mobile,Password,ComfirmPassword,RestaurantId,CreatedBy,DateCreated,DateLastModified,LastModifiedBy")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.AppUsers.Add(appUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restuarnts, "RestaurantId", "Name", appUser.RestaurantId);
            return View(appUser);
        }

        // GET: AppUsers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.AppUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restuarnts, "RestaurantId", "Name", appUser.RestaurantId);
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppUserId,FirstName,LastName,MiddleName,Email,Mobile,Password,ComfirmPassword,RestaurantId,CreatedBy,DateCreated,DateLastModified,LastModifiedBy")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restuarnts, "RestaurantId", "Name", appUser.RestaurantId);
            return View(appUser);
        }

        // GET: AppUsers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.AppUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AppUser appUser = db.AppUsers.Find(id);
            db.AppUsers.Remove(appUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
