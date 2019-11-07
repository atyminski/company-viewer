using Gevlee.CompanyViewer.Core.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Seed
{
    public abstract class SeederBase : IDatabaseSeeder
    {
        public virtual string Name => GetType().Name;

        public bool AlreadySeeded(CompaniesDbContext dbContext)
        {
            return !(SeedingRequired?.Invoke(dbContext)).GetValueOrDefault();
        }

        public void Seed(CompaniesDbContext dbContext)
        {
            dbContext.AddRange(Data);
            dbContext.SaveChanges();
        }

        protected abstract Func<CompaniesDbContext, bool> SeedingRequired { get; }

        protected abstract IEnumerable<object> Data { get; }
    }
}
