using System;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
