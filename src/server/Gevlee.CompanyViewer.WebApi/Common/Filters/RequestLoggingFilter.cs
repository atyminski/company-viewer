using Gevlee.CompanyViewer.Core.Application.ApiRequests.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Gevlee.CompanyViewer.WebApi.Common.Filters
{
    public class RequestLoggingFilter : IResourceFilter
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger logger;

        public RequestLoggingFilter(IServiceProvider serviceProvider, ILogger<RequestLoggingFilter> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            LogRequestAsync(context.HttpContext);
        }

        private async void LogRequestAsync(HttpContext context)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                await mediator.Send(new LogApiRequestCommand
                {
                    Id = context.TraceIdentifier,
                    Timespan = DateTime.UtcNow,
                    RequestData = new
                    {
                        Path = context.Request.Path.HasValue ? context.Request.Path.Value : null,
                        context.Request.Method,
                        RemoteAddress = context.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                        QueryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : null,
                        Headers = context.Request.Headers.ToDictionary(x => x.Key, x => x.Value),
                    }
                });
            }
            catch (Exception e)
            {
                logger.LogWarning(e, "Error occured during request logging.");
            }
        }
    }
}
