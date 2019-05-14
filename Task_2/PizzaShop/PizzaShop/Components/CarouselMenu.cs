using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Components
{
    public class CarouselMenu : ViewComponent
    {
        private readonly AppDbContext _context;
        public CarouselMenu(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pizzas = await _context.Pizzas.Where(x => x.IsPizzaOfTheWeek).ToListAsync();
            return View(pizzas);
        }
    }
}
