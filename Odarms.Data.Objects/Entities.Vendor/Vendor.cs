using Odarms.Data.Objects.Entities.SystemManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Vendor
{
    public class Vendor
    {
        #region Model Data

        public long VendorId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [DisplayName("Vendor Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "State field is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "LGA field is required")]
        public string LGA { get; set; }

        [Required(ErrorMessage = "Contact Address field is required")]
        public string ContactAddress { get; set; }

        [Required(ErrorMessage = "Contact Number field is required")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Contact Email field is required")]
        public string ContactEmail { get; set; }

        #endregion

        #region Foreign Keys

        public long? RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        #endregion

    }
}
