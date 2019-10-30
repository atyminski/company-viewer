using Gevlee.CompanyViewer.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Configurations
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.TaxNumber)
                .IsRequired();
            builder.Property(x => x.NationalBusinessRegistryNumber)
                .HasColumnName("nbrn")
                //.HasComment("National Business Registry Number")
                .IsRequired();
            builder.Property(x => x.NationalCourtRegister)
                .HasColumnName("ncr")
                //.HasComment("National Court Register")
                .IsRequired();
            builder.HasIndex(x => x.TaxNumber);
            builder.HasIndex(x => x.NationalBusinessRegistryNumber);
            builder.HasIndex(x => x.NationalCourtRegister);
        }
    }
}
