using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public ICategoryDAL CategoryDAL { get; set; }
        public ISupplierDAL SupplierDAL { get; set; }

        private NorthWindContext _northWindContext;

        public UnidadDeTrabajo(NorthWindContext northWindContext,
                        ICategoryDAL categoryDAL
                       
            ) 
        {
                this._northWindContext = northWindContext;
                this.CategoryDAL = categoryDAL; 
                
        }
       

        public bool Complete()
        {
            try
            {
                _northWindContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._northWindContext.Dispose();
        }
    }
}
