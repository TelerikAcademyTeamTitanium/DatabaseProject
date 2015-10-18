namespace FurnitureFactory.Model
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        private ICollection<MaterialsPerProduct> materialsPerProduct;

        private ICollection<ProductsPerOrder> productsPerOrder;

      public Product()
        {
            this.materialsPerProduct = new HashSet<MaterialsPerProduct>();
            this.productsPerOrder = new HashSet<ProductsPerOrder>();
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<MaterialsPerProduct> MaterialsPerProduct
        {
            get { return this.materialsPerProduct; }
            set { this.materialsPerProduct = value; }
        }

        public virtual ICollection<ProductsPerOrder> ProductsPerOrder
        {
            get { return this.productsPerOrder; }
            set { this.productsPerOrder = value; }
        }
    }
}
