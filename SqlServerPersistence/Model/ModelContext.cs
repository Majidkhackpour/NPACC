using System.Data.Entity;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Migrations;

namespace SqlServerPersistence.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }
        public virtual DbSet<CustomerGroup> CustomerGroup { get; set; }
    }
}
