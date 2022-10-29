using Storekeeper.Models;
using Storekeeper.Repositories;
using System.Linq;

namespace Storekeeper.Services.TypeOperations
{
    public class TypeOperationsAppService : ITypeOperationsAppService
    {
        private readonly IRepository<TypeOperation> _typeOperationrepository;

        public TypeOperationsAppService(IRepository<TypeOperation> typeOperationrepository)
        {
            _typeOperationrepository = typeOperationrepository;
        }

        public IQueryable<TypeOperation> GetAll()
        {
            var results = _typeOperationrepository.GetAll();
            return results;
        }
    }
}
