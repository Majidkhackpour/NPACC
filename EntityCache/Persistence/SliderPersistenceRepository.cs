using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class SliderPersistenceRepository : GenericRepository<SliderBussines, Slider>, ISliderRepository
    {
        private ModelContext db;

        public SliderPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
