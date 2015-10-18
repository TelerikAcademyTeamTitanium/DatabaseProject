namespace FurnitureFactory.MongoDb.Data.DataAccessObjects
{
    using System.Collections.Generic;
    using MongoDB.Driver;
    using Contracts;
    using Models;
    using System.Linq;
    using MongoDB.Driver.Builders;

    internal class DefaultProductsDAO : IProductsDAO
    {
        private MongoDatabase db;

        internal DefaultProductsDAO()
            : this(FurnitureFactoryMongoDbDAO.GetDatabase())
        {
        }

        public DefaultProductsDAO(MongoDatabase db)
        {
            this.db = db;
        }

        public void Delete(Product product)
        {
            var products = db.GetCollection<Product>("Products");
            var query = Query.And(Query.EQ("Price", product.Price), Query.EQ("Name", product.Name));
            var findAndRemoveArguments = new FindAndRemoveArgs();
            findAndRemoveArguments.Query = query;
            products.FindAndRemove(findAndRemoveArguments);
        }

        public void DeleteAll()
        {
            var products = db.GetCollection<Product>("Products");
            products.RemoveAll();
        }

        public ICollection<Product> GetAll()
        {
            var products = db.GetCollection<Product>("Products");
            var productsList = products.FindAll().ToList<Product>();
            return productsList;
        }

        public void Insert(Product product)
        {
            var products = db.GetCollection<Product>("Products");
            products.Insert(product);
        }

        public void InsertMany(ICollection<Product> productsToInsert)
        {
            var products = db.GetCollection<Product>("Products");
            products.InsertBatch(productsToInsert);
        }
    }
}
