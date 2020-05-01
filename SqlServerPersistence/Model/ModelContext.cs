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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 0);
        }
        public virtual DbSet<CustomerGroup> CustomerGroup { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPictures> ProductPictures { get; set; }
        public virtual DbSet<Simcard> Simcard { get; set; }
        public virtual DbSet<DivarCategory> DivarCategory { get; set; }
        public virtual DbSet<ChatNumbers> ChatNumbers { get; set; }
    }
}
