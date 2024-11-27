
using MinimalAPI.Model;

namespace EjemploMinimal.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> GetSuppliers();
        SupplierModel GetSupplier(int id);
    }
}
