using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Odarms.Data.Objects.Entities.SystemManagement
{
    public class Restaurant
    {
        [Required]
        public long RestaurantId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        public string Motto { get; set; }

        public string Logo { get; set; }

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
    }
}
