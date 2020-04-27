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

        public CartItemsService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartItems> CreateCartItems(CartItems cartItems)
        {
            _context.CartItems.Add(cartItems);
            await _context.SaveChangesAsync();
            return cartItems;

        }

        public async Task DeleteCartItems(CartItems cartItems)
        {
            _context.CartItems.Remove(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItems>> GetAllCartItems() => await _context.CartItems.ToListAsync();

        public async Task<CartItems> GetCartItemsById(int ID)
        {
            var cartItems = await _context.CartItems.FindAsync(ID);
            return cartItems;
        }

        public async Task<CartItems> UpdateCartItems(CartItems cartItems)
        {
            _context.CartItems.Update(cartItems);
            await _context.SaveChangesAsync();
            return cartItems;
        }
    }
}
