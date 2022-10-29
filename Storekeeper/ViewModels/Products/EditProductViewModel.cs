using Storekeeper.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Storekeeper.ViewModels.Products
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        /// <summary>
        ///  Product name
        /// </summary>
        [Required]
        public int ProductNomenclatureId { get; set; }

        /// <summary>
        /// Склад 
        /// </summary>
        [Required]
        public int StorehouseId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Sum { get; set; }

        [Required]
        public int TypeOperationId { get; set; }

        public IQueryable<ProductNomenclature> ProductNomenclatureList { get; set; }

        public IQueryable<Storehouse> StorehousesList { get; set; }
    }
}
