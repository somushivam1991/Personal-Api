using SierraPacific.Core.Entities;
using SierraPacific.Core.Repository;
using SierraPacific.Repository.Database;
using System.Linq;
using System;

namespace SierraPacific.Repository
{
    public class SampleRepository : ISampleRepository
    {
        public IQueryable<Loan> GetLoans()
        {
            //using (var db = new SierraPacificDbContext())
            //{
            var db = new SierraPacificDbContext();
            return db.Loans.Select(p => p);
            //}
        }

    }
}
