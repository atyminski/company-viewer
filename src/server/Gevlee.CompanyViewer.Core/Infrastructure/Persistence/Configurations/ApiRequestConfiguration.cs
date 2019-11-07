using Gevlee.CompanyViewer.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Configurations
{
    internal class ApiRequestConfiguration : IEntityTypeConfiguration<ApiRequest>
    {
        public void Configure(EntityTypeBuilder<ApiRequest> builder)
        {
            builder.Property(x => x.Id)
                .HasMaxLength(255);
            builder.Property(x => x.RequestData)
                .IsRequired()
                .HasColumnType("jsonb");
            builder.Property(x => x.Timestamp)
                .IsRequired();
        }
    }
}
