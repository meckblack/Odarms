using Odarms.Data.Objects.Entities.SystemManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class PositionChange : Checker
    {
        #region Model Data

        public long PositionChangeId { get; set; }
        public string Action { get; set; }
        [DisplayName("Previous Position")]
        public long PreviousPositionId { get; set; }
        [DisplayName("Current Position")]
        public long EmploymentPositionId { get; set; }

        #endregion

        #region Foreign Key

        [ForeignKey("EmploymentPositionId")]
        public virtual EmploymentPosition EmploymentPosition { get; set; }

        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public long RestaurantId { get; set; }
        [ForeignKey("InstitutionId")]
        public virtual Restaurant Restaurant { get; set; }

        #endregion
    }
}
