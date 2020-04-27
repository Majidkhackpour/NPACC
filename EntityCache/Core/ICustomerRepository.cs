using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ICustomerRepository : IRepository<CustomerBussines>
    {
        Task<bool> CheckName(Guid guid, string name);
    }
}
