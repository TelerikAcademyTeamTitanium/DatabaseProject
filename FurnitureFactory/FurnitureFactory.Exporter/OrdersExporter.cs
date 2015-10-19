using FurnitureFactory.Data;
using FurnitureFactory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFactory.Exporter
{
    public class OrdersExporter
    {
        private FurnitureFactoryDbContext db;

        public OrdersExporter(FurnitureFactoryDbContext db)
        {
            this.db = db;
        }

        public IList<Order> Export()
        {
            var orders = db.Orders.ToList<Order>();

            return orders;
        }
    }
}
