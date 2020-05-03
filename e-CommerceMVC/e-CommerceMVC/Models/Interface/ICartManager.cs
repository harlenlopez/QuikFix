using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    public interface ICartManager
    {
        //read
        Task<Carts> GetCartById(string email);
        //Read
        Task<List<CartItems>> GetProductByCartID(int id);
        // Create
        Task<Carts> CreateCart(Carts carts);
    }
}
