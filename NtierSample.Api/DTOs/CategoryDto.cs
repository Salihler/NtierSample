using System.ComponentModel.DataAnnotations;

namespace NtierSample.Api.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}