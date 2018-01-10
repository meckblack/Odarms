using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Odarms.Data.DataContext.DataContext;
using System.Threading.Tasks;
using Odarms.Data.Objects.Entities.Employee;

namespace Odarms.Data.Factory.EmployeeManagement
{
    public class StateFactory
    {
        private readonly Data.DataContext.DataContext.DataContext _db;

        #region Constructor

        public StateFactory()
        {
            _db = new Data.DataContext.DataContext.DataContext();
        }
        #endregion  

        public IEnumerable<Lga> GetLgaForState(long stateId)
        {
            return _db.Lgas.Where(n => n.StateId == stateId);
        }
    }
}
