namespace FurnitureFactory.MongoDb.Data.DataAccessObjects
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System.Linq;

    internal class DefaultClientsDAO : IClientsDAO
    {
        private MongoDatabase db;

        internal DefaultClientsDAO()
            : this(FurnitureFactoryMongoDbDAO.GetDatabase())
        {
        }

        public DefaultClientsDAO(MongoDatabase db)
        {
            this.db = db;
        }

        public void Delete(Client client)
        {
            var clients = db.GetCollection<Client>("Clients");
            var query = Query.And(
                Query.EQ("Name", client.Name),
                Query.EQ("Address", client.Address),
                Query.EQ("Contact", client.Contact),
                Query.EQ("Email", client.Email),
                Query.EQ("Mobile", client.Mobile));
            var findAndRemoveArguments = new FindAndRemoveArgs();
            findAndRemoveArguments.Query = query;
            clients.FindAndRemove(findAndRemoveArguments);
        }

        public void DeleteAll()
        {
            var clients = db.GetCollection<Client>("Clients");
            clients.RemoveAll();
        }

        public ICollection<Client> GetAll()
        {
            var clients = db.GetCollection<Client>("Clients");
            var clientsList = clients.FindAll().ToList<Client>();
            return clientsList;
        }

        public void Insert(Client client)
        {
            var clients = db.GetCollection<Client>("Clients");
            clients.Insert(client);
        }

        public void InsertMany(ICollection<Client> clientToInsert)
        {
            var clients = db.GetCollection<Client>("Clients");
            clients.InsertBatch(clientToInsert);
        }
    }
}
