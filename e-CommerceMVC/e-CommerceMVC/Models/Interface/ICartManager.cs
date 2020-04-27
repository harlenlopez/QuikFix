using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    public interface ICartManager
    {
        Task<Cart> GetCartById(int ID);
        // Create
        Task<Cart> CreateCart(Cart cart);
        // Get all products from the db
        Task<List<Cart>> GetAllCart();
        // Update
        Task<Cart> UpdateCart(Cart cart);
        // Delete
        Task DeleteCart(Cart cart);
    }
}
