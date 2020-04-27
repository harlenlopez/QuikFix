using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    public class Carts
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public List<CartItems> CartItems = new List<CartItems>();


    }
}
