using System.Collections.Generic;

namespace NtierSample.Api.DTOs
{
    public class ProductsWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}