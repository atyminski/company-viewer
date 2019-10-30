using Gevlee.CompanyViewer.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Configurations
{
    internal class CompanySearchRequestConfiguration : IEntityTypeConfiguration<CompanySearchRequest>
    {
        public void Configure(EntityTypeBuilder<CompanySearchRequest> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.SearchPhrase).IsRequired();
            builder.Property(x => x.RequestData).IsRequired();
        }
    }
}
