using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {

        bool Agregar(Category category);
        bool Editar(Category category);
        bool Eliminar(Category category);
        /// <summary>
        /// Obtiene Category por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Category Obtener(int id);
        
        /// <summary>
        /// Obtiene todas la categories
        /// </summary>
        /// <returns></returns>
        List<Category> Obtener();
    }
}
