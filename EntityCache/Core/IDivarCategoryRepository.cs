using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IDivarCategoryRepository : IRepository<DivarCategoryBussines>
    {
        Task<List<DivarCategoryBussines>> GetAllAsync(Guid parentGuid);
    }
}
