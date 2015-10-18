namespace FurnitureFactory.MongoDb.Data.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Client
    {
        internal Client(string name, string address, string mobile, string email, string contact)
        {
            DataValidator.ValidateClient(name, address, mobile, email, contact);
            this.Name = name;
            this.Address = address;
            this.Mobile = mobile;
            this.Email = email;
            this.Contact = contact;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string ClientId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }
    }
}
