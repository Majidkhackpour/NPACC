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
        private static IRolleRepository _rollesRepository;
        private static IUserRepository _usersRepository;
        private static IPrdSelectedGroupRepository _prdSelectedGroupRepository;
        private static IPrdTagRepository _prdTagRepository;
        private static IFeatureRepository _featureRepository;
        private static IPrdFeatureRepository _prdFeatureRepository;
        private static IPrdCommentRepository _prdCommentRepository;


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

        public static IRolleRepository Rolles => _rollesRepository ??
                                                           (_rollesRepository =
                                                               new RollesPersistenceRepository(db));

        public static IUserRepository Users => _usersRepository ??
                                                                (_usersRepository =
                                                                    new UsersPersistenceRepository(db));

        public static IPrdSelectedGroupRepository PrdSelectedGroup => _prdSelectedGroupRepository ??
                                                                      (_prdSelectedGroupRepository =
                                                                          new PrdSelectedGroupPersistenceRepository(db)
                                                                      );

        public static IPrdTagRepository PrdTag => _prdTagRepository ??
                                                  (_prdTagRepository =
                                                      new PrdTagPersistenceRepository(db));

        public static IFeatureRepository Feature => _featureRepository ??
                                                    (_featureRepository =
                                                        new FeaturePersistenceRepository(db));

        public static IPrdFeatureRepository PrdFeature => _prdFeatureRepository ??
                                                          (_prdFeatureRepository =
                                                              new PrdFeaturePersistenceRepository(db));

        public static IPrdCommentRepository PrdComment => _prdCommentRepository ??
                                                          (_prdCommentRepository =
                                                              new PrdCommentPersistenceRepository(db));
    }
}
