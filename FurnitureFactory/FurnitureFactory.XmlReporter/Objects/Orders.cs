using System.Xml.Serialization;

namespace FurnitureFactory.XmlReporter.Objects
{
    using System;
    using System.Xml.Linq;
    using FurnitureFactory.Model;

    public class Orders
    {
        public Orders(Client client, DateTime dueData, OrderStatus status)
        {
            this.Client = client;
            this.DueData = dueData;
            this.Status = status;
        }

        [XmlAttribute]
        public Client Client { get; set; }

        [XmlAttribute]
        public DateTime DueData { get; set; }

        [XmlAttribute]
        public OrderStatus Status { get; set; }
    }
}
