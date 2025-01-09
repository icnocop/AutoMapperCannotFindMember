using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Profiles;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(mvcOptions =>
            {
                mvcOptions.EnableEndpointRouting = false;
            })
            .AddOData(opt =>
            {
                opt.EnableQueryFeatures();
                opt.AddRouteComponents("api", GetEdmModel());
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
                options.EnableSensitiveDataLogging();
            });

            services.AddAutoMapper(typeof(PersonProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<PersonDto>("People");
            builder.EntitySet<ChildDto>("Child");

            return builder.GetEdmModel();
        }
    }
}
