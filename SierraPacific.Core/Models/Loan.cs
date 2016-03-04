namespace SierraPacific.Core.Models
{
    public  class Loan
    {
        public int Id { get; set; }

        public string Descriptor { get; set; }

        public int? CustomerId { get; set; }

        //public int AdviserId { get; set; }

        public Customer Customer { get; set; }
    }
}
