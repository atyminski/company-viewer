using Gevlee.CompanyViewer.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Configurations
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.TaxNumber)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.NationalBusinessRegistryNumber)
                .HasMaxLength(9)
                .IsRequired();
            builder.Property(x => x.NationalCourtRegisterNumber)
                .HasMaxLength(9)
                .IsRequired();

            builder.HasIndex(x => x.TaxNumber);
            builder.HasIndex(x => x.NationalBusinessRegistryNumber);
            builder.HasIndex(x => x.NationalCourtRegisterNumber);
        }
    }
}
