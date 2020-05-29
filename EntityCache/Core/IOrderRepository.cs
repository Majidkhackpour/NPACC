using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IOrderRepository : IRepository<OrderBussines>
    {
        Task<int> GetMaxOrderNo();
    }
}
