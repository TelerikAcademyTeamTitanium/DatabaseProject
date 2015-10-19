namespace FurnitureFactory.Exporter
{
    using Data;
    using Model;
    using System.Collections.Generic;
    using System.Linq;

    public class ClientsExporter
    {
        private FurnitureFactoryDbContext db;

        public ClientsExporter(FurnitureFactoryDbContext db)
        {
            this.db = db;
        }

        public IList<Client> Export()
        {
            var clients = db.Clients.ToList<Client>();

            return clients;
        }
    }
}
