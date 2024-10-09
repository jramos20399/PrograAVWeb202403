using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        SupplierDTO Get(int id);
        List<SupplierDTO> Get();
        SupplierDTO Add(SupplierDTO supplier);

        SupplierDTO Update(SupplierDTO supplier);
        void Delete(int id );
    }
}
