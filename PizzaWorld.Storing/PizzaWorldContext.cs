using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Models;
using PizzaWorld.Domain.Factory;

namespace PizzaWorld.Storing
{
    public class PizzaWorldContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connection = "Server=jimpizzaworld.database.windows.net,1433;Initial Catalog=PizzaWorld2;User ID=sqladmin;Password=;";
            builder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(store => store.EntityID);
            //builder.Entity<Store>().HasMany(store => store.Orders);
            
            builder.Entity<User>().HasKey(user => user.EntityID);
            //builder.Entity<User>().HasMany(user => user.Orders);
            
            builder.Entity<Topping>().HasKey(topping => topping.EntityID);
            
            builder.Entity<Crust>().HasKey(crust => crust.EntityID);
            
            builder.Entity<Size>().HasKey(size => size.EntityID);

            builder.Entity<Order>().HasKey(order => order.EntityID);
            // builder.Entity<Order>().HasMany(order => order.Pizzas);
            
            builder.Entity<Pizza>().HasKey(pizza => pizza.EntityID);
            // builder.Entity<Pizza>().OwnsOne(pizza => pizza.Crust);
            // builder.Entity<Pizza>().OwnsOne(pizza => pizza.Size);
            // builder.Entity<Pizza>().HasMany(pizza => pizza.Toppings);

            SeedStoreData(builder);
            SeedToppingData(builder);
            SeedSizeData(builder);
            SeedCrustData(builder);
        }
        private void SeedToppingData(ModelBuilder builder)
        {
            builder.Entity<Topping>().HasData(new List<Topping>()
            {
                new Topping("cheese", 1d) { EntityID = 1},
                new Topping("pepperoni") { EntityID = 2},
                new Topping("sausage") { EntityID = 3},
                new Topping("pineapple") { EntityID = 4},
                new Topping("ham") { EntityID = 5},
                new Topping("onion") { EntityID = 6},
                new Topping("mushroom") { EntityID = 7},
                new Topping("olive") { EntityID = 8},
                new Topping("sauce", 2d) { EntityID = 9}
            });
        }
        private void SeedCrustData(ModelBuilder builder)
        {
            builder.Entity<Crust>().HasData(new List<Crust>
            {
                new Crust("regular", 1d){ EntityID = 1},
                new Crust("thin", 1.5d){ EntityID = 2 },
                new Crust("pan", 1.75d){ EntityID = 3 }
            });
        }
        private void SeedSizeData(ModelBuilder builder)
        {
            builder.Entity<Size>().HasData(new List<Size>()
            {
                new Size("regular", 1d){ EntityID = 1 },
                new Size("medium", 2d){ EntityID = 2 },
                new Size("large", 3d){ EntityID = 3 }
            });
        }
        private void SeedStoreData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>()
            {
                new Store { EntityID = 1, Name = "Domino's" },
                new Store { EntityID = 2, Name = "Pizza Hut" },
                new Store { EntityID = 3, Name = "Papa John's" },
                new Store { EntityID = 4, Name = "Generic Pizza Place" }
            });
        }
    }
}