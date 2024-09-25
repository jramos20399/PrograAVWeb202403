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


        public bool Agregar(Category category)
        {
           Unidad.CategoryDAL.Add(category);
            return Unidad.Complete();
        }

        public bool Editar(Category category)
        {
            Unidad.CategoryDAL.Update(category);
            return Unidad.Complete();   
        }

        public bool Eliminar(Category category)
        {
            Unidad.CategoryDAL.Remove(category);
            return Unidad.Complete();
        }

        public Category Obtener(int id)
        {
            return Unidad.CategoryDAL.Get(id);
        }

        public List<Category> Obtener()
        {
            return Unidad.CategoryDAL.GetAll().ToList(); 
        }
    }
}
