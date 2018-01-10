using Odarms.Data.Objects.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odarms.Data.Factory.EmployeeManagement
{
    public class EmployeeFactory
    {
        private readonly Data.DataContext.DataContext.DataContext _db;

        #region Constructor

        public EmployeeFactory()
        {
            _db = new Data.DataContext.DataContext.DataContext();
        }
        #endregion      

        /// <summary>
        ///     This method rerieves an employees data
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployee(long employeeId)
        {
            var employee = _db.Employees.SingleOrDefault(n => n.EmployeeId == employeeId);
            return employee;
        }

        /// <summary>
        ///     This method rerieves an employees personal data
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public EmployeePersonalData GetEmployeePersonalData(long employeeId)
        {
            var employeePersonalData =_db.EmployeePersonalDatas.SingleOrDefault(n => n.EmployeeId == employeeId);
            return employeePersonalData;
        }

        /// <summary>
        ///     This method retrieves an employees medical data
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public EmployeeMedicalData GetEmployeeMedicalData(long employeeId)
        {
            var employeeMedicalData = _db.EmployeeMedicalDatas.SingleOrDefault(n => n.EmployeeId == employeeId);
            return employeeMedicalData;
        }

        /// <summary>
        ///     This method retrieves an employee work data
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public EmployeeWorkData GetEmployeeWorkData(long employeeId)
        {
            var employeeWorkData = _db.EmployeeWorkDatas.SingleOrDefault(n => n.EmployeeId == employeeId);
            return employeeWorkData;
        }

        /// <summary>
        ///     This method retrives all the list of employee bank data and appends to a list
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IEnumerable<EmployeeBankData> GetEmployeeBankData(long employeeId)
        {
            var employeeBankData = _db.EmployeeBankDatas.Where(n => n.EmployeeId == employeeId);
            return employeeBankData.ToList();
        }

    }
}
