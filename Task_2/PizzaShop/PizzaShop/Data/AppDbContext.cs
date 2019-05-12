using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaShop.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using PizzaShop.Models;

namespace PizzaShop.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PizzaIngredient>().HasKey(pin => new { pin.PizzaId, pin.IngredientId });

            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(pin => pin.Pizza)
                .WithMany(pi => pi.PizzaIngredients)
                .HasForeignKey(pin => pin.PizzaId);

            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(pin => pin.Ingredient)
                .WithMany(ing => ing.PizzaIngredients)
                .HasForeignKey(pin => pin.IngredientId);

            // adds data
            //dbInitializer.Seed(modelBuilder);
        }
    }
}
