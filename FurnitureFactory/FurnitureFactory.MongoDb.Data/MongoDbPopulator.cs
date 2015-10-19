namespace FurnitureFactory.MongoDb.Data
{
    using DataAccessObjects;
    using Models;
    using System;
    using System.Collections.Generic;
    using FurnitureFactory.Utilities;

    public static class MongoDbPopulator
    {
        public static void PopulateFurnitureFactory()
        {
            var clientsDAO = new DefaultClientsDAO();
            var productsDAO = new DefaultProductsDAO();
            var materialsDAO = new DefaultMaterialsDAO();

            var clients = GetSampleClients();
            var products = GetSampleProducts();
            var materials = GetSampleMaterials();

            clientsDAO.InsertMany(clients);
            productsDAO.InsertMany(products);
            materialsDAO.InsertMany(materials);
        }

        private static ICollection<Client> GetSampleClients()
        {
            var clients = new List<Client>()
            {
                new Client("Gosho","bul. Aleksandar Malinov", "0884553245", "gosho@telerik.com", "Gosho Peshov")
            };

            return clients;
        }

        private static ICollection<Product> GetSampleProducts()
        {
            throw new NotImplementedException();
        }

        private static ICollection<Material> GetSampleMaterials()
        {
            var materials = new List<Material>()
            {
                new Material("Wood", (int)Units.Piece),
            };

            return materials;
        }
    }
}
