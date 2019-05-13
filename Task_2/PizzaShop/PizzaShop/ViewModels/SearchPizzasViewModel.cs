using PizzaShop.Models;
using PizzaShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.ViewModels
{
    public class SearchPizzasViewModel
    {
        [Required]
        [DisplayName("Search")]
        public string SearchText { get; set; }

        public IEnumerable<Pizza> PizzaList { get; set; }

    }
}
