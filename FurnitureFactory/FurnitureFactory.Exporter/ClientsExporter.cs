using System.Collections.Generic;
using System.Data.Entity;
using FurnitureFactory.Data;
using FurnitureFactory.Model;
using System.Linq;

namespace FurnitureFactory.Exporter
{
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
