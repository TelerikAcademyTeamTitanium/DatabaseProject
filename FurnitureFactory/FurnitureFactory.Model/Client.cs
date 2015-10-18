namespace FurnitureFactory.Model
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        private ICollection<Order> orders;

        public Client()
        {
            this.orders = new HashSet<Order>();
        }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string EMmail { get; set; }

        public string Contact { get; set; }

        public virtual ICollection<Order> Order
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}
