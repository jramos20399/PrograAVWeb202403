using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {
        IServiceRepository _ServiceRepository;

        public SupplierHelper(IServiceRepository serviceRepository)
        {
                this._ServiceRepository = serviceRepository;
        }


        SupplierViewModel Convertir(Supplier supplier)
        {
            return new SupplierViewModel
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
            };
        }
        public List<SupplierViewModel> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>();

            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/supplier");

            if (responseMessage != null) { 
            
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                suppliers = JsonConvert.DeserializeObject<List<Supplier>>(content);
                
            }
            List<SupplierViewModel> supplierViewModels = new List<SupplierViewModel>();

            foreach (var item in suppliers)
            {
                supplierViewModels.Add(Convertir(item));
            }
            return supplierViewModels;

        }
    }
}
