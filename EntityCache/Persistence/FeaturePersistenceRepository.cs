using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class FeaturePersistenceRepository : GenericRepository<FeatureBussines, Features>, IFeatureRepository
    {
        private ModelContext db;

        public FeaturePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
