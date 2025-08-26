using AutoMapper;
using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.DTOs;

namespace GestFarmacy.Api.Mapping
{
    /// <summary>
    /// AutoMapper profile configuration.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<Sale, SaleResponse>().ReverseMap();
        }
    }
}
