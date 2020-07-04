using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using PacketParser.Services;

namespace EntityCache.Core
{
    public interface IOrderRepository : IRepository<OrderBussines>
    {
        Task<int> GetMaxOrderNo();
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid orderGuid);
    }
}
