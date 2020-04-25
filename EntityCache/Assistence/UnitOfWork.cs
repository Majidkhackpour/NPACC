using System;
using EntityCache.Core;
using EntityCache.Persistence;
using SqlServerPersistence.Model;

namespace EntityCache.Assistence
{
    public static class UnitOfWork 
    {
        private static readonly ModelContext db = new ModelContext();
        
        private static ICustomerGroupRepository _customerGroupRepository;


        public static void Dispose()
        {
            db?.Dispose();
        }
        public static void Set_Save()
        {
            db.SaveChanges();
        }


        public static ICustomerGroupRepository CustomerGroup => _customerGroupRepository ??
                                                         (_customerGroupRepository =
                                                             new CustomerGroupPersistenceRepository(db));
    }
}
