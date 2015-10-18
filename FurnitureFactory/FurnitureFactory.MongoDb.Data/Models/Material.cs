namespace FurnitureFactory.MongoDb.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Material
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string MaterialId { get; set; }

        public string Name { get; set; }

        public string Units { get; set; }
    }
}
