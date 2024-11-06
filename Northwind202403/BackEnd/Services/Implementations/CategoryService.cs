using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        IUnidadDeTrabajo Unidad;
        ILogger<CategoryService> _logger;    

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo, ILogger<CategoryService> logger)
        {
            this.Unidad = unidadDeTrabajo;
            _logger = logger;   
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
            try
            {
                _logger.LogInformation("Ingresa a Obtener CatService");
                List<CategoryDTO> list = new List<CategoryDTO>();
                var categories = Unidad.CategoryDAL.GetAll().ToList();

                foreach (var item in categories)
                {
                    list.Add(Convertir(item));
                }
                _logger.LogInformation("Antes de return CatService GetAll");
                return list;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
        }
    }
}
