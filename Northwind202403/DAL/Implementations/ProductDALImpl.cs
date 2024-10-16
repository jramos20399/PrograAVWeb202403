﻿using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProductDALImpl: DALGenericoImpl<Product>, IProductDAL
    {
        NorthWindContext context;


        public ProductDALImpl(NorthWindContext northWindContext): base(northWindContext) 
        {
                this.context = northWindContext;
        }

    }
}
