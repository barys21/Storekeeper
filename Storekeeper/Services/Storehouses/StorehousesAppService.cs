using Storekeeper.Models;
using Storekeeper.Repositories;
using System.Linq;

namespace Storekeeper.Services.Storehouses
{
    public class StorehousesAppService : IStorehousesAppService
    {
        private readonly IRepository<Storehouse> _storehouseRepository;

        public StorehousesAppService(IRepository<Storehouse> storehouseRepository)
        {
            _storehouseRepository = storehouseRepository;
        }

        public IQueryable<Storehouse> GetAll()
        {
            var results = _storehouseRepository.GetAll();
            return results;
        }

        public Storehouse GetById(int id)
        {
            var result = _storehouseRepository.GetById(id);
            return result;
        }

        public void Create(Storehouse input)
        {
            _storehouseRepository.Create(input);
        }

        public void Update(Storehouse input)
        {
            _storehouseRepository.Update(input);
        }

        public void Delete(int id)
        {
            _storehouseRepository.Delete(id);
        }
    }
}
