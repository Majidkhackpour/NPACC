using EntityCache.Bussines;
using EntityCache.Core;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class CustomerGroupPersistenceRepository : GenericRepository<CustomerGroupBussines>, ICustomerGroupRepository
    {
        private ModelContext db;

        public CustomerGroupPersistenceRepository(ModelContext _db) : base(_db)
        {
            _db = db;
        }
    }
}
