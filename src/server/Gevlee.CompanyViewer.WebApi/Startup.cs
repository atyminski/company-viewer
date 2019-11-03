using FluentValidation.AspNetCore;
using Gevlee.CompanyViewer.Core;
using Gevlee.CompanyViewer.WebApi.Common.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gevlee.CompanyViewer.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCore(Configuration);
            services.AddControllers(options =>
                    {
                        options.Filters.Add(new ModelStateFilter());
                    }).AddFluentValidation(fv =>
                        {
                            fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                            fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
