using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPrdSelectedGroupRepository : IRepository<PrdSelectedGroupBussines>
    {
        Task<List<PrdSelectedGroupBussines>> GetAllAsync(Guid prdGuid);
    }
}
