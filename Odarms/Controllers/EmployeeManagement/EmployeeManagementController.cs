﻿using Odarms.Data.DataContext.DataContext;
using Odarms.Data.Factory.EmployeeManagement;
using Odarms.Data.Objects.Entities.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odarms.Controllers.EmployeeManagement
{
    public class EmployeeManagementController : Controller
    {
        private readonly DataContext _db = new DataContext();

        #region Fetch Data

        /// <summary>
        ///     Sends Json responds object to view with lga of the state requested via an Ajax call
        /// </summary>
        /// <param name="id"> state id</param>
        /// <returns>lgas</returns>
        /// Microsoft.CodeDom.Providers.DotNetCompilerPlatform
        public JsonResult GetLgaForState(int id)
        {
            var lgas = new StateFactory().GetLgaForState(id);
            return Json(lgas, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///     Sends Json responds object to view with Depratments of the Restaurant requested via an Ajax call
        /// </summary>
        /// <param name="id"> Restaurant id</param>
        /// <returns>departments</returns>
        /// Microsoft.CodeDom.Providers.DotNetCompilerPlatform
        public JsonResult GetDepartmentsForRestaurant(int id)
        {
            var deaprtments = _db.Departments.Where(r => r.RestaurantId == id);
            return Json(deaprtments, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///     Sends Json responds object to check if email exists requested via an Ajax call
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>emailCheck</returns>
        /// Microsoft.CodeDom.Providers.DotNetCompilerPlatform
        public JsonResult CheckIfEmailExist(string email)
        {
            var emailCheck = _db.EmployeePersonalDatas.Where(n => n.Email == email);
            return Json(emailCheck, JsonRequestBehavior.AllowGet);
        }
        
        // GET: EmployeeManagement/ListOfEmployeesByStatus
        public ActionResult ListOfEmployeesByStatus(string status, long? id)
        {
            var employees = new EmployeeFactory().GetAllEmployeesByStatus(status, id);
            return View(employees.ToList());
        }

        // GET: EmployeeManagement/ListOfEmployeesInactive
        public ActionResult ListOfEmployeesInactive(string status)
        {
            var employees = new EmployeeFactory().GetAllInactiveEmployees(status);
            return View("ListOfEmployeesByStatus", employees);
        }

        // GET: EmployeeManagement/ListOfEmployees
        public ActionResult ListOfEmployees()
        {
            var institution = Session["institution"] as Restaurant;
            return
                View(
                    _db.Employees.ToList()
                        .Where(n => institution != null && n.RestaurantId == institution.RestaurantId));
        }



        #endregion



        // GET: EmployeeManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}