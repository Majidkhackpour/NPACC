using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class UsersPersistenceRepository : GenericRepository<UserBussines, Users>, IUserRepository
    {
        private ModelContext db;

        public UsersPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
