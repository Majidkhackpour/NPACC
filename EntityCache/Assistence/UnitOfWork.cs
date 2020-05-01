using EntityCache.Core;
using EntityCache.Persistence;
using SqlServerPersistence.Model;

namespace EntityCache.Assistence
{
    public static class UnitOfWork
    {
        private static readonly ModelContext db = new ModelContext();

        private static ICustomerGroupRepository _customerGroupRepository;
        private static ICustomerRepository _customerRepository;
        private static IProductGroupRepository _productGroupRepository;
        private static IProductRepository _productRepository;
        private static IProductPicturesRepository _prdPicturesGroupRepository;
        private static ISimcardRepository _simcardRepository;
        private static IChatNumberRepository _chatNumberRepository;
        private static IDivarCategoryRepository _divarCategoryRepository;


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

        public static ICustomerRepository Customer => _customerRepository ??
                                                      (_customerRepository =
                                                          new CustomerPersistenceRepository(db));

        public static IProductGroupRepository ProductGroup => _productGroupRepository ??
                                                              (_productGroupRepository =
                                                                  new ProductGroupPersisteceRepository(db));

        public static IProductRepository Product => _productRepository ??
                                                      (_productRepository =
                                                          new ProductPersistenceRepository(db));

        public static IProductPicturesRepository ProductPictures => _prdPicturesGroupRepository ??
                                                                    (_prdPicturesGroupRepository =
                                                                        new ProductPicturesPersitenceRepository(db));

        public static ISimcardRepository Simcard => _simcardRepository ??
                                                              (_simcardRepository =
                                                                  new SimcardPersistenceRepository(db));

        public static IChatNumberRepository ChatNumbers => _chatNumberRepository ??
                                                    (_chatNumberRepository =
                                                        new ChatNumberPersitenceRepository(db));

        public static IDivarCategoryRepository DivarCategory => _divarCategoryRepository ??
                                                                    (_divarCategoryRepository =
                                                                        new DivarCategoreyPersistenceRepository(db));
    }
}
