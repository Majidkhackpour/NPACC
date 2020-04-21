using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityCache.Core;
using PacketParser.Services;
using SqlServerPersistence.Model;

namespace SqlServerPersistence.Persistence
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
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
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
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public T Get(Guid guid)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    return _dbSet.Find(guid);
                }
                catch (Exception e)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(e);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public bool Remove(T item)
        {
            try
            {
                if (_dbContext.Entry(item).State == EntityState.Detached)
                    _dbSet.Attach(item);

                _dbSet.Remove(item);
                return true;
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                return false;
            }
        }

        public bool RemoveAll(List<T> list)
        {
            try
            {
                foreach (var item in list)
                {
                    if (_dbContext.Entry(item).State == EntityState.Detached)
                        _dbSet.Attach(item);

                    _dbSet.Remove(item);
                }

                return true;
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                return false;
            }
        }


        public List<T> GetAll()
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                    var result = _dbContext.Set<T>().ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public bool Save(T item, short TryCount = 10, string transActionName = null)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Add(item);
                    return true;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public virtual bool Update(T entity)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    return true;
                }
                catch (Exception e)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(e);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Save(T item)
        {
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
                return true;
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                return false;
            }
        }
    }
}
