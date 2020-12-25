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
            builder.UseSqlServer("Server=jimpizzaworld.database.windows.net,1433;Initial Catalog=PizzaWorldBuz;User ID=sqladmin;Password=Momo0Kagami;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(store => store.EntityID);
            builder.Entity<User>().HasKey(user => user.EntityID);
            builder.Entity<Pizza>().HasKey(pizza => pizza.EntityID);
            builder.Entity<Order>().HasKey(order => order.EntityID);
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>()
                {
                    new Store { EntityID = 2, Name = "Store1" },
                    new Store { EntityID = 3, Name = "Store2" },
                    new Store { EntityID = 4, Name = "Store3" }
                }
            );
        }
    }

}