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

            if (dbContext.Products.ToList().Count() == 0)
            {
                var ProductNomenclature = dbContext.ProductNomenclatures.First();
                var Storehouse = dbContext.Storehouses.First();
                if (ProductNomenclature == null || Storehouse == null) return;

                // приход
                var productIn = new Product()
                {
                    ProductNomenclatureId = ProductNomenclature.Id,
                    StorehouseId = Storehouse.Id,
                    Quantity = 5,
                    Price = 15,
                    Sum = 75
                };

                dbContext.Add(productIn);
                dbContext.SaveChanges();

                // приход
                var productIn2 = new Product()
                {
                    ProductNomenclatureId = ProductNomenclature.Id,
                    StorehouseId = Storehouse.Id,
                    Quantity = 7,
                    Price = 20,
                    Sum = 140
                };

                dbContext.Add(productIn2);
                dbContext.SaveChanges();

                // приход
                var productIn3 = new Product()
                {
                    ProductNomenclatureId = ProductNomenclature.Id,
                    StorehouseId = Storehouse.Id,
                    Quantity = 17,
                    Price = 50,
                    Sum = 850
                };

                dbContext.Add(productIn3);
                dbContext.SaveChanges();
            }
        }
    }
}
