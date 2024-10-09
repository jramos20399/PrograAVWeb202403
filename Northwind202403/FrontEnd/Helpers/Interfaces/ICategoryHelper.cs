using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoryHelper
    {
        List<CategoryViewModel> GetCategories();

        CategoryViewModel GetCategory(int id);  
        CategoryViewModel Add(CategoryViewModel category);
        CategoryViewModel Update(CategoryViewModel category);
        CategoryViewModel Delete(int id);
    }
}
