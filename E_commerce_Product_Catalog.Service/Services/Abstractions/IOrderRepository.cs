﻿using E_commerce_Product_Catalog.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Services.Abstractions
{
    internal interface IOrderRepository
    {
        Order GetByOrderId(Guid orderId);
        void SaveOrderInfo(Order order);
    }
}
