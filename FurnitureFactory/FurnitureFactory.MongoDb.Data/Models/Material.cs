namespace FurnitureFactory.MongoDb.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Material
    {
        internal Material(string name, int unit)
        {
            DataValidator.ValidateMaterial(name);
            this.Name = name;
            this.Unit = unit;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string MaterialId { get; set; }

        public string Name { get; set; }

        public int Unit { get; set; }
    }
}
