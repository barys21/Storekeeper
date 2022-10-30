using Storekeeper.Models;
using System.Linq;

namespace Storekeeper.Services.TypeOperations
{
    public interface ITypeOperationsAppService
    {
        IQueryable<TypeOperation> GetAll();

        void Create(TypeOperation input);
    }
}
