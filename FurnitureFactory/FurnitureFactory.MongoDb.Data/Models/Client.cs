namespace FurnitureFactory.MongoDb.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Client
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClientId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public long Mobile { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }
    }
}
