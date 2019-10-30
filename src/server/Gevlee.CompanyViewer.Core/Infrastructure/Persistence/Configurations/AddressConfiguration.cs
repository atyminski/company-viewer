using Gevlee.CompanyViewer.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Street).IsRequired();
            builder.Property(x => x.HouseNumber).IsRequired();
            builder.Property(x => x.PostalCode).IsRequired();
            builder.Property(x => x.City).IsRequired();
        }
    }
}
