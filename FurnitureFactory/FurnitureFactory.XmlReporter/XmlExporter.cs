namespace FurnitureFactory.XmlReporter
{
    using System.Xml.Linq;
    using System.Collections.Generic;
    using FurnitureFactory.Model;

    public class XmlExporter
    {
        public XmlExporter()
        {
        }

        public void ExportOrders(IList<Order> orders, string exportTo)
        {
            XElement report =
                    new XElement("orders");

            foreach (Order order in orders)
            {
                report.Add(
                    new XElement("order", new XAttribute("client", order.Client),
                    new XElement("summary",
                        new XAttribute("dueDate", order.DueData),
                        new XAttribute("status", order.Status)))
                ); 
            }

            report.Save(exportTo);
        }

        public void ExportClients(IList<Client> clients, string exportTo)
        {
            XElement report =
                    new XElement("clients");
            foreach (Client client in clients)
            {
                report.Add(
                        new XElement("client",
                            new XElement("name", client.Name),
                            new XElement("mobile", client.Mobile),
                            new XElement("email", client.Email),
                            new XElement("contact", client.Contact),
                            new XElement("address", client.Address))
                );
            }

            report.Save(exportTo);
        }
    }
}
