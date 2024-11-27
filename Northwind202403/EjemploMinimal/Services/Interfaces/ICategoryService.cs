using MinimalAPI.Model;
using Entities.Entities;

namespace EjemploMinimal.Services.Interfaces
{
    public interface ICategoryService
    {


        bool Add(CategoryModel category);
        bool Remove(CategoryModel category);
        bool Update(CategoryModel category);

        CategoryModel Get(int id);
        IEnumerable<CategoryModel> Get();
    }
}
