namespace FurnitureFactory.Reports.Objects
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Product
    {
        public Product(int id, string name, decimal price, IList<string> materials)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Materials = new List<string>(materials);
        }

        [JsonProperty("product-id")]
        public int Id { get; set; }

        [JsonProperty("product-name")]
        public string Name { get; set; }

        [JsonProperty("product-price")]
        public decimal Price { get; set; }

        [JsonProperty("materials")]
        public IList<string> Materials { get; set; }
    }
}
