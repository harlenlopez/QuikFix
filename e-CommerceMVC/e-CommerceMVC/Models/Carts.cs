using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    /// <summary>
    /// Carts model for database
    /// </summary>
    public class Carts
    {
        public int ID { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Nav properties
        /// </summary>
        public List<CartItems> CartItems = new List<CartItems>();


    }
}
