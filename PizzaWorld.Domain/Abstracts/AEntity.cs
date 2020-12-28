using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaWorld.Domain.Abstracts
{
    public abstract class AEntity
    {
        [Key]
        public long EntityID { get; set; }

        protected AEntity()
        {
            //EntityID = DateTime.Now.Ticks;
        }

        
    }
}