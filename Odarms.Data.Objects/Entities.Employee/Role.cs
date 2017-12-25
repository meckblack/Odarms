using Odarms.Data.Objects.Entities.SystemManagement;
using Odarms.Data.Objects.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class Role
    {
        #region Model Data

        public long RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ManagePackages { get; set; }
        public bool ManageRestaurants { get; set; }
        public bool ManageDepartments { get; set; }
        public bool ManageVendors { get; set; }
        public bool ManageEmployees { get; set; }

        #endregion

        #region Foreign Keys

        public long? RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        #endregion

        #region IEnumerables

        public IEnumerable<AppUser> AppUsers { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        #endregion

    }
}
