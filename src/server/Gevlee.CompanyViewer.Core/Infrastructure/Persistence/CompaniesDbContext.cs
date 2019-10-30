using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence
{
    public class CompaniesDbContext : DbContext
    {
        public CompaniesDbContext()
        {
        }

        public CompaniesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
