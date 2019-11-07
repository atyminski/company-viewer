using MediatR;
using System;

namespace Gevlee.CompanyViewer.Core.Application.ApiRequests.Commands
{
    public class LogApiRequestCommand : IRequest
    {
        public string Id { get; set; }

        public DateTime Timespan { get; set; }

        public object RequestData { get; set; }
    }
}
