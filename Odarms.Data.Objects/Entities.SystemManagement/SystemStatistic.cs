using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.SystemManagement
{
    public class SystemStatistic
    {
        #region Model Data

        public long ApplicationStatisticId { get; set; }

        [Required]
        public string Action { get; set; }

        [DisplayName("Date Occured")]
        public DateTime DateOccured { get; set; }
        
        [DisplayName("Logged In User")]
        public long? LoggedInUserId { get; set; }

        #endregion

        #region Foreign Key

        [DisplayName("Restaurant")]
        public long? RestaurantId { get; set; }

        #endregion
    }
}
