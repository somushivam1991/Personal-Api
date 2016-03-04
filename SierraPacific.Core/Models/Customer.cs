using System.Collections.Generic;

namespace SierraPacific.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
