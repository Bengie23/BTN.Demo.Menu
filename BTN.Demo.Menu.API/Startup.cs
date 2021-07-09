using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BTN.Demo.Menu.Infra.Startup;
using BTN.Demo.Menu.Domain.Requests;
using BTN.Demo.Menu.Infra.Configuration;
using BTN.Demo.Menu.Services;

namespace BTN.Demo.Menu
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
            services.RegisterEvaluators();

            services.RegisterRepositories();

            services.RegisterServices();

            services.AddControllers();

            services.SeedDrinks().GetAwaiter().GetResult();
            services.SeedCountries().GetAwaiter().GetResult();

            var countryOptions = new CountryConfigurationOptions();
            Configuration.GetSection(CountryConfigurationOptions.CountryConfigurationKey).Bind(countryOptions);
            services.AddSingleton(countryOptions);
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
