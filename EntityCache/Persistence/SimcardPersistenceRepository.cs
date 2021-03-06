﻿using System;
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

        public async Task<bool> CheckNumber(Guid guid, long number)
        {
            try
            {
                var acc = db.Simcard.AsNoTracking().Where(q => q.Number == number && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
    }
}
