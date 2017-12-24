using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class Lga
    {
        #region Model Data

        [Key]
        public int LgaId { get; set; }
        public string Name { get; set; }
        
        #endregion

        #region Foreign Keys

        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        #endregion
    }
}
