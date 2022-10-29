using Storekeeper.Models;
using Storekeeper.Repositories;
using System.Linq;

namespace Storekeeper.Services.ProductNomenclatures
{
    public class ProductNomenclaturesAppService : IProductNomenclaturesAppService
    {
        private readonly IRepository<ProductNomenclature>_productNomenclaturerepository;

        public ProductNomenclaturesAppService(IRepository<ProductNomenclature> productNomenclaturerepository)
        {
            _productNomenclaturerepository = productNomenclaturerepository;
        }

        public IQueryable<ProductNomenclature> GetAll()
        {
            var results = _productNomenclaturerepository.GetAll();
            return results;
        }

        public ProductNomenclature GetById(int id)
        {
            var result = _productNomenclaturerepository.GetById(id);
            return result;
        }

        public void Create(ProductNomenclature input)
        {
            _productNomenclaturerepository.Create(input);
        }

        public void Update(ProductNomenclature input)
        {
            _productNomenclaturerepository.Update(input);
        }

        public void Delete(int id)
        {
            _productNomenclaturerepository.Delete(id);
        }
    }
}
