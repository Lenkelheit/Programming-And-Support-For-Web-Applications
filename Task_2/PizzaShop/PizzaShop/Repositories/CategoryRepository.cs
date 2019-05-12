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
    public class CategoryRepository : IEntityRepository<Category>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Elements => _context.Categories.Include(x => x.Pizzas); //include here

        public void Add(Category category)
        {
            _context.Add(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public Category GetById(int? id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Pizzas.Any(p => p.Id == id);
        }

        public void Remove(Category category)
        {
            _context.Remove(category);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Category category)
        {
            _context.Update(category);
        }

    }
}
