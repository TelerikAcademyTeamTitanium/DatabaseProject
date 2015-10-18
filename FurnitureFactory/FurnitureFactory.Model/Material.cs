namespace FurnitureFactory.Model
{
    using System;
    using System.Collections.Generic;

    public class Material
    {
        private ICollection<Product> products;

        public Material()
        {
            this.products = new HashSet<Product>();
        }

        public int MaterialId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
