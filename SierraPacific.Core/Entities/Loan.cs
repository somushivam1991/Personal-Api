using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SierraPacific.Core.Entities
{
    public class Loan
    {
        public Loan()
        {

        }
        public int Id { get; set; }

        public string Descriptor { get; set; }

        public int? CustomerId { get; set; }

        //public int AdviserId { get; set; }

        public Customer Customer { get; set; }
    }
}
