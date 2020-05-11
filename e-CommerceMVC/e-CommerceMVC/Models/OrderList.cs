using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    public class OrderList
    {
        public int ID { get; set; }
        public int CartsID { get; set; }
        public int ProductID { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantities { get; set; }
        public Product Product { get; set; }
        public Carts Carts { get; set; }

    }
}
