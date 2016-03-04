using System.Collections.Generic;

namespace SierraPacific.Core.Entities
{
    public class Customer
    {

        public Customer()
        {
            Loans = new List<Loan>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}