using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class OpinionPersistenceRepository : GenericRepository<OpinionBussines, Opinions>, IOpinionRepository
    {
        private ModelContext db;

        public OpinionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
