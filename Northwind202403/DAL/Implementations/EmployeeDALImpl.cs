using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EmployeeDALImpl : DALGenericoImpl<Employee>, IEmployeeDAL
    {

        NorthWindContext context;

        public EmployeeDALImpl(NorthWindContext context) : base(context)
        {
            this.context = context;
        }


    }
}
