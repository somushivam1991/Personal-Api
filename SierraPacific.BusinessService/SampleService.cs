using SierraPacific.Core.Models;
using SierraPacific.Core.Repository;
using SierraPacific.Core.Service;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SierraPacific.BusinessService
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository sampleRepository;
        public SampleService(ISampleRepository sampleRepository)
        {
            this.sampleRepository = sampleRepository;
        }
        public ICollection<Loan> GetLoans()
        {
            var loans = sampleRepository.GetLoans();
            return loans.Select(l => new Loan
            {
                CustomerId = l.CustomerId,
                Id = l.Id,
                Descriptor = l.Descriptor
            }).ToList();
        }

        public string GetSessionId(User user)
        {
            // api call with user creds to existing service
            return "SampleSessionId";
        }
    }
}
