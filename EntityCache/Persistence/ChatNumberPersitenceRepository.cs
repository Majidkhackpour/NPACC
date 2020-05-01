using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class ChatNumberPersitenceRepository : GenericRepository<ChatNumberBussines, ChatNumbers>, IChatNumberRepository
    {
        private ModelContext db;

        public ChatNumberPersitenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
