using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductHelper : IProductHelper
    {
        IServiceRepository _repository;

        public ProductHelper(IServiceRepository serviceRepository)
        {
                this._repository = serviceRepository;
        }

        ProductViewModel Convertir(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = (int) product.CategoryId,
                Discontinued = product.Discontinued
            };
        }

        Product Convertir(ProductViewModel product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }



        public ProductViewModel AddProduct(ProductViewModel ProductViewModel)
        {
            HttpResponseMessage responseMessage = _repository.PostResponse("api/product", Convertir(ProductViewModel));
            if (responseMessage != null) {
                    var content = responseMessage.Content;
            }


            return ProductViewModel;

        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/product" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }


            
        }

        public ProductViewModel EdiProduct(ProductViewModel ProductViewModel)
        {
            HttpResponseMessage responseMessage = _repository.PutResponse("api/product", Convertir(ProductViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }


            return ProductViewModel;
        }

        public List<ProductViewModel> GetAll()
        {
            List<Product> products = new List<Product>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/product");


            if (responseMessage != null) { 
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                products= JsonConvert.DeserializeObject<List<Product>>(content);
            
            
            }

            List<ProductViewModel> list = new List<ProductViewModel>();


            foreach (var item in products)
            {
                list.Add(Convertir(item));
            }
            return list;


        }

        public ProductViewModel GetById(int id)
        {
            Product product = new Product();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/product");


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(content);


            }

            return Convertir(product);
        }
    }
}
