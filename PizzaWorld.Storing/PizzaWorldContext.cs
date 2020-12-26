using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Storing
{

    public class PizzaWorldContext : DbContext
    {

        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=jimpizzaworld.database.windows.net,1433;Initial Catalog=PizzaWorldBuz;User ID=sqladmin;Password={};");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(store => store.EntityID);
            builder.Entity<User>().HasKey(user => user.EntityID);
            builder.Entity<Pizza>().HasKey(pizza => pizza.EntityID);
            builder.Entity<Order>().HasKey(order => order.EntityID);
            SeedStoreData(builder);
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
        private void SeedPizzaData(ModelBuilder builder)
        {
            builder.Entity<Pizza>().HasData(new List<Pizza>()
            {
                new Pizza {EntityID = 1}
            });
        }
    }

}