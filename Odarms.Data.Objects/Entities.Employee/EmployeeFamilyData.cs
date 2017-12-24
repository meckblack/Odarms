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
    public class EmployeeFamilyData
    {
        #region Model Data

        public long EmployeeFamilyDataId { get; set; }

        [DisplayName("Full Name"), Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
      
        [DisplayName("Address"), Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [DisplayName("Contact Number"), Required(ErrorMessage = "Contact number is required")]
        public string ContactNumber { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "Email is requred")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Date Of Birth"), Required(ErrorMessage = "Date Of Birth is required")]
        public DateTime DOB { get; set; }

        [DisplayName("Relationship"), Required(ErrorMessage = "Date Of Birth is required")]
        public string Relationship { get; set; }

        #endregion

        #region Foreign Keys

        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        #endregion
    }
}
