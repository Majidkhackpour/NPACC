using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class PrdTagPersistenceRepository : GenericRepository<PrdTagBussines, PrdTag>, IPrdTagRepository
    {
        private ModelContext db;

        public PrdTagPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
