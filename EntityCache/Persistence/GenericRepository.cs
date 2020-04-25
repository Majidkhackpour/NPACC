using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityCache.Core;
using PacketParser.EntitiesInterface;
using PacketParser.Services;
using SqlServerPersistence.Model;

namespace EntityCache.Persistence
{
    public class GenericRepository<T> : IRepository<T> where T : class, IHasGuid, new()
    {
        private ModelContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(ModelContext db)
        {
            this._dbContext = db;
            this._dbSet = _dbContext.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> where = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (where != null)
                    query = query.Where(where);

                return query.ToList();
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                return null;
            }
        }

        public T Get(Guid guid)
        {
            try
            {
                return _dbSet.Find(guid);
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                return null;
            }
        }

        public ReturnedSaveFuncInfo Remove(T item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (_dbContext.Entry(item).State == EntityState.Detached)
                    _dbSet.Attach(item);

                _dbSet.Remove(item);
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                res.AddReturnedValue(e);
            }

            return res;
        }

        public ReturnedSaveFuncInfo RemoveAll(List<T> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    if (_dbContext.Entry(item).State == EntityState.Detached)
                        _dbSet.Attach(item);

                    _dbSet.Remove(item);
                }
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                res.AddReturnedValue(e);
            }

            return res;
        }


        public List<T> GetAll()
        {
            try
            {
                var result = _dbContext.Set<T>().ToList();
                return result;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public ReturnedSaveFuncInfo Save(T item, short TryCount = 10, string transActionName = null)
        {
            var res = new ReturnedSaveFuncInfo();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Add(item);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    transaction.Rollback();
                    res.AddReturnedValue(ex);
                }

                return res;
            }
        }

        public ReturnedSaveFuncInfo Save(T item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var entity = _dbSet.Find(item.Guid);
                if (entity == null)
                {
                    _dbContext.Entry(item).State = EntityState.Unchanged;
                    _dbSet.Add(item);
                }
                else
                {
                    _dbContext.Entry(entity).State = EntityState.Detached;
                    _dbContext.Entry(item).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                res.AddReturnedValue(e);
            }

            return res;
        }
    }
}
