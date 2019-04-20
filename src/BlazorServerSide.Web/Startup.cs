using BlazorServerSide.Core.Data;
using BlazorServerSide.Core.Implementation.Services;
using BlazorServerSide.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorServerSide.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var connectionString = _configuration.GetConnectionString("BlazorServerSide");
            services.AddDbContext<BlazorServerSideContext>(options => options.UseSqlServer(connectionString));

            //add scoped instances of the services so that we get a new one for each request.
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICitiesService, CitiesService>();

            services.AddSingleton<IWeatherForecastService>(new WeatherForecastService());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
