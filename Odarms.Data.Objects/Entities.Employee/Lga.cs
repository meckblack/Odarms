using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class Lga
    {
        #region Model Data

        [Key]
        public long LgaId { get; set; }
        public string Name { get; set; }

        #endregion

        #region Foreign Keys

        public long StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        #endregion
    }
}
