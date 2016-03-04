using SierraPacific.Core.Models;
using System.Collections.Generic;

namespace SierraPacific.Core.Service
{
    public interface ISampleService
    {
        ICollection<Loan> GetLoans();

        string GetSessionId(User user);
    }
}
