using System.Collections;
using System.Collections.Generic;

namespace FurnitureFactory.Exporter.Models
{
    public class ProductParse
    {
        public ProductParse()
        {
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public  ICollection<MaterialParse> MaterialsPerProduct { get; set; }
    }
}
