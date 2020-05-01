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
    public class DivarCategoreyPersistenceRepository : GenericRepository<DivarCategoryBussines, DivarCategory>, IDivarCategoryRepository
    {
        private ModelContext db;

        public DivarCategoreyPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<DivarCategoryBussines>> GetAllAsync(Guid parentGuid)
        {
            try
            {
                var list = db.DivarCategory.AsNoTracking().Where(q => q.ParentGuid == parentGuid).ToList();
                return Mappings.Default.Map<List<DivarCategoryBussines>>(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
