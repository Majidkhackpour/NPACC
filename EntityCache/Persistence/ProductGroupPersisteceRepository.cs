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

        public async Task<string> NextCode()
        {
            try
            {
                var all = await GetAllAsync();
                var code = all.ToList()?.Max(q => int.Parse(q.Code)) ?? 0;
                code += 1;
                var new_code = code.ToString();
                if (code < 10)
                {
                    new_code = "00" + code;
                    return new_code;
                }
                if (code >= 10 && code < 100)
                {
                    new_code = "0" + code;
                    return new_code;
                }

                return new_code;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return "001";
            }
        }
    }
}
