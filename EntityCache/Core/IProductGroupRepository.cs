using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IProductGroupRepository : IRepository<ProductGroupBussines>
    {
        Task<bool> CheckName(Guid guid, string name);
        Task<int> ChildCount(Guid guid);
    }
}
