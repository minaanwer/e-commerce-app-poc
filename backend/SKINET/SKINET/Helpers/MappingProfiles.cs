using AutoMapper;
using Core.Entities;
using SKINET.Dtos;

namespace SKINET.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Product, ProductToReturnDto>().
                ForMember(i => i.ProductType, item => item.MapFrom(o => o.ProductType != null ? o.ProductType.Name : ""))
               .ForMember(i => i.ProductBrand, item => item.MapFrom(o => o.ProductBrand != null ? o.ProductBrand.Name : ""));
        }
    }
}
