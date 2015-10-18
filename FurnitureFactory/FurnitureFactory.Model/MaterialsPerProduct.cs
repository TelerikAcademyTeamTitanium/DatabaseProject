namespace FurnitureFactory.Model
{
    using System;

   public class MaterialsPerProduct
    {
       public int MaterialsPerProductId { get; set; }

        public int QuantityMaterials { get; set; }

        public int MaterialId { get; set; }

        public virtual Material Material { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
