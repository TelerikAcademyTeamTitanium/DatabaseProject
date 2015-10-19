namespace FurnitureFactory.ConsoleClient
{
    using System;

    using Data;
    using Model;
    using Utilities;
    using MongoDb.Data;
    using Importer;
    using System.IO;
    using DataLoad;
    using System.Data;

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

            MongoDbPopulator.PopulateFurnitureFactory();
            ImportMongoDbDataInMssql();

            Console.WriteLine("Ready!");

        }

        private static void ImportMongoDbDataInMssql()
        {
            /*
            var clients = FurnitureFactoryMongoDbDAO.GetAllClients();
            var products = FurnitureFactoryMongoDbDAO.GetAllProducts();
            var materials = FurnitureFactoryMongoDbDAO.GetAllMaterials();
            */
            var importer = new FurnitureFactoryMsSqlImporter();
            
            /*
            importer.ImportClients(clients);
            importer.ImportProducts(products);
            importer.ImportMaterials(materials);
            */
            string zipFilePath = "../../../../ExcelTables/test.zip";
            FileInfo info = new FileInfo(zipFilePath);
            ZipFileReader zipReader = ZipFileReader.Create();
            zipReader.ReadFile(zipFilePath);
            ExcelDataReader excelReader = ExcelDataReader.Create();
            excelReader.ReadFile(info.DirectoryName);
            for (int i = 0; i < excelReader.ExcelData.Count; i++)
            {
                importer.ImportOrders(excelReader.ExcelData[i]);
            }
        }
    }
}
