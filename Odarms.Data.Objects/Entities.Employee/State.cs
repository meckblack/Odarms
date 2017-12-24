using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        //public IEnumerable<Lga> Lgas { get; set; }
    }
}
