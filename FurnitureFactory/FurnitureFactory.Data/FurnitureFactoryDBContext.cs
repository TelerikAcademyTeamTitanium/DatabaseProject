using FurnitureFactory.Model;

namespace FurnitureFactory.Data
{
    using System;
    using System.Data.Entity;

    public class FurnitureFactoryDbContext : DbContext
    {
        public FurnitureFactoryDbContext()
            : base("FurnitureFactory")
        { }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<MaterialsPerProduct> MaterialsPerProduct { get; set; }

        public virtual DbSet<ProductsPerOrder> ProductsPerOrder { get; set; }

    }
}
