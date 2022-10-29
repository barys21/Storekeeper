using Microsoft.EntityFrameworkCore;
using Storekeeper.Dtos.Products;
using Storekeeper.Models;
using Storekeeper.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Storekeeper.Services.Products
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IRepository<Product> _productrepository;

        public ProductsAppService(IRepository<Product> productrepository)
        {
            _productrepository = productrepository;
        }

        public List<ProductDto> GetAll()
        {
            var products = _productrepository.GetAll()
                .Include(e => e.ProductNomenclatureFk)
                .Include(e => e.StorehouseFk)
                .Include(e => e.ProductFk);

            var results = new List<ProductDto>();
            foreach (var item in products)
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

                results.Add(res);
            }

            return results;
        }

        public Product GetById(int id)
        {
            var result = _productrepository.GetById(id);
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
    }
}
