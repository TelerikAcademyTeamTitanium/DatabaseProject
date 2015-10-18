namespace FurnitureFactory.MongoDb.Data
{
    using MongoDB.Driver;
    using DataAccessObjects;
    using System.Collections.Generic;
    using Models;

    public static class FurnitureFactoryMongoDbDAO
    {
        public const string DatabaseHost = "mongodb://127.0.0.1";
        public const string DatabaseName = "FurnitureFactory";

        internal static MongoDatabase GetDatabase()
        {
            var mongoClient = new MongoClient(DatabaseHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(DatabaseName);
        }

        public static ICollection<Product> GetAllProducts()
        {
            var productsDAO = new DefaultProductsDAO();
            return productsDAO.GetAll();
        }

        public static ICollection<Material> GetAllMaterials()
        {
            var materialsDAO = new DefaultMaterialsDAO();
            return materialsDAO.GetAll();
        }

        public static ICollection<Client> GetAllClients()
        {
            var clientsDAO = new DefaultClientsDAO();
            return clientsDAO.GetAll();
        }
    }
}
