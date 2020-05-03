using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class ProductPicturesPersitenceRepository : GenericRepository<ProductPicturesBussines, ProductPictures>, IProductPicturesRepository
    {
        private ModelContext db;

        public ProductPicturesPersitenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<ProductPicturesBussines>> GetAllAsync(Guid prdGuid)
        {
            try
            {
                var acc = db.ProductPictures.AsNoTracking().Where(q => q.PrdGuid == prdGuid)
                    .ToList();
                var ret = Mappings.Default.Map<List<ProductPicturesBussines>>(acc);
                return ret;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
