using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO
{
    public class ProductDTO
    {

        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = null!;
        [Required]
        public int? SupplierId { get; set; }
        [Required]
        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }
    }
}
