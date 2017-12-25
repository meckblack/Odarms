using Odarms.Data.Objects.Entities.AccessManagement;
using Odarms.Data.Objects.Entities.Employee;
using Odarms.Data.Objects.Entities.SystemManagement;
using Odarms.Data.Objects.Entities.User;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Odarms.Data.DataContext.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext ()
            : base ("name = Odarms")
        {

        }

        #region AppUserContext

        public DbSet<AppUser> AppUsers { get; set; }


        #endregion

        #region Access Management

        public DbSet<Package> Packages { get; set; }

        #endregion

        #region System Management

        public DbSet<Restaurant> Restuarnts { get; set; }
        public DbSet<Department> Departments { get; set; }


        #endregion

        #region Employee

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeFamilyData> EmployeeFamilyDatas { get; set; }
        public DbSet<EmployeeWorkData> EmployeeWorkDatas { get; set; }
        public DbSet<EmployeeMedicalData> EmployeeMedicalDatas { get; set; }
        public DbSet<EmployeePersonalData> EmployeePersonalDatas { get; set; }
        public DbSet<EmploymentPosition> EmploymentPositions { get; set; }
        public DbSet<Lga> Lgas { get; set; }
        public DbSet<State> States { get; set; }





        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
