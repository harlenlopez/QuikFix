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
        public async Task<Carts> CreateCart(Carts carts)
        {
            _context.Cart.Add(carts);
            await _context.SaveChangesAsync();
            return carts;
        }

        public async Task DeleteCart(Carts carts)
        {
            _context.Cart.Remove(carts);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Carts>> GetAllCart() => await _context.Cart.ToListAsync();
        public async Task<Carts> GetCartById(string email)
        {
            var carts = await _context.Cart.Where(x => x.Email == email).SingleAsync();
            return carts;
        }

        public async Task<Carts> UpdateCart(Carts carts)
        {
            _context.Cart.Update(carts);
            await _context.SaveChangesAsync();
            return carts;
        }
    }
}
