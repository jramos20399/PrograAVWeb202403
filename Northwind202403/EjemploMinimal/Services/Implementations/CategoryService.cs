using MinimalAPI.Model;

using DAL.Interfaces;
using Entities.Entities;
using EjemploMinimal.Services.Interfaces;

namespace EjemploMinimal.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private ICategoryDAL categoryDAL;

        private Category Convertir(CategoryModel category)
        {

            Category entity = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description

            };
            return entity;

        }


        private CategoryModel Convertir(Category category)
        {

            CategoryModel entity = new CategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description

            };
            return entity;

        }
        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                this._unidadDeTrabajo = unidadDeTrabajo;
        }


        public bool Add(CategoryModel category)
        {
           

             _unidadDeTrabajo.CategoryDAL.Add(Convertir(category));
            return _unidadDeTrabajo.Complete();

        }

        public CategoryModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.CategoryDAL.Get(id));
        }

        public IEnumerable<CategoryModel> Get()
        {
            var lista= _unidadDeTrabajo.CategoryDAL.GetAll();
            List<CategoryModel> categories = new List<CategoryModel>();
            foreach (var item in lista)
            {
                categories.Add(Convertir(item));
            }
            return categories;
        }

        public bool Remove(CategoryModel category)
        {
            
             _unidadDeTrabajo.CategoryDAL.Remove(Convertir(category));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(CategoryModel category)
        {
             _unidadDeTrabajo.CategoryDAL.Update(Convertir(category));
            return _unidadDeTrabajo.Complete();
        }
    }
}
