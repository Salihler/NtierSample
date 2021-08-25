using System.ComponentModel.DataAnnotations;

namespace NtierSample.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boi olamaz.")]
        public string Name { get; set; }
    }
}