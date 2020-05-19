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
    public class PrdSelectedGroupPersistenceRepository : GenericRepository<PrdSelectedGroupBussines, PrdSelectedGroup>, IPrdSelectedGroupRepository
    {
        private ModelContext db;

        public PrdSelectedGroupPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
        public async Task<List<PrdSelectedGroupBussines>> GetAllAsync(Guid prdGuid)
        {
            try
            {
                var acc = db.PrdSelectedGroup.AsNoTracking().Where(q => q.PrdGuid == prdGuid)
                    .ToList();
                var ret = Mappings.Default.Map<List<PrdSelectedGroupBussines>>(acc);
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
