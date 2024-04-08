using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftwareCatalogBackend;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;


namespace SoftwareCatalogBackend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<SoftwareCatalogDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add other services as needed
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline
        }

        // This method gets called by the runtime in development mode. Use this method to configure the development environment.
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // Using a separate method for configuring services during development
            ConfigureServices(services);
        }

        // This method gets called by the runtime in production mode. Use this method to configure the production environment.
        public void ConfigureProductionServices(IServiceCollection services)
        {
            // Using a separate method for configuring services during production
            ConfigureServices(services);
        }
    }
}
