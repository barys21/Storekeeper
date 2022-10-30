using Microsoft.EntityFrameworkCore;
using Storekeeper.Data;
using Storekeeper.Models;
using Storekeeper.Repositories;
using Storekeeper.Services.ProductNomenclatures;
using Storekeeper.Services.Products;
using Storekeeper.Services.Storehouses;
using Storekeeper.Services.TypeOperations;
using System.Collections.Generic;
using System.Linq;

namespace Storekeeper.Tests
{
    public class TestHelper
    {
        public readonly StorekeeperDbContext dbContext;
        public ProductsAppService productsAppService;
        public ProductNomenclaturesAppService productNomenclaturesAppService;
        public StorehousesAppService storehousesAppService;
        public TypeOperationsAppService typeOperationsAppService;

        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<StorekeeperDbContext>();
            builder.UseInMemoryDatabase(databaseName: "StorekeeperDbForTest");

            var dbContextOptions = builder.Options;
            dbContext = new StorekeeperDbContext(dbContextOptions);
            // Delete existing db before creating a new one
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            productsAppService = GetProductsAppService();
            productNomenclaturesAppService = GetProductNomenclaturesAppService();
            storehousesAppService = GetStorehousesAppService();
            typeOperationsAppService = GetTypeOperationsAppService();
        }

        public ProductsAppService GetProductsAppService()
        {
            var repo = new Repository<Product>(dbContext);
            return new ProductsAppService(repo);
        }

        public ProductNomenclaturesAppService GetProductNomenclaturesAppService()
        {
            var repo = new Repository<ProductNomenclature>(dbContext);
            return new ProductNomenclaturesAppService(repo);
        }

        public StorehousesAppService GetStorehousesAppService()
        {
            var repo = new Repository<Storehouse>(dbContext);
            return new StorehousesAppService(repo);
        }

        public TypeOperationsAppService GetTypeOperationsAppService()
        {
            var repo = new Repository<TypeOperation>(dbContext);
            return new TypeOperationsAppService(repo);
        }

        #region AddItems

        public void AddItemStorehouse()
        {
            var storeHouse = new Storehouse
            {
                Name = "Склад 1"
            };

            if (storehousesAppService.GetAll().Count() > 0) return;
            storehousesAppService.Create(storeHouse);
        }

        public void AddItemProductNomenclature()
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

            if (productNomenclaturesAppService.GetAll().Count() > 0) return;
            foreach (var item in items)
            {
                productNomenclaturesAppService.Create(item);
            }
        }

        public void AddItemTypeOperation()
        {
            List<TypeOperation> items = new List<TypeOperation>()
            {
                new TypeOperation() { Name = "Приход" },
                new TypeOperation() { Name = "Перемещение" },
                new TypeOperation() { Name = "Списание" }
            };

            if (typeOperationsAppService.GetAll().Count() > 0) return;
            foreach (var item in items)
            {
                typeOperationsAppService.Create(item);
            }
        }

        public void AddItemProduct()
        {
            AddItemStorehouse();
            AddItemProductNomenclature();
            AddItemTypeOperation();
            List<Product> items = new List<Product>()
                {
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = 1,
                        StorehouseId = 1,
                        Quantity = 5,
                        Price = 15,
                        Sum = 75,
                        TypeOperationId = 1
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = 2,
                        StorehouseId = 1,
                        Quantity = 7,
                        Price = 20,
                        Sum = 140,
                        TypeOperationId = 1
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = 3,
                        StorehouseId = 1,
                        Quantity = 17,
                        Price = 50,
                        Sum = 850,
                        TypeOperationId = 1
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = 4,
                        StorehouseId = 1,
                        Quantity = 3,
                        Price = 50,
                        Sum = 150,
                        TypeOperationId = 1
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = 5,
                        StorehouseId = 1,
                        Quantity = 9,
                        Price = 750,
                        Sum = 6750,
                        TypeOperationId = 1
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = 6,
                        StorehouseId = 1,
                        Quantity = 4,
                        Price = 400,
                        Sum = 1600,
                        TypeOperationId = 1
                    },
                    // приход
                    new Product()
                    {
                        ProductNomenclatureId = 7,
                        StorehouseId = 1,
                        Quantity = 2,
                        Price = 2500,
                        Sum = 5000,
                        TypeOperationId = 1
                    }
                };

            if (productsAppService.GetAll().ProductArrival.Count() > 0) return;
            foreach (var item in items)
            {
                productsAppService.Create(item);
            }
        }
    }

    #endregion
}
