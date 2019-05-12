using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaShop.Models;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Models.Entities;
using PizzaShop.Repositories.Interfaces;

namespace PizzaShop.Repositories
{
    public class IngredientsRepository : IEntityRepository<Ingredient>
    {
        private readonly AppDbContext _context;

        public IngredientsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> Elements => _context.Ingredients.Include(x => x.PizzaIngredients); //include here

        public void Add(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _context.Ingredients.ToList();
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public Ingredient GetById(int? id)
        {
            return _context.Ingredients.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Ingredient> GetByIdAsync(int? id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Ingredients.Any(p => p.Id == id);
        }

        public void Remove(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
        }
    }
}
