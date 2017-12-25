using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.SystemManagement
{
    public class RestaurantStructure
    {
        #region Model Data

        public long RestaurantStructureId { get; set; }

        [Display(Name = "Does your restaurant have departments as part of its structure?")]
        public bool Department { get; set; }

        #endregion



        #region Foreign Keys

        public long RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        #endregion

    }
}
