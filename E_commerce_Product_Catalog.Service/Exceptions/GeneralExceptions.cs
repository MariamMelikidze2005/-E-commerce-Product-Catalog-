﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Exceptions
{
    public class DatabaseExeption : DomainExeption
    {
        public DatabaseExeption()
            :base("Database error") 
        { }
    }

}
