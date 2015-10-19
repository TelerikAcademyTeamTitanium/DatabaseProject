namespace FurnitureFactory.ConsoleClient
{
    using System;

    using Data;
    using Model;
    using Utilities;

   public class Startup
    {
        static void Main()
        {
            var db = new FurnitureFactoryDbContext();

           //// var materials = new Material();
            var material = new Material
            {
                Name = "Wood",
                Unit = Units.SquareMeter
            };

            var produkt = new Product
            {
                Name = "Table",
                Price = 150M
            };

            var materialsperProduct = new MaterialsPerProduct
            {
                MaterialId = material.MaterialId,
                ProductId = produkt.ProductId,
                QuantityMaterials = 2,
            };

            
            db.Products.Add(produkt);
            db.Materials.Add(material);
            db.MaterialsPerProduct.Add(materialsperProduct);

            db.SaveChanges();

            Console.WriteLine("Ready!");

        }
    }
}
