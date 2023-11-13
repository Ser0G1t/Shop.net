using NewRepo.Enums;
using System.ComponentModel.DataAnnotations;

namespace NewRepo.DTO
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Product name is required!")]
        [MaxLength(30, ErrorMessage = "Maximum length of name is 30")]
        public string productName { get; set; }
        public string productDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Category is required!")]
        public ProductCategory category { get; set; }
        [Required(ErrorMessage = "Price is required!")]
        [Range(0, double.MaxValue, ErrorMessage ="Price have to be a number greather than 0")]
        public double price { get; set; }
    }
}
