using EntityCache.Bussines;
using EntityCache.Core;
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
    }
}
