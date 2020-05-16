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
    public class ProductPersistenceRepository : GenericRepository<ProductBussines, Product>, IProductRepository
    {
        private ModelContext db;

        public ProductPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckName(Guid guid, string name)
        {
            try
            {
                var acc = db.Product.AsNoTracking().Where(q => q.Name == name && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
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
                if (code >= 100 && code < 1000)
                {
                    new_code = code.ToString();
                    return new_code;
                }

                return new_code;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return "0001";
            }
        }

        public async Task<List<ProductBussines>> GetAllByGroupAsync(Guid groupGuid)
        {
            try
            {
                //var acc = db.Product.AsNoTracking().Where(q => q.GroupGuid == groupGuid)
                //    .ToList();
                //var ret = Mappings.Default.Map<List<ProductBussines>>(acc);
                //return ret;
                return null;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
