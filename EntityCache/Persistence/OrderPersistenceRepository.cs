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
    public class OrderPersistenceRepository : GenericRepository<OrderBussines, Order>, IOrderRepository
    {
        private ModelContext db;

        public OrderPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<int> GetMaxOrderNo()
        {
            try
            {
                var all = await GetAllAsync();
                var code = all.ToList()?.Max(q => int.Parse(q.OrderNo.ToString())) ?? 0;
                return code + 1;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return 1;
            }
        }

        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid orderGuid)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var order = db.Order.SingleOrDefault(q => q.Guid == orderGuid);
                if (order == null) return res;
                order.IsFinally = true;
                await db.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                res.AddReturnedValue(exception);
            }

            return res;
        }
    }
}
