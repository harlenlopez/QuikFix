using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    /// <summary>
    /// Model for cartItems will carry quantities
    /// </summary>
    public class CartItems
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int CartsID { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Nav properties
        /// </summary>
        public Carts Carts { get; set; }
        public Product Product { get; set; }
    }
}
