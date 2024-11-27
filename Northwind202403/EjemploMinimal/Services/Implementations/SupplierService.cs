using MinimalAPI.Model;

using DAL.Interfaces;
using Entities.Entities;
using EjemploMinimal.Services.Interfaces;

namespace EjemploMinimal.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        public IUnidadDeTrabajo unidad;

        SupplierModel Convertir(Supplier supplier)
        {
            return new SupplierModel
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }

        public IEnumerable<SupplierModel> GetSuppliers()
        {
           var suppliers = unidad.SupplierDAL.GetAll();

            List<SupplierModel> supplierModels = new List<SupplierModel>();


            foreach (var item in suppliers)
            {
                supplierModels.Add(Convertir(item));
            }

            return supplierModels;

        }

        public SupplierModel GetSupplier(int id)
        {
            var supplier = unidad.SupplierDAL.Get(id);
            return Convertir(supplier);
        }

        public SupplierService(IUnidadDeTrabajo unidad)
        {
                this.unidad = unidad;
        }




    }
}
