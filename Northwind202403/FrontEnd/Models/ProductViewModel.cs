namespace FrontEnd.Models
{
    public class ProductViewModel
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }

    }
}
