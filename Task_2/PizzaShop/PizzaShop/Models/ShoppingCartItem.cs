using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PizzaShop.Models.Entities;

namespace PizzaShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Pizza Pizza { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
