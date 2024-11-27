using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Model
{
    public class CategoryModel
    {

        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
