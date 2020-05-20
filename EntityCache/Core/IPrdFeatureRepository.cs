using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPrdFeatureRepository : IRepository<PrdFeatureBussines>
    {
        Task<List<PrdFeatureBussines>> GetAllAsync(Guid prdGuid);
    }
}
