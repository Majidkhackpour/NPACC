using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPrdTagRepository : IRepository<PrdTagBussines>
    {
        Task<List<PrdTagBussines>> GetAllAsync(Guid prdGuid);
    }
}
