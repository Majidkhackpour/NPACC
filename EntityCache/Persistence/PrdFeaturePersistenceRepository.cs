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
    public class PrdFeaturePersistenceRepository : GenericRepository<PrdFeatureBussines, PrdFeatures>, IPrdFeatureRepository
    {
        private ModelContext db;

        public PrdFeaturePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
        public async Task<List<PrdFeatureBussines>> GetAllAsync(Guid prdGuid)
        {
            try
            {
                var acc = db.PrdFeatures.AsNoTracking().Where(q => q.PrdGuid == prdGuid)
                    .ToList();
                var ret = Mappings.Default.Map<List<PrdFeatureBussines>>(acc);
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
