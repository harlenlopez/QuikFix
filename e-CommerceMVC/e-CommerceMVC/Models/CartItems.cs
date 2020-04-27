using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    public class CartItems
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int CartID { get; set; }
        public int Quantity { get; set; }
        
        public Carts Carts { get; set; }
        public Product Product { get; set; }


    }
}
