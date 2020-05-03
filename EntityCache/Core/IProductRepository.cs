using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IProductRepository : IRepository<ProductBussines>
    {
        Task<bool> CheckName(Guid guid, string name);
        Task<string> NextCode();
        Task<List<ProductBussines>> GetAllByGroupAsync(Guid groupGuid);
    }
}
