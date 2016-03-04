using SierraPacific.Core.Entities;
using System.Linq;

namespace SierraPacific.Core.Repository
{
    public interface ISampleRepository
    {
        IQueryable<Loan> GetLoans();
    }
}
