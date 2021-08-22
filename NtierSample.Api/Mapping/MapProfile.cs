using AutoMapper;
using NtierSample.Api.DTOs;
using NtierSample.Core.Models;

namespace NtierSample.Api.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category,CategoryDto>();
            CreateMap<CategoryDto,Category>();
            CreateMap<Category,CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto,Category>();
            CreateMap<Product,ProductDto>();
            CreateMap<ProductDto,Product>();
            CreateMap<ProductsWithCategoryDto,Product>();
            CreateMap<Product,ProductsWithCategoryDto>();
            CreateMap<Person,PersonDto>();
            CreateMap<PersonDto,Person>();
        }
    } 
}