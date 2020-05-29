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
    public class OrderDetailPersitenceRepository : GenericRepository<OrderDetailBussines, OrderDetail>, IOrderDetailRepository
    {
        private ModelContext db;

        public OrderDetailPersitenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<OrderDetailBussines>> GetAllAsync(Guid orderGuid)
        {
            try
            {
                var acc = db.OrderDetail.AsNoTracking().Where(q => q.OrderGuid == orderGuid)
                    .ToList();
                var ret = Mappings.Default.Map<List<OrderDetailBussines>>(acc);
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
