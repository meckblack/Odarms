using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class Employee
    {
        #region Foreign Keys
        public long RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public int MyProperty { get; set; }
        #endregion
    }
}
