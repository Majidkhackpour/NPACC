using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
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
        public async Task<List<PrdTagBussines>> GetAllAsync(Guid prdGuid)
        {
            try
            {
                var acc = db.PrdTag.AsNoTracking().Where(q => q.PrdGuid == prdGuid)
                    .ToList();
                var ret = Mappings.Default.Map<List<PrdTagBussines>>(acc);
                return ret;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
