namespace FurnitureFactory.XmlToDbParser
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using FurnitureFactory.Data;
    using FurnitureFactory.Model;

    public static class XmlParser
    {
        public static void ParseXmlToSql()
        {
            var db = new FurnitureFactoryDbContext();
            Order order = new Order();

            XDocument xmlDoc =
                XDocument.Load("../../../XmlFiles/Comments.xml");
            var comments =
                from client in xmlDoc.Descendants("client")
                select new
                {
                    Name = client.Attribute("name").Value,
                    Comment = client.Element("comment").FirstNode.ToString(),
                    Date = client.Element("comment").FirstAttribute.Value
                };

            foreach (var comment in comments)
            {
                order = new Order
                {
                    DueData = comment.Date,
                    Comment = comment.Comment,
                    Client = new Client()
                    {
                        Name = comment.Name
                    }
                };
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}