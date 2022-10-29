namespace Storekeeper.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }

        /// <summary>
        ///  Product name
        /// </summary>
        public string ProductNomenclatureName { get; set; }

        /// <summary>
        /// Склад
        /// </summary>
        public string StorehouseName { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int Sum { get; set; }

        public string ParentProductName { get; set; }
    }
}
