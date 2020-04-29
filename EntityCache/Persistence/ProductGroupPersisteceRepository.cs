using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
using SqlServerPersistence.Entities;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class ProductGroupPersisteceRepository : GenericRepository<ProductGroupBussines, ProductGroup>, IProductGroupRepository
    {
        private ModelContext db;

        public ProductGroupPersisteceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckName(Guid guid, string name)
        {
            try
            {
                var acc = db.ProductGroup.AsNoTracking().Where(q => q.Name == name && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }

        public async Task<int> ChildCount(Guid guid)
        {
            try
            {
                var acc = db.ProductGroup.AsNoTracking().Count(q => q.ParentGuid == guid);
                return acc;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return 0;
            }
        }
    }
}
