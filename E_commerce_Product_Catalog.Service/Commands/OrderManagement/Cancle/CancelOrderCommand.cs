﻿using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement.Cancle
{
    public class CancelOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }

        public CancelOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}