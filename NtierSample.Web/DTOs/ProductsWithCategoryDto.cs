using System.Collections.Generic;

namespace NtierSample.Web.DTOs
{
    public class ProductsWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}