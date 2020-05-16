using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class PrdSelectedGroupPersistenceRepository : GenericRepository<PrdSelectedGroupBussines, PrdSelectedGroup>, IPrdSelectedGroupRepository
    {
        private ModelContext db;

        public PrdSelectedGroupPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
