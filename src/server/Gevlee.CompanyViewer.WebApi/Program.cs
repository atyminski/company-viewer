using Gevlee.CompanyViewer.Core.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Core;
using Serilog.Filters;

namespace Gevlee.CompanyViewer.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogging();

            var builder = CreateHostBuilder(args).Build();
            builder.Services.GetRequiredService<IDatabaseInitializer>().EnsureInitialized();
            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(x => x.AddEnvironmentVariables(prefix: "COMPANYVIEWER_"));
                    webBuilder.UseStartup<Startup>();
                });

        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Logger(config =>
                    config.Filter.ByExcluding(Matching.FromSource("Microsoft.EntityFrameworkCore.Database.Command"))
                    .WriteTo
                    .ColoredConsole(
                    LogEventLevel.Information,
                    "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                )
                .WriteTo.RollingFile("logs/server-{Date}.log", LogEventLevel.Debug)
                .CreateLogger();
        }
    }
}
