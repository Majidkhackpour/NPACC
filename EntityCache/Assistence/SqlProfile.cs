using AutoMapper;
using EntityCache.Bussines;
using EntityCache.WebBussines;
using SqlServerPersistence.Entities;

namespace EntityCache.Assistence
{
   public class SqlProfile : Profile
    {
        public SqlProfile()
        {
            CreateMap<CustomerGroup, CustomerGroupBussines>().ReverseMap();
            CreateMap<Customer, CustomerBussines>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupBussines>().ReverseMap();
            CreateMap<Product, ProductBussines>().ReverseMap();
            CreateMap<ProductPictures, ProductPicturesBussines>().ReverseMap();
            CreateMap<Simcard, SimcardBussines>().ReverseMap();
            CreateMap<DivarCategory, DivarCategoryBussines>().ReverseMap();
            CreateMap<ChatNumbers, ChatNumberBussines>().ReverseMap();
            CreateMap<Rolles, RolleBussines>().ReverseMap();
            CreateMap<Users, UserBussines>().ReverseMap();
            CreateMap<UserBussines, WebUsers>().ReverseMap();
        }
    }
}
