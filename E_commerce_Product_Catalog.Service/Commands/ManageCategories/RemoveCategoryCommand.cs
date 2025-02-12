﻿using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories
{
    public class RemoveCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}