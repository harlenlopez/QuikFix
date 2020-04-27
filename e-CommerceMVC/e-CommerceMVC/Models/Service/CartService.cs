using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class CartService : ICartManager
    {
        private readonly StoreDbContext _context;

        public CartService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<Cart> CreateCart(Cart cart)
        {
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task DeleteCart(Cart cart)
        {
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cart>> GetAllCart() => await _context.Cart.ToListAsync();
        public async Task<Cart> GetCartById(int ID)
        {
            var cart = await _context.Cart.FindAsync(ID);
            return cart;
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            _context.Cart.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
    }
}
