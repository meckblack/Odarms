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
        #region Model Data

        public long EmployeeId { get; set; }
        public List<EmployeeFamilyData> EmployeeFamilyDatas { get; set; }
        public List<EmployeePersonalData> EmployeePersonalDatas { get; set; }
        public List<EmployeeMedicalData> EmployeeMedicalDatas { get; set; }
        public List<EmployeeWorkData> EmployeeWorkDatas { get; set; }


        #endregion

        #region Foreign Keys

        [DisplayName("Restaurant")]
        public long? RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        [DisplayName("Assigned Department")]
        public long? DepartmentId { get; set; }
        [ForeignKey("DepartmentId"), Required]
        public virtual Department Department { get; set; }

        [DisplayName("Assigned Role")]
        public long? RoleId { get; set; }
        [ForeignKey("RoleId"), Required]
        public virtual Role Role { get; set; }

        #endregion

        #region IEnumerables

        public IEnumerable<Department> Departments { get; set; }

        #endregion
    }
}
