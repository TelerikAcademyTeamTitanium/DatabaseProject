namespace FurnitureFactory.MongoDb.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
