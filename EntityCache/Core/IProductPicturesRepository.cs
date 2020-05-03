using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IProductPicturesRepository : IRepository<ProductPicturesBussines>
    {
        Task<List<ProductPicturesBussines>> GetAllAsync(Guid prdGuid);
    }
}
