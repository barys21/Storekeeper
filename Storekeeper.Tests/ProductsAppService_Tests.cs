using Shouldly;
using Storekeeper.Dtos.Products;
using System.Linq;
using Xunit;

namespace Storekeeper.Tests
{
    public class ProductsAppService_Tests : TestHelper
    {
        [Fact]
        public void TestGetAll()
        {
            //Act
            AddItemProduct();
            var result = productsAppService.GetAll();

            //Assert
            result.ProductArrival.Count().ShouldBe(7);
        }

        [Fact]
        public void TestGetById()
        {
            //Act
            AddItemProduct();
            var result = productsAppService.GetById(1);

            //Assert
            result.ProductNomenclatureName.ShouldBe("Ручка");
        }

        [Fact]
        public void TestWriteOff()
        {
            // Списание из этой записи
            //Product()
            //{
            //    ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Ручка").First().Id,
            //    StorehouseId = Storehouse.Id,
            //    Quantity = 5,
            //    Price = 15,
            //    Sum = 75,
            //    TypeOperationId = TypeOperations.Id
            //}

            //Act
            AddItemProduct();
            var writeOff = new WriteOffInput
            {
                StorehouseId = 1,
                Quantity = 3,
                ParentProductId = 1,
                TypeId = 3 // списание
            };

            productsAppService.WriteOff(writeOff);
            var resultWriteOff = productsAppService.GetAll().ProductWriteOff.First();
            var resultArrival = productsAppService.GetAll().ProductArrival.Where(e => e.Id == 1).First();

            //Assert
            resultWriteOff.Quantity.ShouldBe(3);
            resultArrival.Quantity.ShouldBe(2);
        }

        [Fact]
        public void TestMove()
        {
            // Перемещ из этой записи
            //Product()
            //{
            //    ProductNomenclatureId = ProductNomenclatures.Where(e => e.Name == "Ручка").First().Id,
            //    StorehouseId = Storehouse.Id,
            //    Quantity = 5,
            //    Price = 15,
            //    Sum = 75,
            //    TypeOperationId = TypeOperations.Id
            //}

            AddItemProduct();
            var move = new MoveInput
            {
                StorehouseId = 1,
                Quantity = 3,
                ParentProductId = 1,
                TypeId = 2 // перемещ
            };

            productsAppService.Move(move);
            var resultMove = productsAppService.GetAll().ProductMove.First();
            var resultArrival = productsAppService.GetAll().ProductArrival.Where(e => e.Id == 1).First();

            //Assert
            resultMove.Quantity.ShouldBe(3);
            resultArrival.Quantity.ShouldBe(2);
        }
    }
}
