using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        IUnidadDeTrabajo Unidad;

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }
        #region Convertir
        Category Convertir (CategoryDTO category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }


        CategoryDTO Convertir(Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        #endregion
     
        
        
        public bool Agregar(CategoryDTO category)
        {

            Category entity = Convertir(category);
           Unidad.CategoryDAL.Add(entity);
            return Unidad.Complete();
        }

        public bool Editar(CategoryDTO category)
        {
            var entity = Convertir(category);
            Unidad.CategoryDAL.Update(entity);
            return Unidad.Complete();   
        }

        public bool Eliminar(CategoryDTO category)
        {
            
            Unidad.CategoryDAL.Remove(Convertir(category));
            return Unidad.Complete();
        }

        public CategoryDTO Obtener(int id)
        {
            return  Convertir(Unidad.CategoryDAL.Get(id));
        }

        public List<CategoryDTO> Obtener()
        {
            List<CategoryDTO > list = new List<CategoryDTO>();
            var categories = Unidad.CategoryDAL.GetAll().ToList();

            foreach (var item in categories)
            {
                list.Add(Convertir(item));
            }

            return list; 
        }
    }
}
