using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Vendor
{
    public class Vendor
    {
        #region Model Data

        public long VendorId { get; set; }

        public string Name { get; set; }

        public int MyProperty { get; set; }

        #endregion
    }
}
