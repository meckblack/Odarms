using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Objects.Entities.Employee
{
    public class Bank
    {
        #region Model Data

        public long BankId { get; set; }
        public string Name { get; set; }

        #endregion

        #region IEnumerable

        public IEnumerable<EmployeeBankData> EmployeeBankDatas { get; set; }

        #endregion


    }
}
