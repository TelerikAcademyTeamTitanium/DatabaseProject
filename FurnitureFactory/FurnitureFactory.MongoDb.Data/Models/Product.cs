namespace FurnitureFactory.MongoDb.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Product
    {
        internal Product(string name, double price)
        {
            DataValidator.ValidateProduct(name);
            this.Name = name;
            this.Price = price;
            this.ProductId = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
