using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        ProductDTO Add(ProductDTO product);
        ProductDTO Update(ProductDTO product);  
        void Delete(int id);
        ProductDTO GetById(int id);



    }
}
