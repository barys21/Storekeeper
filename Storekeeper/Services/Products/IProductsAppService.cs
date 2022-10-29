using Storekeeper.Dtos.Products;
using Storekeeper.Models;

namespace Storekeeper.Services.Products
{
    public interface IProductsAppService
    {
        GetAllViewDto GetAll();

        GetProductViewDto GetById(int id);

        void Create(Product input);

        void Update(Product input);

        void Delete(int id);

        void WriteOff(WriteOffInput input);

        int GetBalance(int id);

        void Move(MoveInput input);
    }
}
