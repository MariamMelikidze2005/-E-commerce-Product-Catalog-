﻿using E_commerce_product_catalog.Exceptions;
using MediatR;
using IOrderRepository = E_commerce_Product_Catalog.Service.Abstractions.IOrderRepository;

namespace E_commerce_Product_Catalog.Service.Commands.OrderManagement.Cancle
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CancelOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if (order == null) throw new OrderNotFoundException(request.OrderId);
            if (order.Status != "Pending") throw new InvalidOperationException("Only orders with 'Pending' status can be cancelled.");

            order.Status = "Canceled";
            await _orderRepository.UpdateOrderAsync(order);
            return default;
        }
    }
}