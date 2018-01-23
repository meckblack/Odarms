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
        [Required]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
        public string Type { get; set; }

        #endregion

        #region IEnumerables

        public IEnumerable<Restaurant> Restaurants { get; set; }

        #endregion

    }
}
