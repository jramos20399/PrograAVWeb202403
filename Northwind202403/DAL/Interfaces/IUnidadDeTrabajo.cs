using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        ICategoryDAL CategoryDAL { get; }
        ISupplierDAL SupplierDAL { get; } 
        
        IProductDAL ProductDAL { get; }
       

        bool Complete();
    }
}
