using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ICustomerRepository : IRepository<CustomerBussines>
    {
        Task<bool> CheckName(Guid guid, string name);
        Task<List<CustomerBussines>> GetAllByGroupAsync(Guid groupGuid);
    }
}
