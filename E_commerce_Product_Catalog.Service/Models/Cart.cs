using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Product_Catalog.Service.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }    
        public List<CartItem> Items { get; set;} = new List<CartItem>();
    }
}
