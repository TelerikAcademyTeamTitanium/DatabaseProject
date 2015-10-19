namespace FurnitureFactory.Exporter
{
    using Data;
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;
    using Models;

    public class ProductsExporter
    {
        private FurnitureFactoryDbContext db;

        public ProductsExporter(FurnitureFactoryDbContext db)
        {
            this.db = db;
        }

        public IList<ProductParse> Export()
        {
            var products = db.Products.ToList<Product>();

            var productsFix = products.Select(p => new ProductParse()
            {
                Name = p.Name,
                Price = p.Price,
                ProductId = p.ProductId,
                MaterialsPerProduct = p.MaterialsPerProduct.Select(m => new MaterialParse()
                {
                    Name = m.Material.Name,
                    Unit = m.Material.Unit
                }).ToList()
            }).ToList();

            return productsFix;
        }
    }
}
