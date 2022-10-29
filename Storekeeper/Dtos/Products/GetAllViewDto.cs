using System.Collections.Generic;

namespace Storekeeper.Dtos.Products
{
    public class GetAllViewDto
    {
        public List<ProductDto> ProductArrival { get; set; }

        public List<ProductDto> ProductWriteOff { get; set; }
    }
}
