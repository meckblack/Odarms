using Odarms.Data.Objects.Entities.SystemManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.User
{
    public class AppUser : Checker
    {
        #region Model Data

        public long AppUserId { get; set; }

        [DisplayName("First Name"), Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name"), Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [EmailAddress, Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DisplayName("Mobile Number"), Required(ErrorMessage = "Moblie number is required")]
        public string Mobile { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Comfirm password is required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match."), DisplayName("Comfrim Password")]
        public string ComfirmPassword { get; set; }

        #endregion

        #region Foreign Keys

        public long RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        #endregion

    }
}
