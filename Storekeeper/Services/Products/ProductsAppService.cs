using Microsoft.EntityFrameworkCore;
using Storekeeper.Dtos.Products;
using Storekeeper.Models;
using Storekeeper.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Storekeeper.Services.Products
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IRepository<Product> _productrepository;

        public ProductsAppService(IRepository<Product> productrepository)
        {
            _productrepository = productrepository;
        }

        public GetAllViewDto GetAll()
        {
            var dbList = _productrepository.GetAll()
                .Include(e => e.ProductNomenclatureFk)
                .Include(e => e.StorehouseFk)
                .Include(e => e.ProductFk)
                .Include(e => e.TypeOperationFk);

            var arrivals = new List<ProductDto>();
            var writeOffs = new List<ProductDto>();
            var productArrivals = dbList.Where(e => e.Quantity != 0 && e.TypeOperationFk.Name == "Приход").ToList();
            var productWriteOffs = dbList.Where(e => e.Quantity != 0 && e.TypeOperationFk.Name == "Списание").ToList();
            
            // список приходов
            foreach (var item in productArrivals)
            {
                var res = new ProductDto
                {
                    Id = item.Id,
                    ProductNomenclatureName = item.ProductNomenclatureFk.Name,
                    StorehouseName = item.StorehouseFk.Name,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Sum = item.Sum,
                    ParentProductName = item.ProductFk?.ProductNomenclatureFk?.Name
                };

                arrivals.Add(res);
            }

            // список списанных товаров
            foreach (var item in productWriteOffs)
            {
                var res = new ProductDto
                {
                    Id = item.Id,
                    ProductNomenclatureName = item.ProductNomenclatureFk.Name,
                    StorehouseName = item.StorehouseFk.Name,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Sum = item.Sum,
                    ParentProductName = item.ProductFk?.ProductNomenclatureFk?.Name
                };

                writeOffs.Add(res);
            }
            var result = new GetAllViewDto
            {
                ProductArrival = arrivals,
                ProductWriteOff = writeOffs
            };

            return result;
        }

        public GetProductViewDto GetById(int id)
        {
            var product = _productrepository.GetAll().Include(e => e.ProductNomenclatureFk).Where(e => e.Id == id).FirstOrDefault();
            if (product == null) return new GetProductViewDto();

            var result = new GetProductViewDto
            {
                Product = product,
                ProductNomenclatureName = product.ProductNomenclatureFk.Name
            };

            return result;
        }

        public void Create(Product input)
        {
            _productrepository.Create(input);
        }

        public void Update(Product input)
        {
            _productrepository.Update(input);
        }

        public void Delete(int id)
        {
            _productrepository.Delete(id);
        }

        public void WriteOff(WriteOffInput input)
        {
            var dbProduct = _productrepository.GetById(input.ParentProductId);
            if (dbProduct == null) return;

            var newProduct = new Product
            {
                ProductNomenclatureId = dbProduct.ProductNomenclatureId,
                StorehouseId = input.StorehouseId,
                Quantity = input.Quantity,
                Price = dbProduct.Price,
                Sum = dbProduct.Price * input.Quantity,
                ParentProductId = input.ParentProductId,
                TypeOperationId = input.TypeId
            };

            _productrepository.Create(newProduct);

            dbProduct.Quantity = dbProduct.Quantity - input.Quantity;
            _productrepository.Update(dbProduct);
        }

        public int GetBalance(int id)
        {
            var product = _productrepository.GetAll()
                .Include(e => e.ProductFk)
                .Include(e => e.ProductMoves)
                .Where(e => e.Id == id && e.ParentProductId == null).FirstOrDefault();

            if(product == null) return 0;

            var quantity = product.Quantity;
            foreach (var item in product.ProductMoves)
            {
                quantity = quantity - item.Quantity;
            }

            return quantity;
        }
    }
}
