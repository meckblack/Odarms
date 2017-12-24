using Odarms.Data.Objects.Entities.SystemManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class Employee
    {
        public long EmployeeId { get; set; }



        #region Foreign Keys

        [DisplayName("Restaurant")]
        public long? RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        [DisplayName("Assigned Department")]
        public long? DepartmentId { get; set; }
        [ForeignKey("DepartmentId"), Required]
        public virtual Department Department { get; set; }



        #endregion
    }
}
