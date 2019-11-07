using Gevlee.CompanyViewer.Core.Common.Interfaces;
using Gevlee.CompanyViewer.Core.Infrastructure.Persistence;
using Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Seed;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gevlee.CompanyViewer.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterDatabaseDependencies(services, configuration);

            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            return services;
        }

        private static void RegisterDatabaseDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CompaniesDbContext, PostgresCompaniesDbContext>(builder => builder.UseNpgsql(configuration["ConnectionString"]));
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            services.AddTransient<IDatabaseSeeder, CompaniesSeeder>();
        }
    }
}
