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
    using XmlReporter;
    using Exporter;
    using Reports;


    public class Startup
    {
        static void Main()
        {
            
            MongoDbPopulator.PopulateFurnitureFactory();
            ImportMongoDbDataInMssql();
            ImportExcelDataInMssql();

            var xmlReporter = new XmlExporter();
            var clients = new ClientsExporter(new FurnitureFactoryDbContext()).Export();
            xmlReporter.ExportClients(clients, "../../../../Exports/Xml/ClientsReport.xml");

            var xmlReporterOrder = new XmlExporter();
            var orders = new OrdersExporter(new FurnitureFactoryDbContext()).Export();
            xmlReporterOrder.ExportOrders(orders, "../../../../Exports/Xml/OrdersReport.xml");

            var products = new ProductsExporter(new FurnitureFactoryDbContext()).Export();
            var jsonReporter = new JsonExporter(JsonExporter.DefaultOutputPath, products);
            jsonReporter.Export();

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

        private static void ImportExcelDataInMssql()
        {
            var importer = new FurnitureFactoryMsSqlImporter();

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
