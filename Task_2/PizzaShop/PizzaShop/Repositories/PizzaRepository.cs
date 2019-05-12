using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Models;
using PizzaShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaShop.Repositories.Interfaces;

namespace PizzaShop.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext _context;

        public PizzaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pizza> Pizzas => _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients); //include here

        public IEnumerable<Pizza> PizzasOfTheWeek => _context.Pizzas.Where(p => p.IsPizzaOfTheWeek).Include(p => p.Category);

        public void Add(Pizza pizza)
        {
            _context.Add(pizza);
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public async Task<IEnumerable<Pizza>> GetAllAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<IEnumerable<Pizza>> GetAllIncludedAsync()
        {
            return await _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).ToListAsync();
        }

        public IEnumerable<Pizza> GetAllIncluded()
        {
            return _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).ToList();
        }

        public Pizza GetById(int? id)
        {
            return _context.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Pizza> GetByIdAsync(int? id)
        {
            return await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Pizza GetByIdIncluded(int? id)
        {
            return _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).FirstOrDefault(p => p.Id == id);
        }

        public async Task<Pizza> GetByIdIncludedAsync(int? id)
        {
            return await _context.Pizzas.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Pizzas.Any(p => p.Id == id);
        }

        public void Remove(Pizza pizza)
        {
            _context.Remove(pizza);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Pizza pizza)
        {
            _context.Update(pizza);
        }

    }
}
