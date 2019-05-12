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
    public class PizzaIngredientsRepository : IEntityRepository<PizzaIngredient>
    {
        private readonly AppDbContext _context;

        public PizzaIngredientsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PizzaIngredient> Elements => _context.PizzaIngredients.Include(x => x.Pizza).Include((System.Linq.Expressions.Expression<Func<PizzaIngredient, Ingredient>>)(x => x.Ingredient)); //include here

        public void Add(PizzaIngredient pizzaIngredient)
        {
            _context.PizzaIngredients.Add(pizzaIngredient);
        }

        public IEnumerable<PizzaIngredient> GetAll()
        {
            return _context.PizzaIngredients.ToList();
        }

        public async Task<IEnumerable<PizzaIngredient>> GetAllAsync()
        {
            return await _context.PizzaIngredients.ToListAsync();
        }

        public PizzaIngredient GetById(int? id)
        {
            return _context.PizzaIngredients.FirstOrDefault(p => p.Id == id);
        }

        public async Task<PizzaIngredient> GetByIdAsync(int? id)
        {
            return await _context.PizzaIngredients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.PizzaIngredients.Any(p => p.Id == id);
        }

        public void Remove(PizzaIngredient pizzaIngredient)
        {
            _context.PizzaIngredients.Remove(pizzaIngredient);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(PizzaIngredient pizzaIngredient)
        {
            _context.PizzaIngredients.Update(pizzaIngredient);
        }
    }
}
