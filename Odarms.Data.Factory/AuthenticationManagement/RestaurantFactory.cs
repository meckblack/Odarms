﻿using Odarms.Data.Objects.Entities.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Factory.AuthenticationManagement
{
    public class RestaurantFactory
    {
        private readonly DataContext _db = new DataContext();

        /// <summary>
        /// This method retrieves the list of all institutions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Restaurant> GetListOfInstitutions()
        {
            var allRestaurants = _db.Restaurants.ToList();
            var restaurants = allRestaurants;
            return restaurants;
        }
    }
}