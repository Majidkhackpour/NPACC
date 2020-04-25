using System;
using EntityCache.Core;
using EntityCache.Persistence;
using SqlServerPersistence.Model;

namespace EntityCache.Assistence
{
    public class UnitOfWork : IDisposable
    {
        private readonly ModelContext db = new ModelContext();
        
        private ICustomerGroupRepository _customerGroupRepository;


        public void Dispose()
        {
            db?.Dispose();
        }
        public void Set_Save()
        {
            db.SaveChanges();
        }


        public ICustomerGroupRepository CustomerGroup => _customerGroupRepository ??
                                                         (_customerGroupRepository =
                                                             new CustomerGroupPersistenceRepository(db));
    }
}
