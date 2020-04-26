using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ICustomerGroupRepository : IRepository<CustomerGroupBussines>
    {
        Task<bool> CheckName(Guid guid, string name);
    }
}
