namespace FurnitureFactory.MongoDb.Data.DataAccessObjects
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System.Linq;

    internal class DefaultMaterialsDAO : IMaterialsDAO
    {
        private MongoDatabase db;

        internal DefaultMaterialsDAO()
            : this(FurnitureFactoryMongoDbDAO.GetDatabase())
        {
        }

        public DefaultMaterialsDAO(MongoDatabase db)
        {
            this.db = db;
        }

        public void Delete(Material material)
        {
            var materials = db.GetCollection<Material>("Materials");
            var query = Query.And(Query.EQ("Name", material.Name));
            var findAndRemoveArguments = new FindAndRemoveArgs();
            findAndRemoveArguments.Query = query;
            materials.FindAndRemove(findAndRemoveArguments);
        }

        public void DeleteAll()
        {
            var materials = db.GetCollection<Material>("Materials");
            materials.RemoveAll();
        }

        public ICollection<Material> GetAll()
        {
            var materials = db.GetCollection<Material>("Materials");
            var materialsList = materials.FindAll().ToList<Material>();
            return materialsList;
        }

        public void Insert(Material material)
        {
            var materials = db.GetCollection<Material>("Materials");
            materials.Insert(material);
        }

        public void InsertMany(ICollection<Material> materialsToInsert)
        {
            var materials = db.GetCollection<Material>("Materials");
            materials.InsertBatch(materialsToInsert);
        }
    }
}
