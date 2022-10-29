using Storekeeper.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Storekeeper.ViewModels.Products
{
    public class MoveViewModel
    {
        /// <summary>
        /// Склад 
        /// </summary>
        public int StorehouseId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public int? ParentProductId { get; set; }

        public string ProductName { get; set; }

        public int Balance { get; set; }

        public IQueryable<Storehouse> StorehousesList { get; set; }
    }
}
