using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_product_catalog.Models;
using MediatR;

namespace E_commerce_Product_Catalog.Service.Commands.ManageCategories
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {
    }
}
