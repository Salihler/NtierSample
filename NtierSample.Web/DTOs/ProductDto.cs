using System.ComponentModel.DataAnnotations;

namespace NtierSample.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Name { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "{0} alanı 1den büyük değer olmalıdır.")]
        public int Stock { get; set ; }

        [Range(1,double.MaxValue, ErrorMessage = "{0} alanı 1den büyük değer olmalıdır.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}