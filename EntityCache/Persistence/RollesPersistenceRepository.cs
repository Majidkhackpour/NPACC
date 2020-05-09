using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class RollesPersistenceRepository : GenericRepository<RolleBussines, Rolles>, IRolleRepository
    {
        private ModelContext db;

        public RollesPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
