using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Odarms.Data.DataContext.DataContext;
using Odarms.Data.Objects.Entities.AccessManagement;
using Odarms.Data.Service.Enums;
using Odarms.Data.Objects.Entities.User;

namespace Odarms.Controllers.AccessManagement
{
    public class PackagesController : Controller
    {
        private DataContext _db;

        #region Constructor

        public PackagesController()
        {
            _db = new DataContext();
        }

        #endregion

        #region Index Package

        // GET: Packages
        public ActionResult Index()
        {
            return View(_db.Packages.ToList());
        }

        #endregion

        #region Details Package

        // GET: Packages/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = _db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        #endregion

        #region Create Package

        // GET: Packages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackageId,Name,Description,Amount,Type")] Package package, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var allPackages = _db.Packages.ToList();
                package.DateCreated = DateTime.Now;
                package.DateLastModified = DateTime.Now;
                package.Amount = long.Parse(collection["Amount"]);
                package.Description = collection["Description"];
                package.Name = collection["Name"];
                package.Type = typeof(PackageType).GetEnumName(int.Parse(collection["Type"]));

                if (allPackages.Count >= 3)
                {
                    TempData["message"] = "You cannot added a package!";
                    TempData["notificationType"] = NotificationType.Error.ToString();
                    return RedirectToAction("Index");
                }

                if (allPackages.Any(p => p.Type == package.Type))
                {
                    TempData["message"] = "You cannot add this package because this type exist!";
                    TempData["notificationType"] = NotificationType.Error.ToString();
                    return RedirectToAction("Index");
                }

                _db.Packages.Add(package);
                _db.SaveChanges();
                TempData["message"] = "You have successfully added a new package!";
                TempData["notificationType"] = NotificationType.Success.ToString();
                return RedirectToAction("Index");
            }

            return View(package);
        }

        #endregion

        #region Edit Package

        // GET: Packages/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = _db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackageId,Name,Description,Amount,Type")] Package package)
        {
            var loggedinuser = Session["odarmsloggedinuser"] as AppUser; 
            if (loggedinuser != null)
            {
                if (ModelState.IsValid)
                {
                    package.DateLastModified = DateTime.Now;
                    //package.LastModifiedBy = loggedinuser.AppUserId;
                    _db.Entry(package).State = EntityState.Modified;
                    _db.SaveChanges();
                    TempData["message"] = "You have successfully modified the package";
                    TempData["notificationtype"] = NotificationType.Success.ToString();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["message"] = "Session Expired, Login Again";
                TempData["notificationtype"] = NotificationType.Info.ToString();
                return RedirectToAction("Login", "Account");
            }
            
            return View(package);
        }

        #endregion

        #region Delete Package

        // GET: Packages/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = _db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var loggedinuser = Session[""] as AppUser;
            if (loggedinuser != null)
            {
                Package package = _db.Packages.Find(id);
                _db.Packages.Remove(package);
                _db.SaveChanges();
            }
            else
            {
                TempData["message"] = "Session Expired, Login Again";
                TempData["notificationtype"] = NotificationType.Info.ToString();
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Index");
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
