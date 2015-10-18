namespace FurnitureFactory.MongoDb.Data.Contracts
{
    using Models;
    using System.Collections.Generic;

    internal interface IClientsDAO
    {
        void Insert(Client client);

        ICollection<Client> GetAll();

        void DeleteAll();

        void Delete(Client client);
    }
}
