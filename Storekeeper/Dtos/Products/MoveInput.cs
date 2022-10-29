using System.ComponentModel.DataAnnotations;

namespace Storekeeper.Dtos.Products
{
    public class MoveInput
    {
        /// <summary>
        /// Склад
        /// </summary>
        public int StorehouseId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int ParentProductId { get; set; }

        /// <summary>
        ///  Тип операций
        /// </summary>
        public int TypeId { get; set; }
    }
}
