namespace FurnitureFactory.ConsoleClient
{
    using System;

    using Data;
    using Model;
    using Utilities;
    using MongoDb.Data;
    using Importer;
    using XmlReporter;
    using Exporter;

    public class Startup
    {
        static void Main()
        {
            // var db = new FurnitureFactoryDbContext();

            //// var materials = new Material();
            // var material = new Material
            // {
            //     Name = "Wood",
            //     Unit = Units.SquareMeter
            // };
            // 
            // var produkt = new Product
            // {
            //     Name = "Table",
            //     Price = 150M
            // };
            // 
            // var materialsperProduct = new MaterialsPerProduct
            // {
            //     MaterialId = material.MaterialId,
            //     ProductId = produkt.ProductId,
            //     QuantityMaterials = 2,
            // };
            // 
            // 
            // db.Products.Add(produkt);
            // db.Materials.Add(material);
            // db.MaterialsPerProduct.Add(materialsperProduct);
            // 
            // db.SaveChanges();

            // Testing importer

            // MongoDbPopulator.PopulateFurnitureFactory();
            // ImportMongoDbDataInMssql();
            var xmlReporter = new XmlExporter();
            var clients = new ClientsExporter(new FurnitureFactoryDbContext()).Export();
            xmlReporter.ExportClients(clients, "../../../../Exports/ClientsReport.xml");
            Console.WriteLine("Ready!");

        }

        private static void ImportMongoDbDataInMssql()
        {
            var clients = FurnitureFactoryMongoDbDAO.GetAllClients();
            var products = FurnitureFactoryMongoDbDAO.GetAllProducts();
            var materials = FurnitureFactoryMongoDbDAO.GetAllMaterials();

            var importer = new FurnitureFactoryMsSqlImporter();

            importer.ImportClients(clients);
            importer.ImportProducts(products);
            importer.ImportMaterials(materials);
        }
    }
}
