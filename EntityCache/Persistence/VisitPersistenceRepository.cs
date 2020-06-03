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
    public class VisitPersistenceRepository : GenericRepository<VisitBussines, Visit>, IVisitRepository
    {
        private ModelContext db;

        public VisitPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckIP(string ip, string date)
        {
            try
            {
                var dateshNow = Calendar.MiladiToShamsi(DateTime.Now);
                var acc = db.Visit.AsNoTracking().Any(q => q.IP == ip && q.Date == dateshNow);
                return acc;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
    }
}
