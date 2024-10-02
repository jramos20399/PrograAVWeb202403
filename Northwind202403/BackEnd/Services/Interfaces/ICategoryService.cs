using BackEnd.DTO;


namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {

        bool Agregar(CategoryDTO category);
        bool Editar(CategoryDTO category);
        bool Eliminar(CategoryDTO category);
        /// <summary>
        /// Obtiene Category por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryDTO Obtener(int id);
        
        /// <summary>
        /// Obtiene todas la categories
        /// </summary>
        /// <returns></returns>
        List<CategoryDTO> Obtener();
    }
}
