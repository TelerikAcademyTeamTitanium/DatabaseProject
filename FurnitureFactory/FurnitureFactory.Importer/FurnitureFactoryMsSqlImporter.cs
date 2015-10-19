namespace FurnitureFactory.Importer
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Utilities;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;

    public class FurnitureFactoryMsSqlImporter
    {
        private FurnitureFactoryDbContext dbContext;

        public FurnitureFactoryMsSqlImporter()
        {
            this.dbContext = new FurnitureFactoryDbContext();
        }

        public void ImportClients(ICollection<MongoDb.Data.Models.Client> mongoClients)
        {
            var clients = mongoClients.Select(c => new Model.Client()
            {
                Address = c.Address,
                Contact = c.Contact,
                Email = c.Email,
                Mobile = c.Mobile,
                Name = c.Name
            });

            var counter = 0;
            foreach (var client in clients)
            {
                this.dbContext.Clients.Add(client);
                counter++;

                if (counter % 50 == 0)
                {
                    this.dbContext.SaveChanges();
                    this.dbContext.Dispose();
                    this.dbContext = new FurnitureFactoryDbContext();
                }
            }

            this.dbContext.SaveChanges();
        }

        public void ImportProducts(ICollection<MongoDb.Data.Models.Product> mongoProducts)
        {
            var products = mongoProducts.Select(c => new Model.Product()
            {
                Name = c.Name,
                Price = Convert.ToDecimal(c.Price)
            });

            var counter = 0;
            foreach (var product in products)
            {
                this.dbContext.Products.Add(product);
                counter++;

                if (counter % 50 == 0)
                {
                    this.dbContext.SaveChanges();
                    this.dbContext.Dispose();
                    this.dbContext = new FurnitureFactoryDbContext();
                }
            }

            this.dbContext.SaveChanges();
        }

        public void ImportMaterials(ICollection<MongoDb.Data.Models.Material> mongoMaterials)
        {
            var materials = mongoMaterials.Select(c => new Model.Material()
            {
                Name = c.Name,
                Unit = (Units)c.Unit
            });

            var counter = 0;
            foreach (var material in materials)
            {
                this.dbContext.Materials.Add(material);
                counter++;

                if (counter % 50 == 0)
                {
                    this.dbContext.SaveChanges();
                    this.dbContext.Dispose();
                    this.dbContext = new FurnitureFactoryDbContext();
                }
            }

            this.dbContext.SaveChanges();
        }

        public void ImportOrders(DataSet data)
        {
            DataTable table = data.Tables[0];
            var order = new Model.Order();
            order.Client = new Model.Client();
            try
            {
                order.ReceivedData = table.Rows[0][0].ToString();
                order.DueData = table.Rows[0][1].ToString();
                order.Status = (Model.OrderStatus)Int16.Parse(table.Rows[0][2].ToString());
                order.Comment = table.Rows[0][3].ToString();
                order.Client.ClientId = Int32.Parse(table.Rows[0][4].ToString());
                this.dbContext.Orders.Add(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.dbContext.SaveChanges();
        }
    }
}
