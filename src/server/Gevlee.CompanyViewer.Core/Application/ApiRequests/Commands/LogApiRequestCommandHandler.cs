using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gevlee.CompanyViewer.Core.Domain.Entities;
using Gevlee.CompanyViewer.Core.Infrastructure.Persistence;
using MediatR;

namespace Gevlee.CompanyViewer.Core.Application.ApiRequests.Commands
{
    public class LogApiRequestCommandHandler : IRequestHandler<LogApiRequestCommand>
    {
        private readonly CompaniesDbContext dbContext;

        public LogApiRequestCommandHandler(CompaniesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(LogApiRequestCommand request, CancellationToken cancellationToken)
        {
            dbContext.Add(new ApiRequest()
            {
                Id = request.Id,
                Timestamp = request.Timespan,
                RequestData = JsonSerializer.Serialize(request.RequestData)
            });

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
