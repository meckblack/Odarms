﻿using Odarms.Data.Objects.Entities.SystemManagement;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class EmployeeMedicalData
    {
        #region Model Data

        public long EmployeeMedicalDataId { get; set; }

        [Required(ErrorMessage = "Genotype is required")]
        public string Genotype { get; set; }

        [DisplayName("Blood Group"), Required(ErrorMessage = "Blood Group is required")]
        public string BloodGroup { get; set; }

        #endregion

        #region Foreign Keys

        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [Required]
        public long DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        #endregion
    }
}
