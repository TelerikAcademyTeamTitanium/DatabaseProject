namespace FurnitureFactory.Model
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        private ICollection<Product> products;

        public Order()
        {
            this.products = new HashSet<Product>();
        }

        public int OrderId { get; set; }

        public DateTime ReceivedData { get; set; }

        public DateTime DueData { get; set; }

        public OrderStatus Status { get; set; }

        public string Comment { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
