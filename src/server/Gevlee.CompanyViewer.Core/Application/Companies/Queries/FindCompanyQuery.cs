using System;
using MediatR;

namespace Gevlee.CompanyViewer.Core.Application.Companies.Queries
{
    public class FindCompanyQuery : IRequest<FoundCompany>
    {
        public FindCompanyQuery(string searchPhrase)
        {
            SearchPhrase = searchPhrase;
        }
        
        public string SearchPhrase { get; set; }
    }
}
