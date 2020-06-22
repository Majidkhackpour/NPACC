using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class SettingsPersistenceRepository : GenericRepository<SettingsBussines, Settings>, ISettingsRepositort
    {
        private ModelContext db;

        public SettingsPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<SettingsBussines> GetAsync(string memberName)
        {
            try
            {
                var acc = db.Settings.AsNoTracking().FirstOrDefault(q => q.Name == memberName);
                var ret = Mappings.Default.Map<SettingsBussines>(acc);
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
