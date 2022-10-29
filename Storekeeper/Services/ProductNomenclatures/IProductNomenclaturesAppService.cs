using Storekeeper.Models;
using System.Linq;

namespace Storekeeper.Services.ProductNomenclatures
{
    public interface IProductNomenclaturesAppService
    {
        IQueryable<ProductNomenclature> GetAll();

        ProductNomenclature GetById(int id);

        void Create(ProductNomenclature input);

        void Update(ProductNomenclature input);

        void Delete(int id);
    }
}
