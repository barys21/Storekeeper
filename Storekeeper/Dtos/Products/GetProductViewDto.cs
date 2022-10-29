using Storekeeper.Models;

namespace Storekeeper.Dtos.Products
{
    public class GetProductViewDto
    {
        public Product Product { get; set; }

        public string ProductNomenclatureName { get; set; }
    }
}
