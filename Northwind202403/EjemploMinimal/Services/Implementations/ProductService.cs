using MinimalAPI.Model;

using DAL.Interfaces;
using Entities.Entities;
using EjemploMinimal.Services.Interfaces;

namespace EjemploMinimal.Services.Implementations
{
    public class ProductService : IProductService
    {
        IUnidadDeTrabajo Unidad;


        ProductModel Convertir(Product product)
        {
            return new ProductModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }

        Product Convertir(ProductModel product)
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

        public ProductService(IUnidadDeTrabajo unidad)
        {
            this.Unidad = unidad;
        }


        public bool Add(ProductModel product)
        {
            try
            {
                Unidad.ProductDAL.Add(Convertir(product));
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var producto = new Product { ProductId = id };
            Unidad.ProductDAL.Remove(producto);
            return Unidad.Complete();
        }

        public ProductModel GetProduct(int id)
        {
            return Convertir(Unidad.ProductDAL.Get(id));
        }

        public List<ProductModel> GetProducts()
        {
            var products = Unidad.ProductDAL.GetAll();

            List<ProductModel> productModels = new List<ProductModel>();

            foreach (var product in products)
            {
                productModels.Add(Convertir(product));
            }

            return productModels;

        }

        public bool Update(ProductModel product)
        {
            Unidad.ProductDAL.Update(Convertir(product));
            return Unidad.Complete();
        }
    }
}
