namespace FurnitureFactory.Model
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        private ICollection<Material> materials;

        public Product()
        {
            this.materials = new HashSet<Material>();
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Material> Materials
        {
            get { return this.materials; }
            set { this.materials = value; }
        }
    }
}
