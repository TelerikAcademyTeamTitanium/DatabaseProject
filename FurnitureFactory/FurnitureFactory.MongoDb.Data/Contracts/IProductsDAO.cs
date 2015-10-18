namespace FurnitureFactory.MongoDb.Data.Contracts
{
    using Models;
    using System.Collections.Generic;

    internal interface IProductsDAO
    {
        void Insert(Product product);

        ICollection<Product> GetAll();

        void DeleteAll();

        void Delete(Product product);
    }
}