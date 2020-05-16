using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Core;
using PacketParser.EntitiesInterface;
using PacketParser.Services;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class GenericRepository<T, U> : IRepository<T> where U : class, IHasGuid, new()
        where T : class, IHasGuid, new()
    {
        private ModelContext _dbContext;
        private DbSet<U> _dbSet;

        public GenericRepository(ModelContext db)
        {
            this._dbContext = db;
            this._dbSet = _dbContext.Set<U>();
        }

        public async Task<T> GetAsync(Guid guid)
        {
            try
            {
                var tranName = Guid.NewGuid().ToString();
                var ret = _dbContext.Set<U>().AsNoTracking().FirstOrDefault(p => p.Guid == guid);
                return Mappings.Default.Map<T>(ret);
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                return null;
            }
        }


        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, string tranName)
        {
            try
            {
                var ret = _dbContext.Set<U>().FirstOrDefault(p => p.Guid == guid);
                if (ret == null) return new ReturnedSaveFuncInfo();
                if (_dbContext.Entry(ret).State == EntityState.Detached)
                    _dbSet.Attach(ret);
                _dbSet.Remove(ret);
                await _dbContext.SaveChangesAsync();
                return new ReturnedSaveFuncInfo();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new ReturnedSaveFuncInfo(ex);
            }
        }

        public async Task<ReturnedSaveFuncInfo> RemoveAllAsync(string tranName)
        {
            try
            {
                _dbContext.Set<U>().RemoveRange(_dbContext.Set<U>().AsNoTracking().ToList());
                await _dbContext.SaveChangesAsync();
                return new ReturnedSaveFuncInfo();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new ReturnedSaveFuncInfo(ex);
            }
        }


        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var tranName = Guid.NewGuid().ToString();
                var tt = typeof(T);
                var Tu = typeof(U);
                var ret = _dbContext.Set<U>().AsNoTracking().ToList();
                return Mappings.Default.Map<List<T>>(ret);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }


        public async Task<ReturnedSaveFuncInfo> SaveAsync(T item, string tranName)
        {
            try
            {
                var ret = Mappings.Default.Map<U>(item);
                _dbContext.Set<U>().AddOrUpdate(ret);
                await _dbContext.SaveChangesAsync();
                return new ReturnedSaveFuncInfo();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new ReturnedSaveFuncInfo(ex);
            }
        }

        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(IEnumerable<Guid> items, string tranName)
        {
            try
            {
                foreach (var item in items)
                {
                    var ret = _dbContext.Set<U>().FirstOrDefault(p => p.Guid == item);
                    if (ret == null) return new ReturnedSaveFuncInfo();
                    if (_dbContext.Entry(ret).State == EntityState.Detached)
                        _dbSet.Attach(ret);
                    _dbSet.Remove(ret);
                }

                await _dbContext.SaveChangesAsync();
                return new ReturnedSaveFuncInfo();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new ReturnedSaveFuncInfo(ex);
            }
        }

        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<T> items, string tranName)
        {
            try
            {
                foreach (var item in items)
                {
                    var ret = Mappings.Default.Map<U>(item);
                    _dbContext.Set<U>().AddOrUpdate(ret);
                }

                await _dbContext.SaveChangesAsync();
                return new ReturnedSaveFuncInfo();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new ReturnedSaveFuncInfo(ex);
            }
        }
    }
}
