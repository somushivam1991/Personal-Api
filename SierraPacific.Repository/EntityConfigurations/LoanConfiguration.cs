using SierraPacific.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SierraPacific.Repository.EntityConfigurations
{
    class LoanConfiguration : EntityTypeConfiguration<Loan>
    {
        public LoanConfiguration()
        {
            ToTable("Loans");

            HasKey(l => l.Id);
            Property(l => l.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(l => l.Descriptor).HasMaxLength(100).IsOptional();
            Property(l => l.CustomerId).IsOptional();


            HasRequired(l => l.Customer).WithMany(c => c.Loans).HasForeignKey(l => l.CustomerId);
        }
    }
}
