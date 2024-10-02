using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        IServiceRepository _ServiceRepository;

        public CategoryHelper(IServiceRepository serviceRepository)
        {
                _ServiceRepository = serviceRepository;
        }

        public List<CategoryViewModel> GetCategories()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Category");
            List<Category> categories = new List<Category>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<Category>>(content);
            }

            List<CategoryViewModel> resultado = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                resultado.Add(
                            new CategoryViewModel 
                            { 
                                CategoryId = item.CategoryId,
                              CategoryName = item.CategoryName
                            }
                    );
            }
            return resultado;

        }

        public CategoryViewModel GetCategory(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Category/" + id.ToString());
            Category category = new Category();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<Category>(content);
            }

            CategoryViewModel resultado =
                            new CategoryViewModel
                            {
                                CategoryId = category.CategoryId,
                                CategoryName = category.CategoryName
                            };
                    
            
            return resultado;
        }
    }
}
