namespace FurnitureFactory.Model
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        private ICollection<ProductsPerOrder> productsPerOrder;

        public Order()
        {
            this.productsPerOrder = new HashSet<ProductsPerOrder>();
        }

        public int OrderId { get; set; }

        public DateTime ReceivedData { get; set; }

        public DateTime DueData { get; set; }

        public OrderStatus Status { get; set; }

        public string Comment { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<ProductsPerOrder> ProductsPerOrder
        {
            get { return this.productsPerOrder; }
            set { this.productsPerOrder = value; }
        }
    }
}
