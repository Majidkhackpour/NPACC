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
    public class CustomerPersistenceRepository : GenericRepository<CustomerBussines, Customer>, ICustomerRepository
    {
        private ModelContext db;

        public CustomerPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckName(Guid guid, string name)
        {
            try
            {
                var acc = db.Customer.AsNoTracking().Where(q => q.Name == name && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }

        public async Task<List<CustomerBussines>> GetAllByGroupAsync(Guid groupGuid)
        {
            try
            {
                var acc = db.Customer.AsNoTracking().Where(q => q.GroupGuid == groupGuid)
                    .ToList();
                var ret = Mappings.Default.Map<List<CustomerBussines>>(acc);
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
