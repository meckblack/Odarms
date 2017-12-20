using Odarms.Data.Objects.Entities.SystemManagement;
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

        #endregion

        #region SystemManagement
        public DbSet<Restaurant> Restuarnts { get; set; }
        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
