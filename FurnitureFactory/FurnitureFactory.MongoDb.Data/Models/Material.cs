namespace FurnitureFactory.MongoDb.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Material
    {
        internal Material(string name)
        {
            this.Name = name;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string MaterialId { get; set; }

        public string Name { get; set; }
    }
}
