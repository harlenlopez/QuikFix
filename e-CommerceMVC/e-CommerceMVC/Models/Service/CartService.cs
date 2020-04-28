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
        private readonly IProductManager _productManager;

        public CartService(StoreDbContext context, IProductManager productManager)
        {
            _context = context;
            _productManager = productManager;
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

        public async Task<List<CartItems>> GetProductByCartID(int id)
        {
            List<CartItems> cartList = await _context.CartItems.Where(x => x.CartsID == id).ToListAsync();
            foreach (var item in cartList)
            {
                var pro = await _productManager.GetInventoryById(item.ProductID);
                item.Product = pro;
            }

            return cartList;
        }

        public async Task<Carts> UpdateCart(Carts carts)
        {
            _context.Cart.Update(carts);
            await _context.SaveChangesAsync();
            return carts;
        }
    }
}
