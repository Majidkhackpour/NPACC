using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPrdCommentRepository : IRepository<PrdCommentBussines>
    {
        Task<List<PrdCommentBussines>> GetAllAsync(Guid prdGuid);
    }
}
