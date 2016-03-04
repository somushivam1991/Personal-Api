using SierraPacific.Core.Entities;
using System.Data.Entity.Migrations;

namespace SierraPacific.Repository.Database
{
    class SierraPacificDbMigrationConfig : DbMigrationsConfiguration<SierraPacificDbContext>
    {
        public SierraPacificDbMigrationConfig()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SierraPacificDbContext context)
        {
            context.Customers.AddOrUpdate(c => c.Id,
                new Customer { Id = 1, Name = "James Bond" },
                new Customer { Id = 12, Name = "Mike Tyson" });

            context.Loans.AddOrUpdate(l => l.Id,
                new Loan { Id = 1, CustomerId = 1, Descriptor = "Car loan" },
                new Loan { Id = 2, CustomerId = 1, Descriptor = "Home loan" });
        }
    }
}
