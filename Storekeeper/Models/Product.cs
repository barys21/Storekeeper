using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storekeeper.Models
{
    public class Product
    {
        public int Id { get; set; }

        /// <summary>
        ///  Product name
        /// </summary>
        public int ProductNomenclatureId { get; set; }

        [ForeignKey("ProductNomenclatureId")]
        public ProductNomenclature ProductNomenclatureFk { get; set; }

        /// <summary>
        /// Склад 
        /// </summary>
        public int StorehouseId { get; set; }

        [ForeignKey("StorehouseId")]
        public Storehouse StorehouseFk { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int Sum { get; set; }

        [ForeignKey("ProductFk")]
        public int? ParentProductId { get; set; }
        public Product ProductFk { get; set; }
        public ICollection<Product> ProductMoves { get; set; }

    }
}
