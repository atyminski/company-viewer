using System;
using Xunit;
using Gevlee.CompanyViewer.Core.Application.Companies.Queries;

namespace Gevlee.CompanyViewer.Tests.Application.Companies.Queries
{
    public class FindCompanyQueryHandlerTest
    {
        [Fact]
        public void Test1()
        {
            var handler = CreateHandler();
        }

        private FindCompanyQueryHandler CreateHandler()
        {
            return new FindCompanyQueryHandler();
        }
    }
}
