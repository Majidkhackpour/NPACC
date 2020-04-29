using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class ProductPersistenceRepository : GenericRepository<ProductBussines, Product>, IProductRepository
    {
        private ModelContext db;

        public ProductPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
