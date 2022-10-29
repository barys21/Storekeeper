using Storekeeper.Dtos.Products;
using Storekeeper.Models;
using System.Collections.Generic;

namespace Storekeeper.Services.Products
{
    public interface IProductsAppService
    {
        List<ProductDto> GetAll();

        Product GetById(int id);

        void Create(Product input);

        void Update(Product input);

        void Delete(int id);
    }
}
