using Gevlee.CompanyViewer.Core.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<DatabaseInitializer> logger;

        public DatabaseInitializer(IServiceProvider serviceProvider, ILogger<DatabaseInitializer> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public void EnsureInitialized()
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CompaniesDbContext>();

            var seeders = scope.ServiceProvider.GetServices<IDatabaseSeeder>()
                ?.Where(x => !x.AlreadySeeded(dbContext));

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                logger.LogInformation("Database needs update, executing...");
                dbContext.Database.Migrate();
            }

            if(seeders != null && seeders.Any())
            {
                logger.LogInformation("Seeding database...");
                foreach (var seeder in seeders.Where(x => !x.AlreadySeeded(dbContext)))
                {
                    logger.LogInformation("Executing {Seeder}", seeder.Name);
                    seeder.Seed(dbContext);
                }
            }
        }
    }
}
