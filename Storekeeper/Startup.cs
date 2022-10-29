using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Storekeeper.Common;
using Storekeeper.Data;
using Storekeeper.Repositories;
using Storekeeper.Services.ProductNomenclatures;
using Storekeeper.Services.Products;
using Storekeeper.Services.Storehouses;
using Storekeeper.Services.TypeOperations;

namespace Storekeeper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StorekeeperDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Test")));

            services.AddControllersWithViews();

            #region Include services

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddScoped<IStorehousesAppService, StorehousesAppService>();
            services.AddScoped<IProductNomenclaturesAppService, ProductNomenclaturesAppService>();
            services.AddScoped<IProductsAppService, ProductsAppService>();
            services.AddScoped<ITypeOperationsAppService, TypeOperationsAppService>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            InitializeDb.Seed(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
