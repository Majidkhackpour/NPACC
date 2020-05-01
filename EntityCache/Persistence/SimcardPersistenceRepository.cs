using System;
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
    public class SimcardPersistenceRepository : GenericRepository<SimcardBussines, Simcard>, ISimcardRepository
    {
        private ModelContext db;

        public SimcardPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<SimcardBussines> GetAsync(long number)
        {
            try
            {
                var ret = db.Simcard.FirstOrDefault(q => q.Number == number);
                return Mappings.Default.Map<SimcardBussines>(ret);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
