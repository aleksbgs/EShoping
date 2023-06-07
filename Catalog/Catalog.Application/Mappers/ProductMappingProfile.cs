using AutoMapper;
using Catalog.Core.Entities;
using Catalog.Application.Responses;

namespace Catalog.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();
    }
}