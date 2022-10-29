using Storekeeper.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Storekeeper.ViewModels.Products
{
    public class CreateProductViewModel
    {
        /// <summary>
        ///  Product name
        /// </summary>
        public int ProductNomenclatureId { get; set; }

        /// <summary>
        /// Склад 
        /// </summary>
        public int StorehouseId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Sum { get; set; }

        public IQueryable<ProductNomenclature> ProductNomenclatureList { get; set; }

        public IQueryable<Storehouse> StorehousesList { get; set; }
    }
}
