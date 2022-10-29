using Storekeeper.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Storekeeper.ViewModels.Products
{
    public class WriteOffViewModel
    {
        /// <summary>
        /// Склад 
        /// </summary>
        public int StorehouseId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int? ParentProductId { get; set; }

        public string ProductName { get; set; }

        public int Balance { get; set; }

        public IQueryable<Storehouse> StorehousesList { get; set; }
    }
}
