using Storekeeper.Models;
using System.Linq;

namespace Storekeeper.Services.Storehouses
{
    public interface IStorehousesAppService
    {
        IQueryable<Storehouse> GetAll();

        Storehouse GetById(int id);

        void Create(Storehouse input);

        void Update(Storehouse input);

        void Delete(int id);
    }
}
