using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    public interface ICartManager
    {
        Task<Carts> GetCartById(string email);
        // Create
        Task<Carts> CreateCart(Carts carts);
        // Get all products from the db
        Task<List<Carts>> GetAllCart();
        // Update
        Task<Carts> UpdateCart(Carts carts);
        // Delete
        Task DeleteCart(Carts carts);
    }
}
