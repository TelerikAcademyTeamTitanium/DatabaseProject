namespace FurnitureFactory.Model
{
    using System;

    public class ProductsPerOrder
    {
        public int ProductsPerOrderId { get; set; }

        public int QuantityProduct { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}
