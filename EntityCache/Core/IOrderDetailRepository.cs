using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IOrderDetailRepository : IRepository<OrderDetailBussines>
    {
        Task<List<OrderDetailBussines>> GetAllAsync(Guid orderGuid);
    }
}
