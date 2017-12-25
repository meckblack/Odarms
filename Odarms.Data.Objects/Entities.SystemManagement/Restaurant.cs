using Odarms.Data.Objects.Entities.AccessManagement;
using Odarms.Data.Objects.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odarms.Data.Objects.Entities.SystemManagement
{
    public class Restaurant
    {
        #region Model Data

        public long RestaurantId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        public string Motto { get; set; }

        public string Logo { get; set; }

        public DateTime SubscriprionStartDate { get; set; }

        public DateTime SubscriptonEndDate { get; set; }

        [DisplayName("Subscription Duration")]
        public string SubscriptionDuration { get; set; }

        [Required(ErrorMessage = "State field is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "LGA field is required")]
        public string LGA { get; set; }

        [Required(ErrorMessage = "Location field is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Contact Email field is required")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Contact Number field is required")]
        public string ContactNumber { get; set; }

        #endregion

        #region Foreign Keys

        public long? PackageId { get; set; }
        [ForeignKey("PackageId")]
        public virtual Package Package { get; set; }
        #endregion

        #region IEnumerables

        public IEnumerable<Employee.Employee> Employees { get; set; }
        public IEnumerable<Employee.EmploymentPosition> EmploymentPositions { get; set; }
        public IEnumerable<AppUser> AppUsers { get; set; }


        #endregion



    }
}
