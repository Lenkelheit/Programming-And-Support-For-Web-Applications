using PizzaShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Models.Entities
{
    public class OrderDetail : EntityBase
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
