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
        public DbSet<Size> Sizes { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //var connection = "Server=jimpizzaworld.database.windows.net,1433;Initial Catalog=PizzaWorldBuz;User ID=sqladmin;Password=;";
            var connection = "Server=jimpizzaworld.database.windows.net,1433;Initial Catalog=PizzaWorld2;User ID=sqladmin;Password=;";
            builder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pizza>().HasKey(pizza => pizza.EntityID);
            builder.Entity<Store>().HasKey(store => store.EntityID);
            builder.Entity<User>().HasKey(user => user.EntityID);
            builder.Entity<Topping>().HasKey(topping => topping.EntityID);
            builder.Entity<Crust>().HasKey(crust => crust.EntityID);
            builder.Entity<Size>().HasKey(size => size.EntityID);
            builder.Entity<Order>().HasKey(order => order.EntityID);
            
            //SeedPizzaData(builder);
            SeedStoreData(builder);
            SeedToppingData(builder);
            SeedSizeData(builder);
            SeedCrustData(builder);
        }
        private void SeedToppingData(ModelBuilder builder)
        {
            builder.Entity<Topping>().HasData(new List<Topping>()
            {
                APizzaPartFactory.MakeTopping("cheese"),
                APizzaPartFactory.MakeTopping("pepperoni"),
                APizzaPartFactory.MakeTopping("sausage"),
                APizzaPartFactory.MakeTopping("pineapple"),
                APizzaPartFactory.MakeTopping("ham"),
                APizzaPartFactory.MakeTopping("onion"),
                APizzaPartFactory.MakeTopping("mushroom"),
                APizzaPartFactory.MakeTopping("olive"),
                APizzaPartFactory.MakeTopping("sauce")
            });
        }
        private void SeedCrustData(ModelBuilder builder)
        {
            builder.Entity<Crust>().HasData(new List<Crust>
            {
                APizzaPartFactory.MakeCrust("regular"),
                APizzaPartFactory.MakeCrust("thin"),
                APizzaPartFactory.MakeCrust("pan")
            });
        }
        private void SeedSizeData(ModelBuilder builder)
        {
            builder.Entity<Size>().HasData(new List<Size>()
            {
                APizzaPartFactory.MakeSize("small"),
                APizzaPartFactory.MakeSize("medium"),
                APizzaPartFactory.MakeSize("large")
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
        private void SeedPizzaData(ModelBuilder builder)
        {
            builder.Entity<Pizza>().HasData(new List<Pizza>()
            {
                PizzaFactory.MakePizza("cheese"),
                PizzaFactory.MakePizza("pepperoni"),
                PizzaFactory.MakePizza("combo"),
                PizzaFactory.MakePizza("meat lover"),
                PizzaFactory.MakePizza("veggie lover"),
                PizzaFactory.MakePizza("hawaiian")                
            });
        }
    }

}