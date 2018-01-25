using Odarms.Data.Objects.Entities.SystemManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.AccessManagement
{
    public class Package : Checker
    {
        #region Model Data

        public long PackageId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description field is required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Amount field is required")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Type field is required")]
        public string Type { get; set; }

        #endregion

        #region IEnumerables

        public IEnumerable<Restaurant> Restaurants { get; set; }

        #endregion

    }
}
