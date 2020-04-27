using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    interface ICartItemsManager
    {
        Task<CartItems> GetCartItemsById(int ID);
        // Create
        Task<CartItems> CreateCartItems(CartItems cartItems);
        // Get all products from the db
        Task<List<CartItems>> GetAllCartItems();
        // Update
        Task<CartItems> UpdateCartItems(CartItems cartItems);
        // Delete
        Task DeleteCartItems(CartItems cartItems);
    }
}

