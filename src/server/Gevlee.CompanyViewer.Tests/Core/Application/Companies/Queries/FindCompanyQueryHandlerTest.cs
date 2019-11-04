using Xunit;
using Gevlee.CompanyViewer.Core.Application.Companies.Queries;
using Gevlee.CompanyViewer.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Gevlee.CompanyViewer.Core.Domain.Entities;
using System.Threading;
using System;

namespace Gevlee.CompanyViewer.Tests.Application.Companies.Queries
{
    public class FindCompanyQueryHandlerTest : IDisposable
    {
        public CompaniesDbContext DbContext { get; }

        public FindCompanyQueryHandlerTest()
        {
            var options = new DbContextOptionsBuilder<CompaniesDbContext>().UseInMemoryDatabase(nameof(FindCompanyQueryHandlerTest)).Options;
            DbContext = new CompaniesDbContext(options);
            AddTestCompanies();
        }

        [Theory]
        [InlineData("715382844", 1)]
        [InlineData("PL715382844", 1)]
        [InlineData("PL715-382-844", 1)]
        [InlineData("715-382-844", 1)]
        [InlineData("PL-715-382-844", 1)]
        [InlineData("0000111111", 1)]
        [InlineData("1579330179", 1)]
        public async void Handle_ShouldReturn_ValidResult(string searchPhrase, int expectedResultId)
        {
            var handler = new FindCompanyQueryHandler(DbContext);

            var result = await handler.Handle(new FindCompanyQuery(searchPhrase), CancellationToken.None);

            Assert.Equal(expectedResultId, result.Id);
        }

        private void AddTestCompanies()
        {
            DbContext.Add(new Company
            {
                Id = 1,
                Name = "Test Company 1",
                Address = new Address(),
                NationalBusinessRegistryNumber = "715382844",
                NationalCourtRegisterNumber = "0000111111",
                TaxNumber = "1579330179",
            });
            DbContext.Add(new Company
            {
                Id = 2,
                Name = "Test Company 2",
                Address = new Address(),
                NationalBusinessRegistryNumber = "536849520",
                NationalCourtRegisterNumber = "0000111112",
                TaxNumber = "1196395597",
            });
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }
    }
}
