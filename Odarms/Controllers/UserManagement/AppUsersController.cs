using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Odarms.Data.DataContext.DataContext;
using Odarms.Data.Objects.Entities.User;
using Odarms.Data.Objects.Entities.SystemManagement;
using System.Web.Security;
using Odarms.Data.Service.Encryption;
using Odarms.Data.Service.TextFormatter;

namespace Odarms.Controllers.UserManagement
{
    public class AppUsersController : Controller
    {
        private DataContext _db;

        #region Constructor

        public AppUsersController()
        {
            _db = new DataContext();
        }

        #endregion

        #region Index AppUser

        // GET: AppUsers
        public ActionResult Index()
        {
            var restaurant = Session["restaurant"] as Restaurant;
            var appUsers = _db.AppUsers.Include(a => a.Employee).Include(a => a.Restaurant);
            return View(appUsers.ToList().Where(a => restaurant != null && a.RestaurantId == restaurant.RestaurantId));
        }

        #endregion
        
        #region Details AppUser

        // GET: AppUsers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = _db.AppUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        #endregion

        #region Get Admin AppUsers

        public ActionResult GetAdminAppUsers()
        {
            var appUsers = _db.AppUsers.Include(a => a.Restaurant);
            var admin = new List<AppUser>();
            foreach (var item in appUsers)
            {
                if (item.RoleId != null)
                {
                    var userRole = _db.Roles.Find(item.RoleId);
                    if((userRole.Name == "Platform Administrator" || userRole.Name == "Restaurant Adminstrator"))
                    {
                        admin.Add(item);
                    }
                }
            }
            return View("Index", admin);
        }

        #endregion

        #region Create AppUser

        // GET: AppUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppUserId,FirstName,LastName,MiddleName,Email,Mobile,Password,ComfirmPassword,RestaurantId,Create_dby,DateCreated,DateLastModified,LastModifie_dby")] AppUser appUser, FormCollection collectedValues)
        {
            var loggedinuser = Session["odarmsloggedinuser"] as AppUser;
            var restaurant = Session["restaurant"] as Restaurant;

            if (ModelState.IsValid)
            {
                if (loggedinuser != null && restaurant != null)
                {
                    appUser.EmployeeId = loggedinuser.EmployeeId;
                    appUser.RestaurantId = loggedinuser.RestaurantId;
                    appUser.DateLastModified = DateTime.Now;
                    appUser.DateCreated = DateTime.Now;
                    appUser.LastModifiedBy = loggedinuser.AppUserId;
                    appUser.CreatedBy = loggedinuser.AppUserId;

                    //generate password and convert to md5 hash
                    var password = Membership.GeneratePassword(8, 1);
                    var hashPassword = new Md5Encryption().ConvertStringToMd5Hash(password.Trim());
                    appUser.Password = new RemoveCharacters().RemoveSpecialCharacters(hashPassword);
                    appUser.ComfirmPassword = appUser.Password;

                }
                _db.AppUsers.Add(appUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(appUser);
        }


        #endregion

        #region Edit Appuser

        // GET: AppUsers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = _db.AppUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppUserId,FirstName,LastName,MiddleName,Email,Mobile,Password,ComfirmPassword,RestaurantId,Create_dby,DateCreated,DateLastModified,LastModifie_dby")] AppUser appUser)
        {
            var loggedinuser = Session["odarmsloggedinuser"] as AppUser;

            if (ModelState.IsValid)
            {
                appUser.DateLastModified = DateTime.Now;
                if (loggedinuser != null)
                {
                    appUser.LastModifiedBy = loggedinuser.AppUserId;
                }
                _db.Entry(appUser).State = EntityState.Modified;
                _db.SaveChanges();
                Session["odarmsloggedinuser"] = appUser;
                if (loggedinuser != null && loggedinuser.AppUserId != appUser.AppUserId)
                {
                    return RedirectToAction("Dashboard", "Home");
                }

                return RedirectToAction("Index");
            }
            return View(appUser);
        }

        #endregion

        #region Delete AppUser

        // GET: AppUsers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = _db.AppUsers.Find(id);
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
            AppUser appUser = _db.AppUsers.Find(id);
            _db.AppUsers.Remove(appUser);
            _db.SaveChanges();
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
