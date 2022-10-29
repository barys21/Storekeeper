using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Storekeeper.Models;
using System.Linq;

namespace Storekeeper.Data
{
    public static class InitializeDb
    {        
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StorekeeperDbContext>();


            if (dbContext.Storehouses.ToList().Count() == 0)
            {
                for (int i = 1; i < 3; i++)
                {
                    var storehouse = new Storehouse()
                    {
                        Name = $"Скдал {i}"
                    };

                    dbContext.Add(storehouse);
                    dbContext.SaveChanges();
                }     
            }

            if (dbContext.ProductNomenclatures.ToList().Count() == 0)
            {
                for (int i = 1; i < 3; i++)
                {
                    var productNomenclature = new ProductNomenclature()
                    {
                        Name = $"Товар {i}"
                    };

                    dbContext.Add(productNomenclature);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
