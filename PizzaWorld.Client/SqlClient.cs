using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client
{
    public class SqlClient
    {

        private readonly PizzaWorldContext _db = new PizzaWorldContext();

        public SqlClient()
        {
            
        }

        public IEnumerable<Order> ReadOrders(Store store) //How to make generic
        {
            return ReadOneStore(store.Name).Orders;
        }

        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }

        public Store ReadOneStore(string name)
        {
            return _db.Stores.FirstOrDefault<Store>(store => store.Name == name);
        }

        public void SaveStore(Store store)
        {
            _db.Add(store); //add
            _db.SaveChanges(); //commit
        }

        public void UpdateStore(Store store)
        {
            _db.SaveChanges();
        }

        public void SelectStore()
        {

        }
    }
}