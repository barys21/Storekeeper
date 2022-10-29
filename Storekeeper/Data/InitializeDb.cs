using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Storekeeper.Models;
using System.Collections.Generic;
using System.Linq;

namespace Storekeeper.Data
{
    public static class InitializeDb
    {        
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StorekeeperDbContext>();

            if (dbContext.TypeOperations.ToList().Count() == 0)
            {
                var item = new TypeOperation() { Name = "Приход" };
                dbContext.Add(item);
                dbContext.SaveChanges();

                var item2 = new TypeOperation() { Name = "Перемещ" };
                dbContext.Add(item2);
                dbContext.SaveChanges();

                var item3 = new TypeOperation() { Name = "Списание" };
                dbContext.Add(item3);
                dbContext.SaveChanges();
            }

            if (dbContext.Storehouses.ToList().Count() == 0)
            {
                for (int i = 1; i < 4; i++)
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
                List<ProductNomenclature> items = new List<ProductNomenclature>() 
                { 
                    new ProductNomenclature() { Name = "Ручка" },
                    new ProductNomenclature() { Name = "Карандаш" },
                    new ProductNomenclature() { Name = "Ведро" },
                    new ProductNomenclature() { Name = "Тетрадь" },
                    new ProductNomenclature() { Name = "Лопата" },
                    new ProductNomenclature() { Name = "Рюкзак" },
                    new ProductNomenclature() { Name = "Рубашка" },
                };

                dbContext.AddRange(items);
                dbContext.SaveChanges();
            }

            if (dbContext.Products.ToList().Count() == 0)
            {
                var ProductNomenclatures = dbContext.ProductNomenclatures.ToList();
                var Storehouse = dbContext.Storehouses.First();
                var TypeOperations = dbContext.TypeOperations.First(e => e.Name == "Приход");
                if (ProductNomenclatures == null || Storehouse == null) return;

                List<Product> items = new List<Product>()
                {
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Ручка").First().Id,
                        StorehouseId = Storehouse.Id,
                        Quantity = 5,
                        Price = 15,
                        Sum = 75,
                        TypeOperationId = TypeOperations.Id
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Карандаш").First().Id,
                        StorehouseId = Storehouse.Id,
                        Quantity = 7,
                        Price = 20,
                        Sum = 140,
                        TypeOperationId = TypeOperations.Id
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Ведро").First().Id,
                        StorehouseId = Storehouse.Id,
                        Quantity = 17,
                        Price = 50,
                        Sum = 850,
                        TypeOperationId = TypeOperations.Id
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Тетрадь").First().Id,
                        StorehouseId = Storehouse.Id,
                        Quantity = 3,
                        Price = 50,
                        Sum = 150,
                        TypeOperationId = TypeOperations.Id
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Лопата").First().Id,
                        StorehouseId = Storehouse.Id,
                        Quantity = 9,
                        Price = 750,
                        Sum = 6750,
                        TypeOperationId = TypeOperations.Id
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Рюкзак").First().Id,
                        StorehouseId = Storehouse.Id,
                        Quantity = 4,
                        Price = 400,
                        Sum = 1600,
                        TypeOperationId = TypeOperations.Id
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Рубашка").First().Id,
                        StorehouseId = Storehouse.Id,
                        Quantity = 2,
                        Price = 2500,
                        Sum = 5000,
                        TypeOperationId = TypeOperations.Id
                    }
                };                

                dbContext.AddRange(items);
                dbContext.SaveChanges();
            }
        }
    }
}
