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
            CreateMap<ProductGroupBussines, WebProductGroup>().ReverseMap();
            CreateMap<PrdSelectedGroup, PrdSelectedGroupBussines>().ReverseMap();
            CreateMap<PrdTag, PrdTagBussines>().ReverseMap();
            CreateMap<ProductBussines, WebProduct>().ReverseMap();
            CreateMap<PrdSelectedGroupBussines, WebPrdSelectedGroup>().ReverseMap();
            CreateMap<ProductPicturesBussines, WebProductPictures>().ReverseMap();
            CreateMap<FeatureBussines, Features>().ReverseMap();
            CreateMap<PrdFeatureBussines, PrdFeatures>().ReverseMap();
            CreateMap<PrdFeatureBussines, WebPrdFeature>().ReverseMap();
            CreateMap<FeatureBussines, WebFeature>().ReverseMap();
            CreateMap<PrdCommentBussines, PrdComment>().ReverseMap();
            CreateMap<PrdCommentBussines, WebPrdComment>().ReverseMap();
            CreateMap<OrderBussines, Order>().ReverseMap();
            CreateMap<OrderDetailBussines, OrderDetail>().ReverseMap();
            CreateMap<OrderBussines, WebOrder>().ReverseMap();
            CreateMap<OrderDetailBussines, WebOrerDetail>().ReverseMap();
            CreateMap<SliderBussines, Slider>().ReverseMap();
            CreateMap<SliderBussines, WebSlider>().ReverseMap();
            CreateMap<VisitBussines, Visit>().ReverseMap();
        }
    }
}
