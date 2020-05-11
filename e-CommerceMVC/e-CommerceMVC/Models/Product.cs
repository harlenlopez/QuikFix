using ECommerceMVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    /// <summary>
    /// Model for storedbcontext database
    /// </summary>
    public class Product
    {
        public int ID { get; set; }

        public string SKU { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Nav properties
        /// </summary>
        public List<CartItems> CartItems = new List<CartItems>();
        public List<OrderList> OrderLists = new List<OrderList>();
        
    }
}
