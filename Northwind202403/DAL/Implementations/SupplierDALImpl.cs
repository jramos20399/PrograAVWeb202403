using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class SupplierDALImpl : DALGenericoImpl<Supplier>, ISupplierDAL
    {
        NorthWindContext _context;


        public SupplierDALImpl(NorthWindContext Context): base(Context) 
        {
                _context = Context;
        }
    }
}
