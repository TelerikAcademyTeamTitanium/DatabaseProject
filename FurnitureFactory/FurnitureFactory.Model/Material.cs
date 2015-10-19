namespace FurnitureFactory.Model
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    public class Material
    {
        private ICollection<MaterialsPerProduct> materialsPerProduct;

        public Material()
        {
            this.materialsPerProduct = new HashSet<MaterialsPerProduct>();
        }

        public int MaterialId { get; set; }

        public string Name { get; set; }

        public Units Unit { get; set; }

        public virtual ICollection<MaterialsPerProduct> MaterialsPerProduct
        {
            get { return this.materialsPerProduct; }
            set { this.materialsPerProduct = value; }
        }
    }
}
