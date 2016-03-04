namespace SierraPacific.Repository.Database
{
    using Core.Entities;
    using EntityConfigurations;
    using System.Data.Entity;
    public partial class SierraPacificDbContext : DbContext
    {
        public SierraPacificDbContext()
            : base("name=Sierra.Pacific")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SierraPacificDbContext, SierraPacificDbMigrationConfig>());

            //Configuration.ProxyCreationEnabled = false; // means we have to use include
            //Configuration.LazyLoadingEnabled = false;  
        }

        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LoanConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }

    }
}
