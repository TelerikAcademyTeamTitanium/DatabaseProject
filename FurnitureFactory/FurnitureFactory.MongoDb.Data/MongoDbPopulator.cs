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
                new Client("Gosho","Sofia, Mladost, bul. A.Malinov", "0884553245", "gosho@telerik.com", "Gosho Peshov"),
                new Client("Perfekt Mebel", "Sofia, Lulin 3, bl.340", "0888436778", "perfekt@gmail.com", ""),
                new Client("Mebelni Idei", "Sofia, Suhata Reka, bl.45", "0898123890", "mebelniidei@gmail.com", ""),
                new Client("Mebeli Roko", "Sofia, Mariya Luiza 15", "0878145298", "mroko@abv.bg", ""),
                new Client("TiD Mebel", "Sofia, Boyana, Student Kladenec 32", "0888723835", "tidmebel@mail.bg", ""),
                new Client("Mebelina", "Pernik, ul. Vasil Levski 10", "0883456123", "mebelina@abv.bg", ""),
                new Client("Interiori", "Sofia, Voenna Rampa", "0889561290", "interiori@gmail.com", ""),
                new Client("Mebelisimo", "Plovdiv, Opulchenska 45", "0888890345", "mebelisimo@abv.bg", ""),
                new Client("GTC Design", "Plovdiv, Trakia, bl.101", "0883123659", "office@gtcdesign.com", ""),
                new Client("Delfos Design", "Sofia, Slatina, bl.1", "0888", "info@delfos.com", ""),
                new Client("Archidea", "Pernik, ul.Osvobojdenska 132", "0888", "office@archidea.com", ""),
                new Client("Mebelna Fabrika Irim", "Ruse, Zapanda Industrialna Zona", "0888", "office@irim.com", ""),
                new Client("Kolorado", "Pazardjik, Industrialna Zona", "0888", "@gmail.com", ""),
                new Client("Ikar 2006", "Elena, ul. Stara Planina 1", "0888", "@gmail.com", ""),
                new Client("Koral", "Pazardjik, ul. Levski 14", "0888", "@gmail.com", ""),
                new Client("Neoform", "Varna, bul. Vladislav Varnenchik 100", "0888", "@gmail.com", ""),
                new Client("Diel 09", "Sofia, Mladost", "0888", "diel09@abv.bg", "Lybomir Ivanov")
            };

            return clients;
        }

        private static ICollection<Product> GetSampleProducts()
        {
            var products = new List<Product>()
            {
                new Product("Chair Harmony", 14.50),
                new Product("Chair Cordoba", 12.70),
                new Product("Chair Teresa", 11.00),
                new Product("Chair Daisy", 8.00),
                new Product("Chair Margarita", 10.50),
                new Product("Table Italy", 140.50),
                new Product("Table Monaco", 70.20),
                new Product("Table Padova", 45.50),
                new Product("Bed France", 134.50),
                new Product("Bed Olymp", 234.50),
                new Product("Bed Granada", 150.30),
                new Product("Bed France", 124.00),
                new Product("Wardrobe Michaela", 540.50),
                new Product("Wardrobe Francesca", 400.00),
                new Product("Shoerack Montesano", 100.00)
            };

            return products;
        }

        private static ICollection<Material> GetSampleMaterials()
        {
            var materials = new List<Material>()
            {
                new Material("Chipboard Dark Oak", (int)Units.SquareMeter),
                new Material("Chipboard Beach", (int)Units.SquareMeter),
                new Material("Chipboard Oak", (int)Units.SquareMeter),
                new Material("MDF", (int)Units.SquareMeter),
                new Material("Hinge AGG", (int)Units.Piece),
                new Material("Hinge BGG", (int)Units.Piece),
                new Material("Hinge CGG", (int)Units.Piece),
                new Material("Handle model A", (int)Units.Piece),
                new Material("Knob model A", (int)Units.Piece),
                new Material("Handle model B", (int)Units.Piece),
                new Material("Knob model B", (int)Units.Piece),
                new Material("Table leg", (int)Units.Set),
                new Material("Sofa leg", (int)Units.Piece),
                new Material("Spleen H100", (int)Units.Meter),
                new Material("Spleen H100 INOX", (int)Units.Meter),
                new Material("MiniFix", (int)Units.Piece),
                new Material("MiniFix Screw", (int)Units.Piece)
            };

            return materials;
        }
    }
}
