using System.ComponentModel.DataAnnotations;
using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        
    }

    public class ProductModifyResponse
    {
        public bool isModified { get; set; } = false;
        public ProductError Error { get; set; } = new ProductError();
    }
}
