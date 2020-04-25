using System;
using SqlServerPersistence.Model;

namespace EntityCache.Assistence
{
    public class UnitOfWork : IDisposable
    {
        private readonly ModelContext db = new ModelContext();
        public void Dispose()
        {
            db?.Dispose();
        }
        public void Set_Save()
        {
            db.SaveChanges();
        }
    }
}
