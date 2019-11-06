using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gevlee.CompanyViewer.Core.Domain.Entities;
using Gevlee.CompanyViewer.Core.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gevlee.CompanyViewer.Core.Application.Companies.Queries
{
    public class FindCompanyQueryHandler : IRequestHandler<FindCompanyQuery, FoundCompany>
    {
        private readonly CompaniesDbContext dbContext;

        public FindCompanyQueryHandler(CompaniesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<FoundCompany> Handle(FindCompanyQuery query, CancellationToken cancellationToken)
        {
            var preparedPhrase = MakePhraseQueryFriendly(query.SearchPhrase);
            var result = dbContext.Set<Company>()
                .Where(c =>
                    c.TaxNumber == preparedPhrase ||
                    c.NationalBusinessRegistryNumber == preparedPhrase ||
                    c.NationalCourtRegisterNumber == preparedPhrase)
                .Include(x => x.Address)
                .Select(x => new FoundCompany
                {
                    Id = x.Id,
                    Name = x.Name,
                    Street = x.Address.Street,
                    HouseNumber = x.Address.HouseNumber,
                    AppartmentNumber = x.Address.AppartmentNumber,
                    PostalCode = x.Address.PostalCode,
                    City = x.Address.City,
                })
                .FirstOrDefault();
             
            return Task.FromResult(result);
        }

        private string MakePhraseQueryFriendly(string searchPhrase)
        {
            return new string(searchPhrase.Where(x => char.IsDigit(x)).ToArray());
        }
    }
}