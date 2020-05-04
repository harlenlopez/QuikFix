using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class CartItemsService : ICartItemsManager
    {
        private readonly StoreDbContext _context;

        /// <summary>
        /// Constructor that is bringing in db context
        /// </summary>
        /// <param name="context"></param>
        public CartItemsService(StoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Cart Item to be created
        /// </summary>
        /// <param name="cartItems">Cart item object</param>
        public async Task<CartItems> CreateCartItems(CartItems cartItems)
        {
            _context.CartItems.Add(cartItems);
            await _context.SaveChangesAsync();
            return cartItems;
        }

        /// <summary>
        /// Deleting the cart items
        /// </summary>
        /// <param name="ID">id of cartitem to be deleted</param>
        public async Task DeleteCartItems(int ID)
        {
            var cartItem = await _context.CartItems.FindAsync(ID);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Getting the cart item by its primary key
        /// </summary>
        /// <param name="ID">primary key</param>
        public async Task<CartItems> GetCartItemsById(int ID)
        {
            var cartItems = await _context.CartItems.FindAsync(ID);
            return cartItems;
        }

        /// <summary>
        /// Updating the cart item
        /// </summary>
        /// <param name="cartItems">cartitem object</param>
        public async Task<CartItems> UpdateCartItems(CartItems cartItems)
        {
            _context.CartItems.Update(cartItems);
            await _context.SaveChangesAsync();
            return cartItems;
        }
    }
}
