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
        private const string API_NAME = "BTN.DrinksMenuService.Demo";
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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = API_NAME, Version = "v1" });
            });

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

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", API_NAME);
            });

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
