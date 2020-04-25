using AutoMapper;
using EntityCache.Bussines;
using SqlServerPersistence.Entities;

namespace EntityCache.Assistence
{
   public class SqlProfile : Profile
    {
        public SqlProfile()
        {
            CreateMap<CustomerGroup, CustomerGroupBussines>().ReverseMap();
        }
    }
}
