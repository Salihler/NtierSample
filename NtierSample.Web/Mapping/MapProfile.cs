using AutoMapper;
using NtierSample.Web.DTOs;
using NtierSample.Core.Models;

namespace NtierSample.Web.Mapping
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