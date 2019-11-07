using Gevlee.CompanyViewer.Core.Infrastructure.Persistence;

namespace Gevlee.CompanyViewer.Core.Common.Interfaces
{
    public interface IDatabaseSeeder
    {
        string Name { get; }

        void Seed(CompaniesDbContext dbContext);

        bool AlreadySeeded(CompaniesDbContext dbContext);
    }
}
