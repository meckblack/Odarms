using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.SystemManagement
{
    public class Department
    {
        #region Tables

        public long DepartmentId { get; set; }

        [Required(ErrorMessage="Name field is requried")]
        public string Name { get; set; }
        
        #endregion

        #region Foreign Keys

        [DisplayName("Restaraunt Name")]
        public long RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        public long? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee.Employee Employee { get; set; }

        #endregion

        #region IEnumerables

        public IEnumerable<Employee.Employee> Employees { get; set; }

        #endregion


    }
}
