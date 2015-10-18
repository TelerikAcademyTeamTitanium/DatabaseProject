namespace FurnitureFactory.MongoDb.Data.Contracts
{
    using Models;
    using System.Collections.Generic;

    internal interface IMaterialsDAO
    {
        void Insert(Material material);

        ICollection<Material> GetAll();

        void DeleteAll();

        void Delete(Material material);
    }
}
