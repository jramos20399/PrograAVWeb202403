using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        IUnidadDeTrabajo _Unidad;

        public SupplierService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        Supplier Convertir(SupplierDTO supplier) 
        {
            return new Supplier
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        
        
        }
        SupplierDTO Convertir(Supplier supplier)
        {
            return new SupplierDTO
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };


        }


        public SupplierDTO Add(SupplierDTO supplier)
        {
            _Unidad.SupplierDAL.Add(Convertir(supplier));
            return supplier;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SupplierDTO Get(int id)
        {
            var result = _Unidad.SupplierDAL.Get(id);
            return Convertir(result);
        }

        public List<SupplierDTO> Get()
        {
            var result = _Unidad.SupplierDAL.GetAll();
            List<SupplierDTO> list = new List<SupplierDTO>();
            foreach (var item in result) {
                list.Add(Convertir(item));
            }
            return list;
        }

        public SupplierDTO Update(SupplierDTO supplier)
        {
            throw new NotImplementedException();
        }
    }
}
