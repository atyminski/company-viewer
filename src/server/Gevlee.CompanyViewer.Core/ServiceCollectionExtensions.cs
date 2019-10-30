using Gevlee.CompanyViewer.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gevlee.CompanyViewer.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CompaniesDbContext, PostgresCompaniesDbContext>(builder => builder.UseNpgsql(configuration["ConnectionString"]));
            return services;
        }
    }
}
