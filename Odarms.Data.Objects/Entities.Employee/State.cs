using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class State
    {
        #region Model Data

        [Key]
        public long StateId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        #endregion

        #region Enumerables

        public IEnumerable<Lga> Lgas { get; set; }

        #endregion
    }
}
