using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    public interface ICartItemsManager
    {
        //Read
        Task<CartItems> GetCartItemsById(int ID);
        // Create
        Task<CartItems> CreateCartItems(CartItems cartItems);
        // Update
        Task<CartItems> UpdateCartItems(CartItems cartItems);
        // Delete
        Task DeleteCartItems(int ID);
    }
}

